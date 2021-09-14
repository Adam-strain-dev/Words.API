﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Data.Words.Entity;

namespace Services.Words
{
    public class WordService: IWordService
    {
        private readonly WordContext _wordContext;

        public WordService(WordContext wordContext)
        {
            _wordContext = wordContext;
        }

        public List<string> SolveAnagrams(string wordToCheck, bool includeOriginalWord)
        {
            //THIS GIVES US THE SEARCH WORD SPLIT INTO CHARACTERS AND SORTED
            string searchString = GetSortedCharsString(wordToCheck.ToCharArray());
            
            Dictionary<String, List<String>> map = new Dictionary<string, List<string>>();
            List<string> results = new List<string>();
            Dictionary<string, char[]> wordDict = _wordContext.WordChanges.Where(w => w.Word.Length == wordToCheck.Length).ToDictionary(w => w.Word, w => w.Word.ToCharArray());
            
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

            return results.OrderBy(r => r).ToList();
        }

        private string GetSortedCharsString(char[] wordToSort)
        {
            Array.Sort(wordToSort);
            return new string(wordToSort);
        }

        public int CountAnagrams(string searchString, string stringToBeSearched) 
        {
            //FIND ALL VARIATIONS OF STRING IN DB
            List<string> anagrams = SolveAnagrams(searchString, true);
            //COUNT HOW MANY SUBSTRINGS ARE CONTAINED OF EACH VARIATION ON THE STRINGTOBESEARCHED
            var regexpBuilder = new StringBuilder();
            for(int i = 0; i < anagrams.Count; i++)
            {
                regexpBuilder.Append($"({anagrams[i]})");
                if(i != anagrams.Count - 1)
                {
                    regexpBuilder.Append("|");
                };
            };
            string regExpString = regexpBuilder.ToString();

            int countMatches1 = Regex.Matches(stringToBeSearched, regExpString).Count;
            return countMatches1;
        }
    }
}