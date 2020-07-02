using PreliminaryTest.Service;
using System;
using System.Collections.Generic;
using Xunit;

namespace PreliminaryTest.Test
{
    public class StringProcessorServiceTests : IClassFixture<StringProcessorService>
    {
        private readonly StringProcessorService _stringProcessorService;

        public StringProcessorServiceTests(StringProcessorService stringProcessorService)
        {
            _stringProcessorService = stringProcessorService;
        }

        [Fact]
        public void ProcessStrings_Params_Should_Throw_NotImplementedException()
        {
            // Arrange 

            // Act 

            // Assert 
            Assert.Throws<NotImplementedException>(() => _stringProcessorService.ProcessStrings(""));
        }

        [Fact]
        public void ProcessStrings_List_Should_Throw_NotImplementedException()
        {
            // Arrange 
            var stringList = new List<string>();

            // Act 

            // Assert 
            Assert.Throws<NotImplementedException>(() => _stringProcessorService.ProcessStrings(stringList));
        }
    }
}
