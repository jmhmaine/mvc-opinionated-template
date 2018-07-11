using MvcOpinionatedTemplate.Core.Extensions;
using MvcOpinionatedTemplate.Domain.Models;
using MvcOpinionatedTemplate.TestSupport;
using Xunit;

namespace MvcOpinionatedTemplate.Core.Test.Extensions
{
    public class ObjectExtensionTest
    {
        [Fact]
        public void IsSerializable_ShouldBeSerializable()
        {
            // Arrange
            var state = new State() {StateCode = "ME", CountryCode = "US"};

            // Act
            var actual = state.IsSerializable();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void IsSerializable_ShouldNotBeSerializable()
        {
            // Arrange
            var state = new ObjectNotSerializable() {Name = "Test", Value = "Value01"};

            // Act
            var actual = state.IsSerializable();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void IsSerializable_ShouldNotBeSerializableNull()
        {
            // Arrange
            State state = null;

            // Act
            var actual = state.IsSerializable();

            // Assert
            Assert.False(actual);
        }
    }
}
