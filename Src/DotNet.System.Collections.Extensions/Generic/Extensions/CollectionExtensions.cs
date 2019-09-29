using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet.System.Collections.Generic.Extensions
{
    /// <summary>
    /// Class containing <see cref="ICollection{T}"/> extensions.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds elements to the collection.
        /// </summary>
        /// <typeparam name="T">Generic parameter for <see cref="ICollection{T}"/>.</typeparam>
        /// <param name="collection"><see cref="ICollection{T}"/> collection to which adding the elements.</param>
        /// <param name="items">Items to be added to the collection.</param>
        /// <exception cref="ArgumentNullException">Thrown when collection or items to be added are null.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="AddRange{T}(ICollection{T}, IEnumerable{T})"/>.
        /// <code>
        /// ICollection{int} numbers = new[] { 1, 2, 3 };
        /// 
        /// numbers.AddRange(new[] { 4, 5, 6 });
        /// </code>
        /// </example>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection cannot be null.");
            }

            if (items == null)
            {
                throw new ArgumentNullException(nameof(items), "Items cannot be null.");
            }

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Removes all items which corresponds to the predicate.
        /// </summary>
        /// <typeparam name="T">Generic parameter for <see cref="ICollection{T}"/>.</typeparam>
        /// <param name="collection"><see cref="ICollection{T}"/> collection from which removing the elements.</param>
        /// <param name="predicate">Predicate to be applied to each element of the collection.</param>
        /// <exception cref="ArgumentNullException">Thrown when collection or predicate are null.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="RemoveWhere{T}(ICollection{T}, Func{T, bool})"/>.
        /// <code>
        /// ICollection{int} numbers = new[] { 1, 2, 3 };
        /// 
        /// numbers.RemoveWhere(n => n % 2 == 0);
        /// </code>
        /// </example>
        public static void RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection cannot be null.");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate cannot be null.");
            }

            IEnumerable<T> itemsToRemove = collection.Where(predicate).ToArray();
            foreach (T item in itemsToRemove)
            {
                collection.Remove(item);
            }
        }
    }
}