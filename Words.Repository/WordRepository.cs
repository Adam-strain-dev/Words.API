using System;
using System.Collections.Generic;
using Words.Data.Models;
using Words.Data.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Words.Repository
{
    public class WordRepository: IWordRepository
    {
        private readonly WordContext _wordContext;

        public WordRepository()
        {
            _wordContext = new WordContext();
        }

        public WordRepository(WordContext wordContext) 
        {
            _wordContext = wordContext;
        }

        public IEnumerable<Word> GetAll()
        {
            return _wordContext.Words.ToList();
        }

        public async Task<IEnumerable<Word>> GetAllAsync()
        {
            return await _wordContext.Words.ToListAsync();
        }

    }
}
