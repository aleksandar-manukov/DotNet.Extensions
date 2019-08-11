using System;
using System.Text;

namespace DotNet.System.Extensions
{
    /// <summary>
    /// Class containing string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts any string to camel case.
        /// </summary>
        /// <param name="text">String to be converted to camel case string.</param>
        /// <returns></returns>
        /// <example>
        /// This is an example, showing how to use <see cref="ToCamelCase(string)"/>.
        /// <code>
        /// string test = "This is a test string.";
        ///
        /// string camelCaseTest = text.ToCamelCase();
        ///
        /// Console.WriteLine(camelCaseTest); // thisIsATestString
        /// </code>
        /// </example>
        public static string ToCamelCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(string.Empty, "Text cannot be null, empty or contains only white spaces.");
            }

            StringBuilder sb = new StringBuilder();
            bool shouldBeLowerCase = true;
            bool shouldBeUpperCase = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i]))
                {
                    if (shouldBeLowerCase)
                    {
                        sb.Append(text[i].ToString().ToLower());

                        shouldBeLowerCase = false;
                    }
                    else if (shouldBeUpperCase)
                    {
                        sb.Append(text[i].ToString().ToUpper());

                        shouldBeUpperCase = false;
                    }
                    else
                    {
                        sb.Append(text[i]);
                    }
                }
                else if (!shouldBeLowerCase)
                {
                    shouldBeUpperCase = true;
                }
            }

            return sb.ToString();
        }
    }
}