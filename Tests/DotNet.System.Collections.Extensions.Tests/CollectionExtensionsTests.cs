using System;
using System.Collections.Generic;
using DotNet.System.Collections.Generic.Extensions;
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

        [Fact]
        public void AddRange_Method_Should_Throw_ArgumentNullException_When_Passed_Collection_Is_Null()
        {
            // Arrange
            ICollection<int> collection = new List<int>();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => collection.AddRange(null));
        }

        [Theory]
        [InlineData(new string[] { "string 1", "   ", "", "string 2", null }, new[] { "string 1", "string 2" })]
        public void RemoveWhere_Method_Should_Remove_Null_Empty_Or_Only_White_Spaces_Strings_From_The_Collection(IEnumerable<string> inittialItems, IEnumerable<string> expectedResult)
        {
            // Arrange
            ICollection<string> collection = new List<string>(inittialItems);

            // Act
            collection.RemoveWhere(s => string.IsNullOrWhiteSpace(s));

            // Assert
            Assert.Equal(expectedResult, collection);
        }

        [Fact]
        public void RemoveWhere_Method_Should_Throw_ArgumentNullException_When_Passed_Collection_Is_Null()
        {
            // Arrange
            ICollection<int> collection = new List<int>();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => collection.RemoveWhere(null));
        }
    }
}