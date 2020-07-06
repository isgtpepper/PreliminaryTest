using PreliminaryTest.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PreliminaryTest.Test
{
    public class StringHelperServiceTest : IClassFixture<StringHelperService>
    {
        private readonly StringHelperService _stringHelperService;

        public StringHelperServiceTest(StringHelperService stringHelperService)
        {
            _stringHelperService = stringHelperService;
        }

        [Fact]
        public void ReplaceCharacters_Null_Params_Should_Not_Change_String()
        {
            // Arrange 
            var testString = "Test";
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.ReplaceCharacters(stringBuilder);

            // Assert 
            Assert.Equal(testString, stringBuilder.ToString());
        }

        [Fact]
        public void ReplaceCharacters_Params_Should_Replace_Characters()
        {
            // Arrange 
            var testString = "Test$&";
            var tuple1 = Tuple.Create("$", string.Empty);
            var tuple2 = Tuple.Create("&", "1");
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.ReplaceCharacters(stringBuilder, tuple1, tuple2);

            // Assert 
            Assert.Equal("Test1", stringBuilder.ToString());
        }

        [Fact]
        public void ReplaceCharacters_Enumerable_Should_Replace_Characters()
        {
            // Arrange 
            var testString = "Test$&";
            var tuple1 = Tuple.Create("$", string.Empty);
            var tuple2 = Tuple.Create("&", "1");
            var tupleList = new List<Tuple<string, string>>() { tuple1, tuple2 };
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.ReplaceCharacters(stringBuilder, tupleList);

            // Assert 
            Assert.Equal("Test1", stringBuilder.ToString());
        }

        [Fact]
        public void RemoveContiguousDuplicateCharacters_EmptyString_Should_Be_EmptyString()
        {
            // Arrange 
            var stringBuilder = new StringBuilder(string.Empty);

            // Act 
            _stringHelperService.RemoveContiguousDuplicateCharacters(stringBuilder);

            // Assert 
            Assert.Equal(string.Empty, stringBuilder.ToString());
        }

        [Fact]
        public void RemoveContiguousDuplicateCharacters_OneCharString_Should_Be_OneCharString()
        {
            // Arrange 
            var testString = "T";
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.RemoveContiguousDuplicateCharacters(stringBuilder);

            // Assert 
            Assert.Equal(testString, stringBuilder.ToString());
        }

        [Fact]
        public void RemoveContiguousDuplicateCharacters_WithoutDuplicateString_Should_Be_WithoutDuplicateString()
        {
            // Arrange 
            var testString = "Test";
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.RemoveContiguousDuplicateCharacters(stringBuilder);

            // Assert 
            Assert.Equal(testString, stringBuilder.ToString());
        }

        [Fact]
        public void RemoveContiguousDuplicateCharacters_DuplicateString_Should_Be_DuplicateString()
        {
            // Arrange 
            var testString = "TTTTeessst";
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.RemoveContiguousDuplicateCharacters(stringBuilder);

            // Assert 
            Assert.Equal("Test", stringBuilder.ToString());
        }

        [Fact]
        public void TruncateString_SmallString_Should_Not_Truncate()
        {
            // Arrange 
            var testString = "Test String";
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.TruncateString(stringBuilder, 20);

            // Assert 
            Assert.Equal(testString, stringBuilder.ToString());
        }

        [Fact]
        public void TruncateString_BigString_Should_Truncate()
        {
            // Arrange 
            var testString = "Test String";
            var stringBuilder = new StringBuilder(testString);

            // Act 
            _stringHelperService.TruncateString(stringBuilder, 4);

            // Assert 
            Assert.Equal("Test", stringBuilder.ToString());
        }
    }
}
