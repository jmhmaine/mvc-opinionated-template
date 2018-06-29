using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MvcOpinionatedTemplate.Core.Base;
using MvcOpinionatedTemplate.Core.Interfaces;
using MvcOpinionatedTemplate.Core.Interfaces.Domain;
using MvcOpinionatedTemplate.Core.Interfaces.Repositories;
using MvcOpinionatedTemplate.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MvcOpinionatedTemplate.Services.Domain
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<AddressService> _logger;

        public const string StatesCacheKey = "StateListManagedByStateService";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressRepository">Address Repository</param>
        /// <param name="userContext">UserContext from instantiating class</param>
        public AddressService(IAddressRepository addressRepository, IMemoryCache cache, ILogger<AddressService> logger, IUserContext userContext) : base(userContext)
        {
            _addressRepository = addressRepository;
            _cache = cache;
            _logger = logger;
        }

        public IReadOnlyList<IState> GetAllStates()
        {
            var list = _cache.Get<IReadOnlyList<IState>>(StatesCacheKey);

            if (list != null) return list;

            list = _addressRepository.GetAllStates();
            _logger.LogInformation("GetAllStates retrieved from repository, not in cache.");

            if (list == null)
                list = new List<IState>();
            else
                _cache.Set(StatesCacheKey, list);

            return list;
        }

    }
}
