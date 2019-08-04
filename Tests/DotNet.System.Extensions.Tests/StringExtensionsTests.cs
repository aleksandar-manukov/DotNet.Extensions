using Xunit;

namespace DotNet.System.Extensions.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("thisIsAlreadyCamelCase", "thisIsAlreadyCamelCase")]
        [InlineData("AfterTheCallWillBeCamelCase", "afterTheCallWillBeCamelCase")]
        [InlineData("thisWordContainsDigits123", "thisWordContainsDigits123")]
        public void ToCamelCase_Method_Should_Convert_One_Word_String_To_Camel_Case(string text, string expectedResult)
        {
            // Act
            string actualResult = text.ToCamelCase();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("This is a sentence.", "thisIsASentence")]
        [InlineData("This is a longer sentence, containing comma in it.", "thisIsALongerSentenceContainingCommaInIt")]
        [InlineData(" - \"This is a direct speech.\" - author", "thisIsADirectSpeechAuthor")]
        [InlineData("Digits in the sentence are kept - 1, 2, 3 etc.", "digitsInTheSentenceAreKept123Etc")]
        public void ToCamelCase_Method_Should_Convert_One_Sentence_String_To_Camel_Case(string text, string expectedResult)
        {
            // Act
            string actualResult = text.ToCamelCase();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(@"This is the first paragraph.

                This is the second paragraph.", "thisIsTheFirstParagraphThisIsTheSecondParagraph")]
        [InlineData(@" - This is the first paragraph.

                 - This is the second paragraph, containing digits - 1, 2, 3 etc.", "thisIsTheFirstParagraphThisIsTheSecondParagraphContainingDigits123Etc")]
        public void ToCamelCase_Method_Should_Convert_One_Paragraph_String_To_Camel_Case(string text, string expectedResult)
        {
            // Act
            string actualResult = text.ToCamelCase();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}