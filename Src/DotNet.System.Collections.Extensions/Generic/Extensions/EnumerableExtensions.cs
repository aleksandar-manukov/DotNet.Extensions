using System;
using System.Collections.Generic;

namespace DotNet.System.Collections.Generic.Extensions
{
    /// <summary>
    /// Class containing <see cref="IEnumerable{T}"/> extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Applies provided action to each element of the collection and returns the collection.
        /// </summary>
        /// <typeparam name="T">Generic parameter for <see cref="IEnumerable{T}"/> collection.</typeparam>
        /// <param name="collection"><see cref="IEnumerable{T}"/> collection for which elements provided action will be executed.</param>
        /// <param name="action">Action to be applied to each element of the collection.</param>
        /// <returns>Collection with updated items.</returns>
        /// <exception cref="ArgumentNullException">Thrown when collection or action are null.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="ForEach{T}(IEnumerable{T}, Action{T})"/>.
        /// <code>
        /// IEnumerable{User} users = new List{User}
        /// {{ 
        ///     new User {{ Id = 1, Score = 1 }}, 
        ///     new User {{ Id = 2, Score = 2 }}
        /// }};
        ///
        /// IDictionary{int, User} usersDictionary = users.ForEach(u => u.Score * 2).ToDictionary(u => u.Id);
        /// </code>
        /// </example>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection cannot be null.");
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), "Action cannot be null.");
            }

            foreach (T item in collection)
            {
                action.Invoke(item);
            }

            return collection;
        }
    }
}