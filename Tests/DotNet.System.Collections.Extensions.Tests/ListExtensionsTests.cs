using System;
using System.Collections.Generic;
using DotNet.System.Collections.Generic.Extensions;
using Xunit;

namespace DotNet.System.Collections.Extensions.Tests
{
    public class ListExtensionsTests
    {
        [Theory]
        [InlineData(new[] { "string 1", "string 2" }, "string", "string 1")]
        public void PopOrDefault_Method_Should_Find_The_First_Item_Corresponding_To_The_Passed_Predicate(string[] passedItems, string searchItem, string expectedResult)
        {
            // Arrange
            IList<string> items = new List<string>(passedItems);

            // Act
            string actualResult = items.PopOrDefault(i => i.StartsWith(searchItem));

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new[] { "string 1", "string 2" }, "a", 2)]
        public void PopOrDefault_Method_Should_Keep_The_List_The_Same_When_Cannot_Find_An_Item(string[] passedItems, string searchItem, int expectedResult)
        {
            // Arrange
            IList<string> items = new List<string>(passedItems);

            // Act
            string actualResult = items.PopOrDefault(i => i.StartsWith(searchItem));

            // Assert
            Assert.Equal(expectedResult, items.Count);
        }

        [Theory]
        [InlineData(new[] { 1, 2 }, 3, 0)]
        public void PopOrDefault_Method_Should_Return_The_Default_Value_When_Cannot_Find_An_Item(int[] passedItems, int searchItem, int expectedResult)
        {
            // Arrange
            IList<int> items = new List<int>(passedItems);

            // Act
            int actualResult = items.PopOrDefault(i => i == searchItem);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void PopOrDefault_Method_Should_Throw_ArgumentNullException_When_Passed_Predicate_Is_Null()
        {
            // Arrange
            IList<int> items = new List<int>();

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => items.PopOrDefault(null));
        }
    }
}