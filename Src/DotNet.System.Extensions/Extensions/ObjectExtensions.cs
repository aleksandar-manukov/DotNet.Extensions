using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DotNet.System.Extensions
{
    /// <summary>
    /// Class containing <see cref="object"/> extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get property attribute.
        /// </summary>
        /// <param name="obj">Object of which you are searching the property attribute.</param>
        /// <param name="propertyExpression">Property expression.</param>
        /// <returns>Returns attribute of this type if the property is decorated with it otherwise returns null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when object is null or property expression is null.</exception>
        /// <exception cref="ArgumentException">Thrown when property expression is not of type of <see cref="MemberExpression"/> or when member of property expression is not of type <see cref="PropertyInfo"/>.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="GetPropertyAttribute{TObject, TAttribute}(TObject, Expression{Func{TObject, object}})"/>.
        /// <code>
        /// User user = new User();
        ///
        /// DisplayAttribute displayAttribute = user.GetPropertyAttribute{User, DisplayAttribute}(u => u.FirstName);
        ///
        /// string userFirstNameLabel = displayAttribute.GetName();
        /// </code>
        /// </example>
        public static TAttribute GetPropertyAttribute<TObject, TAttribute>(this TObject obj, Expression<Func<TObject, object>> propertyExpression)
            where TObject : class
            where TAttribute : Attribute
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null.");
            }

            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression), "Property expression cannot be null.");
            }

            MemberExpression memberSelectorExpression = propertyExpression.Body as MemberExpression;
            if (memberSelectorExpression == null)
            {
                throw new ArgumentException("Property expression should be of type of member expression.", nameof(propertyExpression));
            }

            PropertyInfo property = memberSelectorExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("Member of property expression should be of type PropertyInfo.");
            }

            return property.GetCustomAttribute<TAttribute>(true);
        }
    }
}