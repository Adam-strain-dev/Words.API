using Words.Data.Models;
using Moq;
using Words.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Words.Services.Tests
{
    public class ServiceTests
    {
        [Fact]
        public async Task SolveAnagramsReturnsCorrectNumberAnagrams()
        {
            //STEP 1 ARRANGE
            var mockRepo = new Mock<IWordRepository>();
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
            var mockRepo = new Mock<IWordRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(GetTestWords());
            var service = new WordService(mockRepo.Object);
            //STEP 2 ACT
            var result = await service.CountAnagrams("dog", "godisadoggeddog");
            //STEP 3 ASSERT
            var typeResult = Assert.IsType<int>(result);
            Assert.Equal(3, result);
        }

        private List<Word> GetTestWords()
        {
            var words = new List<Word>();
            words.Add(new Word()
            {
                WordId = 1,
                WordText = "apers"
            });
            words.Add(new Word()
            {
                WordId = 2,
                WordText = "apres"
            });
            words.Add(new Word()
            {
                WordId = 3,
                WordText = "asper"
            });
            words.Add(new Word()
            {
                WordId = 4,
                WordText = "parse"
            });
            words.Add(new Word()
            {
                WordId = 5,
                WordText = "pears"
            });
            words.Add(new Word()
            {
                WordId = 6,
                WordText = "spear"
            });
            words.Add(new Word()
            {
                WordId = 7,
                WordText = "test"
            });
            words.Add(new Word()
            {
                WordId = 8,
                WordText = "sett"
            });
            words.Add(new Word()
            {
                WordId = 9,
                WordText = "god"
            });
            words.Add(new Word()
            {
                WordId = 10,
                WordText = "dog"
            });

            return words;
        }
    }
}
