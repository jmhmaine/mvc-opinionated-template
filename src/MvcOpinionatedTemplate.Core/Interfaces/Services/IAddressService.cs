using MvcOpinionatedTemplate.Core.Interfaces.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvcOpinionatedTemplate.Core.Interfaces.Services
{
    public interface IAddressService
    {
        Task<IReadOnlyList<T>> GetAllStatesAsync<T>() where T : IState;
    }
}
