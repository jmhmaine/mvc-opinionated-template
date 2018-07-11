using MvcOpinionatedTemplate.Core.Extensions;
using Xunit;

namespace MvcOpinionatedTemplate.Core.Test.Extensions
{
    public class StringExtensionTest
    {
        [Fact]
        public void StripNonDigits_ShouldDeleteNonDigits()
        {
            // Arrange
            const string stringValue = "(123) 555-1212";
            const string expected = "1235551212";

            // Act
            var actual = stringValue.StripNonDigits();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StripNonDigits_ShouldReturnSameValue()
        {
            // Arrange
            const string stringValue = "1235551212";
            const string expected = "1235551212";

            // Act
            var actual = stringValue.StripNonDigits();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StripNonDigits_ShouldReturnSameValueNull()
        {
            // Arrange
            const string stringValue = null;
            const string expected = null;

            // Act
            var actual = stringValue.StripNonDigits();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StripNonDigits_ShouldReturnSameValueEmptyString()
        {
            // Arrange
            const string stringValue = "";
            const string expected = "";

            // Act
            var actual = stringValue.StripNonDigits();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
