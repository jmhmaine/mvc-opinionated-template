using MvcOpinionatedTemplate.Core.Base;
using MvcOpinionatedTemplate.Core;
using MvcOpinionatedTemplate.Core.Interfaces.Domain;
using MvcOpinionatedTemplate.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Diagnostics;
using MvcOpinionatedTemplate.Core.Interfaces;
using MvcOpinionatedTemplate.Core.Interfaces.Repositories;

namespace MvcOpinionatedTemplate.Services.Domain
{
    public class AddressService : BaseService, IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public const string StatesCacheKey = "StateListManagedByStateService";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressRepository">Address Repository</param>
        /// <param name="userContext">UserContext from instantiating class</param>
        public AddressService(IAddressRepository addressRepository, IUserContext userContext) : base(userContext)
        {
            _addressRepository = addressRepository;
        }

        public IReadOnlyList<IState> GetAllStates()
        {
            var list = CommonCache<IState>.GetAll(StatesCacheKey);

            if (list != null) return list;

            list = _addressRepository.GetAllStates();

            if (list == null)
                list = new List<IState>();
            else
                CommonCache<IState>.Set(list, StatesCacheKey);

            return list;
        }

    }
}
