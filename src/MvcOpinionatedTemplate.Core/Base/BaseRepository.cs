using MvcOpinionatedTemplate.Core.Interfaces;
using MvcOpinionatedTemplate.Core.Interfaces.Repositories.Base;

namespace MvcOpinionatedTemplate.Core.Base
{
    /// <summary>
    /// Base Repository, inherited by all Repositories by default
    /// </summary>
    public abstract class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// Username or Process associated with instance
        /// </summary>
        public IUserContext UserContext { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        protected BaseRepository(IUserContext userContext)
        {
            UserContext = userContext;
        }
    }
}
