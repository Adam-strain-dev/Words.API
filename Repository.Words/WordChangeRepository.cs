using System;
using System.Collections.Generic;
using Data.Words.Models;
using Data.Words.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository.Words
{
    public class WordChangeRepository: IWordChangeRepository
    {
        private readonly WordContext _wordContext;

        public WordChangeRepository()
        {
            _wordContext = new WordContext();
        }

        public WordChangeRepository(WordContext wordContext) 
        {
            _wordContext = wordContext;
        }

        public IEnumerable<WordChange> GetAll()
        {
            return _wordContext.WordChanges.ToList();
        }

        public async Task<IEnumerable<WordChange>> GetAllAsync()
        {
            return await _wordContext.WordChanges.ToListAsync();
        }

    }
}
