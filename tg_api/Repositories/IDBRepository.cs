using System.Collections.Generic;
using System.Threading.Tasks;
using tg_api.Models;

namespace tg_api.Repositories
{
    public interface IDBRepository
    {
        Task<List<string>> AllWords(string collectionName);
        void DeleteWordFromCollection(string word, string collectionName);
        void TakeWordToCollection(string  item, string collectionName);
    }
}