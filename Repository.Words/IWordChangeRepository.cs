using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Words.Models;

namespace Repository.Words
{
    public interface IWordChangeRepository
    {
        public IEnumerable<WordChange> GetAll();
        public Task<IEnumerable<WordChange>> GetAllAsync();
    }
}