using MvcOpinionatedTemplate.Core.Interfaces.Domain.Base;

namespace MvcOpinionatedTemplate.Core.Interfaces.Domain
{
    public interface IState : IBaseReferenceDataModel
    {
        string CountryCode { get; set; }

        string StateCode { get; set; }

        string StateName { get; set; }
    }
}
