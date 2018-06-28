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

    }
}
