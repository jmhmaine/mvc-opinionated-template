using Microsoft.Extensions.Logging;
using MvcOpinionatedTemplate.Core.Base;
using MvcOpinionatedTemplate.Core.Interfaces;
using MvcOpinionatedTemplate.Core.Interfaces.Domain;
using MvcOpinionatedTemplate.Core.Interfaces.Repositories;
using MvcOpinionatedTemplate.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcOpinionatedTemplate.Services.Domain
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICacheClass _cache;
        private readonly ILogger<AddressService> _logger;

        public const string StatesCacheKey = "StateListManagedByStateService";

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressRepository">Address Repository</param>
        /// <param name="cache">ICommonCache implementation instance</param>
        /// <param name="logger">ILogger implementation instance</param>
        /// <param name="userContext">UserContext from instantiating class</param>
        public AddressService(IAddressRepository addressRepository, 
                              ICacheClass cache, 
                              ILogger<AddressService> logger, 
                              IUserContext userContext) : base(userContext)
        {
            _addressRepository = addressRepository;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IReadOnlyList<T>> GetAllStatesAsync<T>() where T : IState
        {
            var list = await _cache.GetAsync<IReadOnlyList<T>>(StatesCacheKey);

            if (list != null) return list;

            var repoList = _addressRepository.GetAllStates().Cast<T>().ToList();

            _logger.LogInformation("GetAllStates retrieved from repository, not in cache.");

            await _cache.SetAsync(StatesCacheKey, repoList);

            return repoList;
        }

    }
}
