using DotNet.System.Extensions.Tests.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace DotNet.System.Extensions.Tests
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void GetPropertyAttribute_Method_Should_Return_Property_Attribute_When_Property_Is_Decorated_With_It()
        {
            // Arrange
            Type userType = typeof(User);

            // Act
            DisplayAttribute propertyAttribute = userType.GetPropertyAttribute<DisplayAttribute>(nameof(User.FirstName));

            // Assert
            Assert.NotNull(propertyAttribute);
        }

        [Fact]
        public void GetPropertyAttribute_Method_Should_Return_Null_When_Property_Is_Not_Decorated_With_It()
        {
            // Arrange
            Type userType = typeof(User);

            // Act
            DisplayAttribute propertyAttribute = userType.GetPropertyAttribute<DisplayAttribute>(nameof(User.LastName));

            // Assert
            Assert.Null(propertyAttribute);
        }
    }
}