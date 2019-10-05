using System;
using System.Reflection;

namespace DotNet.System.Extensions
{
    /// <summary>
    /// Class containing <see cref="Type"/> extensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Get property attribute.
        /// </summary>
        /// <param name="type">Type of which you are searching the property attribute.</param>
        /// <param name="property">Property name.</param>
        /// <returns>Returns attribute of this type if the property is decorated with it otherwise returns null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when type is null or property is null, empty or contains only white spaces.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="GetPropertyAttribute{T}(Type, string)"/>.
        /// <code>
        /// Type userType = typeof(User);
        ///
        /// DisplayAttribute displayAttribute = userType.GetPropertyAttribute{DisplayAttribute}(nameof(User.FirstName));
        ///
        /// string userFirstNameLabel = displayAttribute.GetName();
        /// </code>
        /// </example>
        public static T GetPropertyAttribute<T>(this Type type, string property)
            where T : Attribute
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type), "Type cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(property))
            {
                throw new ArgumentNullException(nameof(property), "Property cannot be null, empty or consists only white spaces.");
            }

            return type.GetProperty(property)?
                .GetCustomAttribute<T>(true);
        }
    }
}