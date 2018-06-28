using System.Collections.Generic;
using MvcOpinionatedTemplate.Core.Interfaces.Domain;

namespace MvcOpinionatedTemplate.Core.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        IReadOnlyList<IState> GetAllStates();

        IState GetStateByCode(string code);
    }
}
