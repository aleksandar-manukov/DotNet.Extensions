﻿using DotNet.System.Extensions.Tests.Models;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace DotNet.System.Extensions.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void GetPropertyAttribute_Method_Should_Return_Property_Attribute_When_Property_Is_Decorated_With_It()
        {
            // Arrange
            User user = new User();

            // Act
            DisplayAttribute propertyAttribute = user.GetPropertyAttribute<User, DisplayAttribute>(u => u.FirstName);

            // Assert
            Assert.NotNull(propertyAttribute);
        }

        [Fact]
        public void GetPropertyAttribute_Method_Should_Return_Null_When_Property_Is_Not_Decorated_With_It()
        {
            // Arrange
            User user = new User();

            // Act
            DisplayAttribute propertyAttribute = user.GetPropertyAttribute<User, DisplayAttribute>(u => u.LastName);

            // Assert
            Assert.Null(propertyAttribute);
        }
    }
}