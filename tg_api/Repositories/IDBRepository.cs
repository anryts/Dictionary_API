using System.Collections.Generic;
using System.Threading.Tasks;
using tg_api.Models;

namespace tg_api.Repositories
{
    public interface IDBRepository
    {
        Task<List<string>> GetAllWords(string collectionName);
        void DeleteWordFromCollection(string word, string collectionName);
        void PutWordToCollection(string item, string collectionName);
        void PutCollectionToCollection(List<string> collection, string collectionName);
    }
}