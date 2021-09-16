using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words.Services
{
    public interface IWordService
    {
        public Task<List<string>> SolveAnagrams(string wordToSearch, bool includeOriginalWord);
        public Task<int> CountAnagrams(string searchString, string stringToBeSearched);
    }
}