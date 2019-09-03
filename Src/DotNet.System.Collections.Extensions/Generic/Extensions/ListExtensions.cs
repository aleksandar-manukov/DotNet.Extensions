using System;
using System.Collections.Generic;

namespace DotNet.System.Collections.Generic.Extensions
{
    /// <summary>
    /// Class containing <see cref="IList{T}"/> extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Tries to find the first element which meats the predicate. If the element is found it is removed from the list and returned otherwise default(T) is returned.
        /// </summary>
        /// <typeparam name="T">Generic parameter for <see cref="IList{T}"/>.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> collection from which trying to find and remove an element which meats the predicate.</param>
        /// <param name="predicate">Predicate to be applied to each element of the list.</param>
        /// <returns>Found and removed element from the collection or the default(T).</returns>
        /// <exception cref="ArgumentNullException">Thrown when collection or action are null.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="PopOrDefault{T}(IList{T}, Func{T, bool})"/>.
        /// <code>
        /// IList{User} users = new List{User}
        /// {{ 
        ///     new User {{ Id = 1, Score = 1 }}, 
        ///     new User {{ Id = 2, Score = 2 }}
        /// }};
        ///
        /// User user = users.PopOrDefault(u => u.Score >= 1);
        /// </code>
        /// </example>
        public static T PopOrDefault<T>(this IList<T> list, Func<T, bool> predicate)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List cannot be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                {
                    T item = list[i];

                    list.RemoveAt(i);

                    return item;
                }
            }

            return default(T);
        }
    }
}