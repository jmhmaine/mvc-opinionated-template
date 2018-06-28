using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace MvcOpinionatedTemplate.Web.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        protected ILogger<T> Logger;

        protected IConfiguration Configuration;

        protected BaseController(IConfiguration configuration, ILogger<T> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }
    }
}
