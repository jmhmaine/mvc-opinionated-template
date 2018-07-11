using System;
using System.Reflection;

namespace MvcOpinionatedTemplate.Core.Extensions
{
    public static class ObjectExtension
    {
        /// <summary>
        /// Gets a value indicating whether the System.Type associated with objectInstance is serializable.
        /// Note, null values will always return false. 
        /// </summary>
        /// <param name="objectInstance">Instance of Object to test</param>
        /// <returns>true if the System.Type is serializable and not null; otherwise, false.</returns>
        public static bool IsSerializable(this object objectInstance)
        {
            return objectInstance != null && objectInstance.GetType().IsSerializable;
        }
    }
}
