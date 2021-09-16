using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Words.Services;

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
        public async Task<List<string>> getAnagrams(String wordToCheck)
        {
            return await _wordService.SolveAnagrams(wordToCheck, false);
        }

        [HttpGet]
        [Route("getAnagramSubstringCount/{searchString}/{stringToBeSearched}")]
        public async Task<int> getAnagramSubstrings(string searchString, string stringToBeSearched)
        {
            return await _wordService.CountAnagrams(searchString, stringToBeSearched);
        }

    }
}
