using System;
using System.ComponentModel.DataAnnotations;
using DotNet.System.Extensions.Tests.Interfaces;
using DotNet.System.Extensions.Tests.Models;
using DotNet.System.Extensions.Tests.Models.BaseModels;
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void GetPropertyAttribute_Method_Should_Throw_ArgumentNullException_When_Property_Is_Null_Empty_Or_Consists_Of_White_Spaces(string property)
        {
            // Arrange
            Type userType = typeof(User);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => userType.GetPropertyAttribute<DisplayAttribute>(property));
        }

        [Fact]
        public void ImplementsInterface_Method_Should_Return_True_When_Interface_Is_Implemented()
        {
            // Arrange
            Type userType = typeof(User);

            // Act
            bool isInterfaceImplemented = userType.ImplementsInterface(typeof(IUser));

            // Assert
            Assert.True(isInterfaceImplemented);
        }

        [Fact]
        public void ImplementsInterface_Method_Should_Return_True_When_Base_Interface_Is_Implemented()
        {
            // Arrange
            Type userType = typeof(User);

            // Act
            bool isInterfaceImplemented = userType.ImplementsInterface<IEntity<int>>();

            // Assert
            Assert.True(isInterfaceImplemented);
        }

        [Fact]
        public void ImplementsInterface_Method_Should_Return_True_When_Interface_Is_Implemented_In_The_Base_Class()
        {
            // Arrange
            Type userType = typeof(ExtendedUser);

            // Act
            bool isInterfaceImplemented = userType.ImplementsInterface(typeof(IUser));

            // Assert
            Assert.True(isInterfaceImplemented);
        }

        [Fact]
        public void ImplementsInterface_Method_Should_Return_True_When_Base_Interface_Is_Implemented_In_The_Base_Class()
        {
            // Arrange
            Type userType = typeof(ExtendedUser);

            // Act
            bool isInterfaceImplemented = userType.ImplementsInterface<IEntity<int>>();

            // Assert
            Assert.True(isInterfaceImplemented);
        }

        [Fact]
        public void ImplementsInterface_Method_Should_Return_False_When_Interface_Is_Not_Implemented()
        {
            // Arrange
            Type userType = typeof(User);

            // Act
            bool isInterfaceImplemented = userType.ImplementsInterface(typeof(IDisposable));

            // Assert
            Assert.False(isInterfaceImplemented);
        }

        [Fact]
        public void ImplementsInterface_Method_Should_Throw_ArgumentNullException_When_Interface_Type_Is_Null()
        {
            // Arrange
            Type userType = typeof(User);

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => userType.ImplementsInterface(null));
        }

        [Fact]
        public void ImplementsInterface_Method_Should_Throw_ArgumentException_When_Interface_Type_Is_Not_Interface()
        {
            // Arrange
            Type userType = typeof(ExtendedUser);

            // Act

            // Assert
            Assert.Throws<ArgumentException>(() => userType.ImplementsInterface<UserBaseModel>());
        }
    }
}