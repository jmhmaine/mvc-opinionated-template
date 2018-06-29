using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Serilog;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOpinionatedTemplate.Web
{

    /// <summary>
    /// ASP.NET Core app with smart request logging middleware, based on example from:
    /// https://github.com/datalust/serilog-middleware-example/blob/master/src/Datalust.SerilogMiddlewareExample/Diagnostics/SerilogMiddleware.cs
    /// More information on ASP.NET Core Middleware:
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.1&amp;tabs=aspnetcore2x
    /// </summary>
    public class SerilogMiddleware
    {
        private const string MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} to {RequestIP} in {Elapsed:0.0000} ms";

        private static readonly ILogger Log = Serilog.Log.ForContext<SerilogMiddleware>();

        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next">RequestDelegate type is a required parameter for extensions of IApplicationBuilder middleware</param>
        public SerilogMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Logs request and exception of request
        /// Required method for extensions of IApplicationBuilder middleware
        /// </summary>
        /// <param name="httpContext">HttpContext type is a required parameter for extensions of IApplicationBuilder middleware</param>
        /// <returns>Async Task</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            var sw = Stopwatch.StartNew();

            try
            {
                await _next(httpContext);
                sw.Stop();

                var statusCode = httpContext.Response?.StatusCode;
                var level = statusCode > 499 ? LogEventLevel.Error : LogEventLevel.Information;
                var log = level == LogEventLevel.Error ? LogForErrorContext(httpContext) : Log;

                if (level == LogEventLevel.Error) return; // errors already logged via LogException

                log.Write(level, MessageTemplate, httpContext.Request.Method, GetPath(httpContext), statusCode, 
                            httpContext.Connection.RemoteIpAddress, sw.Elapsed.TotalMilliseconds);
            }
            catch (Exception ex) when (LogException(httpContext, sw, ex))
            {
                // Never caught, because LogException() returns false.
            }
        }

        private static bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
        {
            sw.Stop();

            LogForErrorContext(httpContext)
                .Error(ex, MessageTemplate, httpContext.Request.Method, GetPath(httpContext), 500, 
                            httpContext.Connection.RemoteIpAddress, sw.Elapsed.TotalMilliseconds);

            return false;
        }

        private static ILogger LogForErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var result = Log
                .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
                .ForContext("RequestHost", request.Host)
                .ForContext("RequestProtocol", request.Protocol);

            if (request.HasFormContentType)
                result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));

            return result;
        }

        private static PathString GetPath(HttpContext httpContext)
        {
            var rawTarget = httpContext.Features.Get<IHttpRequestFeature>()?.RawTarget;

            return rawTarget != null ? new PathString(rawTarget) : httpContext.Request.Path;
        }
    }
}
