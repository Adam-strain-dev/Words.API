using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Services.Words;

namespace API.Words.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController
    {
        private readonly IWordService _wordService;
        public WordsController(IWordService wordService)
        {
            _wordService = wordService;
        }

        [HttpGet]
        [Route("getAnagrams/{wordToCheck}")]
        public async Task<List<String>> getAnagrams(String wordToCheck)
        {
            try
            {
                return await _wordService.SolveAnagrams(wordToCheck, false);
            }
            catch(Exception ex)
            {
                //TODO: ADD REAL EXCEPTION HANDLING
                throw;
            }
        }

        [HttpGet]
        [Route("getAnagramSubstringCount/{searchString}/{stringToBeSearched}")]
        public async Task<int> getAnagramSubstrings(string searchString, string stringToBeSearched)
        {
            try
            {
                return await _wordService.CountAnagrams(searchString, stringToBeSearched);
            }
            catch(Exception ex)
            {
                //TODO: ADD REAL EXCEPTION HANDLING
                throw;
            }
        }

    }
}
