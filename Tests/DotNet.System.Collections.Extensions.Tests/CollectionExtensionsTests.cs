using DotNet.System.Collections.Generic.Extensions;
using System.Collections.Generic;
using Xunit;

namespace DotNet.System.Collections.Extensions.Tests
{
    public class CollectionExtensionsTests
    {
        [Theory]
        [InlineData(new[] { 1, 2 }, new[] { 3, 4 }, new[] { 1, 2, 3, 4 })]
        public void AddRange_Method_Should_Add_Items_To_The_Collection(IEnumerable<int> inittialItems, IEnumerable<int> itemsToAdd, IEnumerable<int> expectedResult)
        {
            // Arrange
            ICollection<int> collection = new List<int>(inittialItems);

            // Act
            collection.AddRange(itemsToAdd);

            // Assert
            Assert.Equal(expectedResult, collection);
        }
    }
}