using System;

namespace MvcOpinionatedTemplate.TestSupport
{
    /// <summary>
    /// Used for unit tests that require an object that doesn't have the Serializable attribute
    /// </summary>
    public class ObjectNotSerializable
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
