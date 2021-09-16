using System.Collections.Generic;
using System.Threading.Tasks;
using Words.Data.Models;

namespace Words.Repository
{
    public interface IWordRepository
    {
        public IEnumerable<Word> GetAll();
        public Task<IEnumerable<Word>> GetAllAsync();
    }
}