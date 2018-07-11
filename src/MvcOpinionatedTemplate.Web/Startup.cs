using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcOpinionatedTemplate.Core.Interfaces;
using MvcOpinionatedTemplate.Core.Interfaces.Repositories;
using MvcOpinionatedTemplate.Core.Interfaces.Services;
using MvcOpinionatedTemplate.Repositories;
using MvcOpinionatedTemplate.Services.Domain;
using MvcOpinionatedTemplate.Services.Infrastructure;
using MvcOpinionatedTemplate.Web.User;
using System;

namespace MvcOpinionatedTemplate.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider(); // configures TempData provider from using cookie to Session

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1); // TODO: Update after testing
                options.Cookie.HttpOnly = true;
            });

            services.AddSingleton<ICacheClass, CacheClass>();

            // Register Repositories
            services.AddTransient<IAddressRepository, AddressRepository>();

            // Register Services
            services.AddTransient<IAddressService, AddressService>();

            // Scoped
            services.AddScoped<IUserContext, UserContext>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseMiddleware<SerilogMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
