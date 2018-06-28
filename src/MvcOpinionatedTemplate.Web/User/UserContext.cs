using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MvcOpinionatedTemplate.Core.Interfaces;

namespace MvcOpinionatedTemplate.Web.User
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IConfiguration _configuration;

        public UserContext(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            _configuration = configuration;
        }

        public string UserName => this._accessor.HttpContext.User.Identity.Name;

        public string ProcessName => _configuration["ProcessName"];

        public string UserNameOrProcess => UserName ?? ProcessName;
    }
}
