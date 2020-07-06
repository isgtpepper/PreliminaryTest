using PreliminaryTest.Test.Fixture;
using System.Collections.Generic;
using Xunit;

namespace PreliminaryTest.Test
{
    public class StringProcessorServiceTests : IClassFixture<StringProcessorServiceFixture>
    {
        private readonly StringProcessorServiceFixture _stringProcessorServiceFixture;

        public StringProcessorServiceTests(StringProcessorServiceFixture stringProcessorServiceFixture)
        {
            _stringProcessorServiceFixture = stringProcessorServiceFixture;
        }

        /// <summary>
        /// The returned collection must not be null
        /// </summary>
        [Fact]
        public void ProcessStrings_Null_Params_Should_Return_Not_Null_Collection()
        {
            // Arrange 
            var stringProcessorService = _stringProcessorServiceFixture.StringProcessorService;

            // Act 
            var resultList = stringProcessorService.ProcessStrings();

            // Assert
            Assert.NotNull(resultList);
            Assert.Equal(0, resultList.Count);
        }

        /// <summary>
        /// The returned collection must not be null
        /// </summary>
        [Fact]
        public void ProcessStrings_Empty_List_Should_Return_Not_Null_Collection()
        {
            // Arrange 
            var stringProcessorService = _stringProcessorServiceFixture.StringProcessorService;

            // Act 
            var resultList = stringProcessorService.ProcessStrings(new List<string>());

            // Assert
            Assert.NotNull(resultList);
            Assert.Equal(0, resultList.Count);
        }

        /// <summary>
        /// Output strings must not be null or empty string
        /// </summary>
        [Fact]
        public void ProcessStrings_Empty_String_Should_Return_Not_Null_String()
        {
            // Arrange 
            var stringProcessorService = _stringProcessorServiceFixture.StringProcessorService;

            // Act 
            var resultList = stringProcessorService.ProcessStrings(new List<string>() { string.Empty });

            // Assert
            Assert.NotNull(resultList);
            Assert.Equal(1, resultList.Count);
            Assert.NotEqual(string.Empty, resultList[0]);
        }

        /// <summary>
        /// Should be truncated to max length of 15 chars
        /// </summary>
        [Fact]
        public void ProcessStrings_Long_String_Should_Return_Trancated_String()
        {

            // Arrange 
            var stringProcessorService = _stringProcessorServiceFixture.StringProcessorService;

            // Act 
            var resultList = stringProcessorService.ProcessStrings(new List<string>() {
                "qweasdzxcqweasdzxc"
            });

            // Assert
            Assert.NotNull(resultList);
            Assert.Equal(1, resultList.Count);
            Assert.Equal(15, resultList[0].Length);
        }

        /// <summary>
        /// Contiguous duplicate characters in the same case should  be reduced to a single character in the same case
        /// </summary>
        [Fact]
        public void ProcessStrings_Duplicated_String_Should_Return_String_With_No_Dublications()
        {
            // Arrange 
            var stringProcessorService = _stringProcessorServiceFixture.StringProcessorService;

            // Act 
            var resultList = stringProcessorService.ProcessStrings(new List<string>() {
                "QQQqqqqq5555"
            });

            // Assert
            Assert.NotNull(resultList);
            Assert.Equal(1, resultList.Count);
            Assert.Equal("Qq5", resultList[0]);
        }

        /// <summary>
        /// Dollar sign ($) should be replaced with a pound sign (£)
        /// and underscores (_) and number 4 should be removed
        /// </summary>
        [Fact]
        public void ProcessStrings_Should_Delete_Forbidden_Chars()
        {
            // Arrange 
            var stringProcessorService = _stringProcessorServiceFixture.StringProcessorService;

            // Act 
            var resultList = stringProcessorService.ProcessStrings(new List<string>() {
                "$$QQQ___qqqqq5555444"
            });

            // Assert
            Assert.NotNull(resultList);
            Assert.Equal(1, resultList.Count);
            Assert.Equal("£Qq5", resultList[0]);
        }

        [Fact]
        public void ProcessStrings_Should_Process_SeceralStrings()
        {
            // Arrange 
            var stringProcessorService = _stringProcessorServiceFixture.StringProcessorService;

            // Act 
            var resultList = stringProcessorService.ProcessStrings(new List<string>() {
                "$$QQQ___qqqqq5555444",
                "AAAc91%cWwWkLq$1ci3_848v3d__K"
            });

            // Assert
            Assert.NotNull(resultList);
            Assert.Equal(2, resultList.Count);
            Assert.Equal("£Qq5", resultList[0]);
            Assert.Equal("Ac91%cWwWkLq£1c", resultList[1]);
        }
    }
}
