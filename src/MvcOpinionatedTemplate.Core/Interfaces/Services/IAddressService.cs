using MvcOpinionatedTemplate.Core.Interfaces.Domain;
using System.Collections.Generic;

namespace MvcOpinionatedTemplate.Core.Interfaces.Services
{
    public interface IAddressService
    {
        IReadOnlyList<IState> GetAllStates();
    }
}
