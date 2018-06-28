using MvcOpinionatedTemplate.Core.Base;
using System.Collections.Generic;
using System.Linq;
using MvcOpinionatedTemplate.Core.Interfaces;
using MvcOpinionatedTemplate.Core.Interfaces.Domain;
using MvcOpinionatedTemplate.Core.Interfaces.Repositories;
using MvcOpinionatedTemplate.Domain.Models;

namespace MvcOpinionatedTemplate.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(IUserContext userContext) : base(userContext) { }

        /// <summary>
        /// List of all United States and Canadian States, Territories, and other regions that have a postal code.
        /// Normally this would be maintained in a datastore, but it is explicitly listed for the purposes of the template.
        /// </summary>
        /// <returns>Read only list of States</returns>
        public IReadOnlyList<IState> GetAllStates()
        {
            var list = new List<IState>();

            list.Add(new State() { CountryCode = "US", StateCode = "AL", StateName = "Alabama" });
            list.Add(new State() { CountryCode = "US", StateCode = "AK", StateName = "Alaska" });
            list.Add(new State() { CountryCode = "US", StateCode = "AZ", StateName = "Arizona" });
            list.Add(new State() { CountryCode = "US", StateCode = "AR", StateName = "Arkansas" });
            list.Add(new State() { CountryCode = "US", StateCode = "CA", StateName = "California" });
            list.Add(new State() { CountryCode = "US", StateCode = "CO", StateName = "Colorado" });
            list.Add(new State() { CountryCode = "US", StateCode = "CT", StateName = "Connecticut" });
            list.Add(new State() { CountryCode = "US", StateCode = "DC", StateName = "District of Columbia" });
            list.Add(new State() { CountryCode = "US", StateCode = "DE", StateName = "Delaware" });
            list.Add(new State() { CountryCode = "US", StateCode = "FL", StateName = "Florida" });
            list.Add(new State() { CountryCode = "US", StateCode = "GA", StateName = "Georgia" });
            list.Add(new State() { CountryCode = "US", StateCode = "HI", StateName = "Hawaii" });
            list.Add(new State() { CountryCode = "US", StateCode = "ID", StateName = "Idaho" });
            list.Add(new State() { CountryCode = "US", StateCode = "IL", StateName = "Illinois" });
            list.Add(new State() { CountryCode = "US", StateCode = "IN", StateName = "Indiana" });
            list.Add(new State() { CountryCode = "US", StateCode = "IA", StateName = "Iowa" });
            list.Add(new State() { CountryCode = "US", StateCode = "KS", StateName = "Kansas" });
            list.Add(new State() { CountryCode = "US", StateCode = "KY", StateName = "Kentucky" });
            list.Add(new State() { CountryCode = "US", StateCode = "LA", StateName = "Louisiana" });
            list.Add(new State() { CountryCode = "US", StateCode = "ME", StateName = "Maine" });
            list.Add(new State() { CountryCode = "US", StateCode = "MD", StateName = "Maryland" });
            list.Add(new State() { CountryCode = "US", StateCode = "MA", StateName = "Massachusetts" });
            list.Add(new State() { CountryCode = "US", StateCode = "MI", StateName = "Michigan" });
            list.Add(new State() { CountryCode = "US", StateCode = "MN", StateName = "Minnesota" });
            list.Add(new State() { CountryCode = "US", StateCode = "MS", StateName = "Mississippi" });
            list.Add(new State() { CountryCode = "US", StateCode = "MO", StateName = "Missouri" });
            list.Add(new State() { CountryCode = "US", StateCode = "MT", StateName = "Montana" });
            list.Add(new State() { CountryCode = "US", StateCode = "NE", StateName = "Nebraska" });
            list.Add(new State() { CountryCode = "US", StateCode = "NV", StateName = "Nevada" });
            list.Add(new State() { CountryCode = "US", StateCode = "NH", StateName = "New Hampshire" });
            list.Add(new State() { CountryCode = "US", StateCode = "NM", StateName = "New Mexico" });
            list.Add(new State() { CountryCode = "US", StateCode = "NY", StateName = "New York" });
            list.Add(new State() { CountryCode = "US", StateCode = "NC", StateName = "North Carolina" });
            list.Add(new State() { CountryCode = "US", StateCode = "ND", StateName = "North Dakota" });
            list.Add(new State() { CountryCode = "US", StateCode = "OH", StateName = "Ohio" });
            list.Add(new State() { CountryCode = "US", StateCode = "OK", StateName = "Oklahoma" });
            list.Add(new State() { CountryCode = "US", StateCode = "OR", StateName = "Oregon" });
            list.Add(new State() { CountryCode = "US", StateCode = "PA", StateName = "Pennsylvania" });
            list.Add(new State() { CountryCode = "US", StateCode = "RI", StateName = "Rhode Island" });
            list.Add(new State() { CountryCode = "US", StateCode = "SC", StateName = "South Carolina" });
            list.Add(new State() { CountryCode = "US", StateCode = "SD", StateName = "South Dakota" });
            list.Add(new State() { CountryCode = "US", StateCode = "TN", StateName = "Tennessee" });
            list.Add(new State() { CountryCode = "US", StateCode = "TX", StateName = "Texas" });
            list.Add(new State() { CountryCode = "US", StateCode = "UT", StateName = "Utah" });
            list.Add(new State() { CountryCode = "US", StateCode = "VT", StateName = "Vermont" });
            list.Add(new State() { CountryCode = "US", StateCode = "VA", StateName = "Virginia" });
            list.Add(new State() { CountryCode = "US", StateCode = "WA", StateName = "Washington" });
            list.Add(new State() { CountryCode = "US", StateCode = "WV", StateName = "West Virginia" });
            list.Add(new State() { CountryCode = "US", StateCode = "WI", StateName = "Wisconsin" });
            list.Add(new State() { CountryCode = "US", StateCode = "WY", StateName = "Wyoming" });

            // Insular area 
            list.Add(new State() { CountryCode = "US", StateCode = "AS", StateName = "American Samoa" });
            list.Add(new State() { CountryCode = "US", StateCode = "GU", StateName = "Guam" });
            list.Add(new State() { CountryCode = "US", StateCode = "MP", StateName = "Northern Mariana Islands" });
            list.Add(new State() { CountryCode = "US", StateCode = "PR", StateName = "Puerto Rico" });
            list.Add(new State() { CountryCode = "US", StateCode = "GU", StateName = "Guam" });
            list.Add(new State() { CountryCode = "US", StateCode = "VI", StateName = "U.S. Virgin Islands" });

            // Freely associated state
            list.Add(new State() { CountryCode = "US", StateCode = "FM", StateName = "Micronesia" });
            list.Add(new State() { CountryCode = "US", StateCode = "MH", StateName = "Marshall Islands" });
            list.Add(new State() { CountryCode = "US", StateCode = "PW", StateName = "Palau" });

            // US military mail code
            list.Add(new State() { CountryCode = "US", StateCode = "AA", StateName = "U.S. Armed Forces – Americas" });
            list.Add(new State() { CountryCode = "US", StateCode = "AE", StateName = "U.S. Armed Forces – Europe" });
            list.Add(new State() { CountryCode = "US", StateCode = "AP", StateName = "U.S. Armed Forces – Pacific" });

            // Canadian provinces and territories
            list.Add(new State() { CountryCode = "CA", StateCode = "AB", StateName = "Alberta" });
            list.Add(new State() { CountryCode = "CA", StateCode = "BC", StateName = "British Columbia" });
            list.Add(new State() { CountryCode = "CA", StateCode = "MB", StateName = "Manitoba" });
            list.Add(new State() { CountryCode = "CA", StateCode = "NB", StateName = "New Brunswick" });
            list.Add(new State() { CountryCode = "CA", StateCode = "NL", StateName = "Newfoundland and Labrador" });
            list.Add(new State() { CountryCode = "CA", StateCode = "NT", StateName = "Northwest Territories" });
            list.Add(new State() { CountryCode = "CA", StateCode = "MS", StateName = "Nova Scotia" });
            list.Add(new State() { CountryCode = "CA", StateCode = "NU", StateName = "Nunavut" });
            list.Add(new State() { CountryCode = "CA", StateCode = "ON", StateName = "Ontario" });
            list.Add(new State() { CountryCode = "CA", StateCode = "PE", StateName = "Prince Edward Island" });
            list.Add(new State() { CountryCode = "CA", StateCode = "QC", StateName = "Quebec" });
            list.Add(new State() { CountryCode = "CA", StateCode = "SK", StateName = "Saskatchewan" });
            list.Add(new State() { CountryCode = "CA", StateCode = "YT", StateName = "Yukon" });

            return list;
        }

        public IState GetStateByCode(string code)
        {
            return GetAllStates().SingleOrDefault(l => l.StateCode == code);
        }
    }
}
