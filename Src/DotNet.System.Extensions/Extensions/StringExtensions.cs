using System;
using System.Text;

namespace DotNet.System.Extensions
{
    /// <summary>
    /// Class containing <see cref="string"/> extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts any string to camel case.
        /// </summary>
        /// <param name="text">String to be converted to camel case string.</param>
        /// <returns>String in camel case.</returns>
        /// <exception cref="ArgumentNullException">Thrown when string is null, empty or contains only white spaces.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="ToCamelCase(string)"/>.
        /// <code>
        /// string testString = "This is a test string.";
        ///
        /// string camelCaseTestString = testString.ToCamelCase();
        ///
        /// Console.WriteLine(camelCaseTestString); // thisIsATestString
        /// </code>
        /// </example>
        public static string ToCamelCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Text cannot be null, empty or contains only white spaces.");
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
        /// <summary>
        /// Converts any string to pascal case.
        /// </summary>
        /// <param name="text">String to be converted to pascal case string.</param>
        /// <returns>String in pascal case.</returns>
        /// <exception cref="ArgumentNullException">Thrown when string is null, empty or contains only white spaces.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="ToPascalCase(string)"/>.
        /// <code>
        /// string testString = "This is a test string.";
        ///
        /// string pascalCaseTestString = testString.ToPascalCase();
        ///
        /// Console.WriteLine(pascalCaseTestString); // ThisIsATestString
        /// </code>
        /// </example>
        public static string ToPascalCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Text cannot be null, empty or contains only white spaces.");
            }

            StringBuilder sb = new StringBuilder();
            bool shouldBeUpperCase = true;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetterOrDigit(text[i]))
                {
                    if (shouldBeUpperCase)
                    {
                        sb.Append(text[i].ToString().ToUpper());

                        shouldBeUpperCase = false;
                    }
                    else
                    {
                        sb.Append(text[i]);
                    }
                }
                else
                {
                    shouldBeUpperCase = true;
                }
            }

            return sb.ToString();
        }
    }
}