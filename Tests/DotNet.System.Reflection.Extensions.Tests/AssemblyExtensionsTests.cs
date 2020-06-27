using System.IO;
using System.Reflection;
using Xunit;

namespace DotNet.System.Reflection.Extensions.Tests
{
    public class AssemblyExtensionsTests
    {
        [Fact]
        public void GetAssemblyFolder_Method_Should_Read_File_From_The_Assembly_Directory()
        {
            // Arrange
            string filesFolder = "Files";
            string fileName = "Test.txt";
            string expectedFileContent = "This is a test file.";
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Act
            string assemblyDirectory = assembly.GetDirectory();

            string filePath = Path.Combine(assemblyDirectory, filesFolder, fileName);

            string fileContent = File.ReadAllText(filePath);

            // Assert
            Assert.Equal(expectedFileContent, fileContent);
        }
    }
}