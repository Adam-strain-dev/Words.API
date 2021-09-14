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
        public List<String> getAnagrams(String wordToCheck)
        {
            try
            {
                return _wordService.SolveAnagrams(wordToCheck, false);
            }
            catch(Exception ex)
            {
                //TODO: ADD REAL EXCEPTION HANDLING
                throw ex;
            }
        }

        [HttpGet]
        [Route("getAnagramSubstringCount/{searchString}/{stringToBeSearched}")]
        public int getAnagramSubstrings(string searchString, string stringToBeSearched)
        {
            try
            {
                return _wordService.CountAnagrams(searchString, stringToBeSearched);
            }
            catch(Exception ex)
            {
                //TODO: ADD REAL EXCEPTION HANDLING
                throw ex;
            }
        }

    }
}
