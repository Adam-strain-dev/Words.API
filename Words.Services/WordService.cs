using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Words.Data.Entity;
using Words.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Words.Repository;


namespace Words.Services
{
    public class WordService: IWordService
    {
        private readonly IWordRepository _wordRepository;

        
        public WordService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }

        public async Task<List<string>> SolveAnagrams(string wordToCheck, bool includeOriginalWord)
        {
            List<string> results = new List<string>();

            try
            {
                //THIS GIVES US THE SEARCH WORD SPLIT INTO CHARACTERS AND SORTED
                string searchString = GetSortedCharsString(wordToCheck.ToCharArray());

                Dictionary<String, List<String>> map = new Dictionary<string, List<string>>();
                IEnumerable<Word> wordsList = await _wordRepository.GetAllAsync();
                Dictionary<string, char[]> wordDict = wordsList.Where(w => w.WordText.Length == wordToCheck.Length).ToDictionary(w => w.WordText, w => w.WordText.ToCharArray());
                foreach (KeyValuePair<string, char[]> wEnt in wordDict)
                {
                    Array.Sort(wEnt.Value);
                    string word = new string(wEnt.Value);
                    //check for matches here
                    if ((!includeOriginalWord && searchString.ToLower() == word.ToLower() && wEnt.Key.ToLower() != wordToCheck.ToLower()) || (includeOriginalWord && searchString.ToLower() == word.ToLower()))
                    {
                        results.Add(wEnt.Key);
                    }
                }
            }
            catch(Exception ex)
            {
                //TODO: HANDLE ERROR
                throw;
            }

            return results.OrderBy(r => r).ToList();
        }

        private string GetSortedCharsString(char[] wordToSort)
        {
            Array.Sort(wordToSort);
            return new string(wordToSort);
        }

        public async Task<int> CountAnagrams(string searchString, string stringToBeSearched) 
        {
            int countMatches = 0;

            try
            {
                //FIND ALL VARIATIONS OF STRING IN DB
                List<string> anagrams = await SolveAnagrams(searchString, true);
                //COUNT HOW MANY SUBSTRINGS ARE CONTAINED OF EACH VARIATION IN THE STRINGTOBESEARCHED
                if (anagrams.Count == 0)
                {
                    return 0;
                }
                var regexpBuilder = new StringBuilder();
                for (int i = 0; i < anagrams.Count; i++)
                {
                    regexpBuilder.Append($"({anagrams[i]})");
                    if (i != anagrams.Count - 1)
                    {
                        regexpBuilder.Append("|");
                    };
                };
                string regExpString = regexpBuilder.ToString();
                countMatches = Regex.Matches(stringToBeSearched, regExpString).Count;
            }
            catch(Exception ex)
            {
                //TODO: HANDLE ERROR
                throw;
            }
            
            return countMatches;
        }
    }
}
    