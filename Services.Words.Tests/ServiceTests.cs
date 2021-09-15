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
                "spears"
            };
            
            Assert.Equal(correctResults.OrderBy(cr => cr), result.OrderBy(r => r));
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
                WordId = 1,
                Word = "asper"
            });
            words.Add(new WordChange()
            {
                WordId = 2,
                Word = "parse"
            });
            words.Add(new WordChange()
            {
                WordId = 1,
                Word = "pears"
            });
            words.Add(new WordChange()
            {
                WordId = 2,
                Word = "spear"
            });
            words.Add(new WordChange()
            {
                WordId = 1,
                Word = "test"
            });
            words.Add(new WordChange()
            {
                WordId = 2,
                Word = "sett"
            });

            return words;
        }
    }
}
