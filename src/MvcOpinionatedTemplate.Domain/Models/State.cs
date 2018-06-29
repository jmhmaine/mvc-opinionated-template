using MvcOpinionatedTemplate.Core.Interfaces.Domain;
using MvcOpinionatedTemplate.Domain.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcOpinionatedTemplate.Domain.Models
{
    /// <summary>
    /// State Model
    /// </summary>
    [Serializable]
    public class State : BaseReferenceDataModel, IState
    {
        [Required]
        public string StateCode { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string StateName { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public State() : base() { }

        /// <summary>
        /// Constructor allows overriding userOrProcessName
        /// </summary>
        public State(string userOrProcessName) : base(userOrProcessName) { }
    }
}
