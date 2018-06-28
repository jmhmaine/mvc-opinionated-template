using System.Text.RegularExpressions;

namespace MvcOpinionatedTemplate.Core.Extensions
{
    /// <summary>
    /// Common String Extensions
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Remove non-digits from String Value
        /// </summary>
        /// <param name="stringValue">Value of string</param>
        /// <returns>String value without digits</returns>
        public static string StripNonDigits(this string stringValue)
        {
            var digitsOnly = new Regex(@"[^\d]");

            return string.IsNullOrEmpty(stringValue) ? stringValue : digitsOnly.Replace(stringValue, "");
        }
    }
}
