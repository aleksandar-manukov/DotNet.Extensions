using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.System.Collections.Extensions.Tests.Models;
using DotNet.System.Collections.Generic.Extensions;
using Xunit;

namespace DotNet.System.Collections.Extensions.Tests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void ForEach_Method_Should_Apply_Action_To_Each_Item_And_Return_The_Collection()
        {
            // Arrange
            IEnumerable<User> initialCollection = new[] { new User(1, 2), new User(2, 5) };
            Action<User> action = u => u.Score *= 2;
            IEnumerable<User> expectedCollectionResult = new[] { new User(1, 4), new User(2, 10) };

            // Act
            IEnumerable<User> actualCollectionResult = initialCollection.ForEach(i => action(i));

            // Assert
            for (int i = 0; i < actualCollectionResult.Count(); i++)
            {
                Assert.Equal(expectedCollectionResult.ElementAt(i).Id, actualCollectionResult.ElementAt(i).Id);
                Assert.Equal(expectedCollectionResult.ElementAt(i).Score, actualCollectionResult.ElementAt(i).Score);
            }
        }
    }
}