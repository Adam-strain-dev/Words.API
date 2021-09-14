using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Words
{
    public interface IWordService
    {
        public List<string> SolveAnagrams(string wordToSearch, bool includeOriginalWord);
        public int CountAnagrams(string searchString, string stringToBeSearched);
    }
}