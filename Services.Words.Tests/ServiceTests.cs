using Data.Words.Models;
using Moq;
using Repository.Words;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Services.Words.Tests
{
    public class ServiceTests
    {
        [Fact]
        public async Task SolveAnagramsReturnsCorrectNumberAnagrams()
        {
            //STEP 1 ARRANGE
            var mockRepo = new Mock<IWordChangeRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetTestWords());
            var service = new WordService(mockRepo.Object);
            //STEP 2 ACT
            var result = await service.SolveAnagrams("aeprs", false);
            //STEP 3 ASSERT
            var typeResult = Assert.IsType<List<string>>(result);
            List<string> correctResults = new List<string>()
            {
                "apers",
                "apres",
                "asper",
                "parse",
                "pears",
                "spear"
            };
            
            Assert.Equal(correctResults.OrderBy(cr => cr), result.OrderBy(r => r));
        }

        [Fact]
        public async Task GetAnagramInstancesFromString()
        {
            //STEP 1 ARRANGE
            var mockRepo = new Mock<IWordChangeRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetTestWords());
            var service = new WordService(mockRepo.Object);
            //STEP 2 ACT
            var result = await service.CountAnagrams("dog", "godisadoggeddog");
            //STEP 3 ASSERT
            var typeResult = Assert.IsType<int>(result);
            Assert.Equal(3, result);
        }

        private List<WordChange> GetTestWords()
        {
            var words = new List<WordChange>();
            words.Add(new WordChange()
            {
                WordId = 1,
                Word = "apers"
            });
            words.Add(new WordChange()
            {
                WordId = 2,
                Word = "apres"
            });
            words.Add(new WordChange()
            {
                WordId = 3,
                Word = "asper"
            });
            words.Add(new WordChange()
            {
                WordId = 4,
                Word = "parse"
            });
            words.Add(new WordChange()
            {
                WordId = 5,
                Word = "pears"
            });
            words.Add(new WordChange()
            {
                WordId = 6,
                Word = "spear"
            });
            words.Add(new WordChange()
            {
                WordId = 7,
                Word = "test"
            });
            words.Add(new WordChange()
            {
                WordId = 8,
                Word = "sett"
            });
            words.Add(new WordChange()
            {
                WordId = 9,
                Word = "god"
            });
            words.Add(new WordChange()
            {
                WordId = 10,
                Word = "dog"
            });

            return words;
        }
    }
}
