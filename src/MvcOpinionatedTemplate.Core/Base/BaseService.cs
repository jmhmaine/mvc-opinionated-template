using MvcOpinionatedTemplate.Core.Interfaces;
using MvcOpinionatedTemplate.Core.Interfaces.Services.Base;

namespace MvcOpinionatedTemplate.Core.Base
{
    /// <summary>
    /// Base Service, inherited by all Services by default
    /// </summary>
    public abstract class BaseService : IBaseService
    {
        /// <summary>
        /// Username or Process associated with instance
        /// </summary>
        public IUserContext UserContext { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        protected BaseService(IUserContext userContext)
        {
            UserContext = userContext;
        }
    }
}
