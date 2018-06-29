using MvcOpinionatedTemplate.Core.Interfaces.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcOpinionatedTemplate.Domain.Models.Base
{
    [Serializable]
    public abstract class BaseReferenceDataModel : IBaseReferenceDataModel
    {
        /// <summary>
        /// Modified By
        /// </summary>
        [Display(Name = "Modified By")]
        public virtual string ModifiedBy { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        [Display(Name = "Modified Date")]
        public virtual DateTimeOffset? ModifiedDate { get; set; }

        /// <summary>
        /// User or Process name that instantiates object
        /// </summary>
        public string UserOrProcessName { get; set; }

        /// <summary>
        /// Default Constructor, uses Environment.UserName to populate UserOrProcessName
        /// </summary>
        protected BaseReferenceDataModel()
        {
            UserOrProcessName = Environment.UserName;
        }

        /// <summary>
        /// Constructor allows consumer to pass UserOrProcessName
        /// </summary>
        protected BaseReferenceDataModel(string userOrProcessName)
        {
            UserOrProcessName = userOrProcessName;
        }
    }
}
