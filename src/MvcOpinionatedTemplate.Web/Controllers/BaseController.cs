using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MvcOpinionatedTemplate.Web.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        protected readonly ILogger<T> Logger;

        protected readonly IConfiguration Configuration;

        protected BaseController(IConfiguration configuration, ILogger<T> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }
    }
}
