using System;
using System.IO;
using System.Reflection;

namespace DotNet.System.Reflection.Extensions
{
    /// <summary>
    /// Class containing <see cref="Assembly"/> extensions.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets assembly folder path.
        /// </summary>
        /// <param name="assembly">Assembly which folder is searched.</param>
        /// <returns>Assembly folder path.</returns>
        /// <exception cref="ArgumentNullException">Thrown when assembly is null.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="GetAssemblyFolder(Assembly)"/>.
        /// <code>
        /// string assemblyFolder = Assembly.GetExecutingAssembly().GetAssemblyFolder();
        ///
        /// string configurationPath = Path.Combine(assemblyFolder, "Configuration.xml");
        ///
        /// string configuration = File.ReadAllText(configurationPath);
        /// </code>
        /// </example>
        public static string GetAssemblyFolder(this Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly), "Assembly cannot be null.");
            }

            UriBuilder uriBuilder = new UriBuilder(assembly.CodeBase);
            string assemblyPath = Uri.UnescapeDataString(uriBuilder.Path);

            return Path.GetDirectoryName(assemblyPath);
        }
    }
}