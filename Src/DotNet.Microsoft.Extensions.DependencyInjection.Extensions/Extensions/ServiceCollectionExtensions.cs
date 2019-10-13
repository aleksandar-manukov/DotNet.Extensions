using System;
using System.Reflection;
using DotNet.System.Collections.Generic.Extensions;
using DotNet.System.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Microsoft.Extensions.DependencyInjection.Extensions
{
    /// <summary>
    /// Class containing <see cref="IServiceCollection"/> extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <inheritdoc cref="AddAll(IServiceCollection, Type, ServiceLifetime)" />
        public static IServiceCollection AddAll<T>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            return services.AddAll(typeof(T), serviceLifetime);
        }

        /// <inheritdoc cref="AddAll(IServiceCollection, Type, Assembly, ServiceLifetime)" />
        public static IServiceCollection AddAll<T>(this IServiceCollection services, Assembly assembly, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            return services.AddAll(typeof(T), assembly, serviceLifetime);
        }

        /// <summary>
        /// Add all classes which inherits or implements the base type from the assembly where base type exists.
        /// </summary>
        /// <inheritdoc cref="AddAll(IServiceCollection, Type, Assembly, ServiceLifetime)" />
        public static IServiceCollection AddAll(this IServiceCollection services, Type baseType, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            return services.AddAll(baseType, Assembly.GetAssembly(baseType), serviceLifetime);
        }

        /// <summary>
        /// Add all classes which inherits or implements the base type from the specific assembly.
        /// </summary>
        /// <param name="services">Service collection.</param>
        /// <param name="baseType">Base type.</param>
        /// <param name="assembly"><see cref="Assembly"/> in which to search.</param>
        /// <param name="serviceLifetime"><see cref="ServiceLifetime"/> with which the founded classes to be added.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when services, baseType or assembly is null.</exception>
        /// <exception cref="ArgumentException">Thrown when serviceLifeTime is different from <see cref="ServiceLifetime.Transient"/>, <see cref="ServiceLifetime.Scoped"/> or <see cref="ServiceLifetime.Singleton"/>.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="AddAll(IServiceCollection, Type, Assembly, ServiceLifetime)"/>.
        /// <code>
        /// services.AddAll(typeof(IDbService), Assembly.GetAssembly(typeof(IDbService)), ServiceLifeTime.Scoped);
        /// </code>
        /// </example>
        public static IServiceCollection AddAll(this IServiceCollection services, Type baseType, Assembly assembly, ServiceLifetime serviceLifetime = ServiceLifetime.Transient)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services), "Services cannot be null.");
            }

            if (baseType == null)
            {
                throw new ArgumentNullException(nameof(baseType), "Base type cannot be null.");
            }

            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), "Assembly cannot be null.");
            }

            assembly.GetExportedTypes()
                .ForEach(t =>
                {
                    if (!t.IsAbstract &&
                        ((baseType.IsInterface && t.ImplementsInterface(baseType)) ||
                            (!baseType.IsInterface && baseType.IsAssignableFrom(t))))
                    {
                        switch (serviceLifetime)
                        {
                            case ServiceLifetime.Singleton:
                                services.AddSingleton(t);
                                break;

                            case ServiceLifetime.Scoped:
                                services.AddScoped(t);
                                break;

                            case ServiceLifetime.Transient:
                                services.AddTransient(t);
                                break;

                            default:
                                throw new ArgumentException($"Unsupported ServiceLifeTime enum value: {serviceLifetime.ToString()}.", nameof(serviceLifetime));
                        }
                    }
                });

            return services;
        }
    }
}