using System;

namespace MvcOpinionatedTemplate.Core.Interfaces.Domain.Base
{
    public interface IBaseReferenceDataModel
    {
        string ModifiedBy { get; set; }

        DateTimeOffset? ModifiedDate { get; set; }

        string UserOrProcessName { get; set; }
    }
}
