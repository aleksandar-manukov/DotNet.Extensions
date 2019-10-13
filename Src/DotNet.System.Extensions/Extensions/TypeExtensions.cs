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

        /// <inheritdoc cref="ImplementsInterface(Type, Type)" />
        /// <example>
        /// This is an example, showing how to use <see cref="ImplementsInterface{T}(Type)"/>.
        /// <code>
        /// Type usersDbServiceType = typeof(UsersDbService);
        ///
        /// if (usersDbServiceType.ImplementsInterface{IDbService}()))
        /// {   
        ///     .......
        /// }
        /// </code>
        /// </example>
        public static bool ImplementsInterface<T>(this Type type)
        {
            return type.ImplementsInterface(typeof(T));
        }

        /// <summary>
        /// Check whether type implements interface.
        /// </summary>
        /// <param name="type">Type for which checking whether implements interface.</param>
        /// <param name="interfaceType">Interface type.</param>
        /// <returns>Returns true if this type implements interface otherwise returns false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when type is null or interfaceType is null.</exception>
        /// <exception cref="ArgumentException">Thrown when interfaceType is not an interface.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="ImplementsInterface(Type, Type)"/>.
        /// <code>
        /// Type usersDbServiceType = typeof(UsersDbService);
        ///
        /// if (usersDbServiceType.ImplementsInterface(typeof(IDbService)))
        /// {   
        ///     .......
        /// }
        /// </code>
        /// </example>
        public static bool ImplementsInterface(this Type type, Type interfaceType)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type), "Type cannot be null.");
            }

            if (interfaceType == null)
            {
                throw new ArgumentNullException(nameof(interfaceType), "Interface type cannot be null.");
            }

            if (!interfaceType.IsInterface)
            {
                throw new ArgumentException("Passed type as argument is not an interface type.", nameof(interfaceType));
            }

            bool isInterfaceImplemented = false;
            if (interfaceType.IsGenericType)
            {
                Type implementedInterfaceType = type.GetInterface(interfaceType.GetGenericTypeDefinition().Name);
                if (implementedInterfaceType != null)
                {
                    Type[] interfaceArgumentsTypes = interfaceType.GetGenericArguments();
                    Type[] implementedInterfaceArgumentsTypes = implementedInterfaceType.GetGenericArguments();
                    if (interfaceArgumentsTypes.Length == implementedInterfaceArgumentsTypes.Length)
                    {
                        isInterfaceImplemented = true;

                        for (int i = 0; i < interfaceArgumentsTypes.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(interfaceArgumentsTypes[i].AssemblyQualifiedName) &&
                                interfaceArgumentsTypes[i].AssemblyQualifiedName != implementedInterfaceArgumentsTypes[i].AssemblyQualifiedName)
                            {
                                isInterfaceImplemented = false;

                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                isInterfaceImplemented = type.GetInterface(interfaceType.Name) != null;
            }

            return isInterfaceImplemented;
        }
    }
}