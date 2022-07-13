using System.Collections.Generic;
using System.Threading.Tasks;
using tg_api.Models;

namespace tg_api.Clients
{
    public interface IDictionaryClient
    {
        Task<Word> GetWordFromAPI(string word_t);
        Task<List<Word>> AllWords(string collectionName);
        void TakeToWordCollection(Word word, string NameCollection);
        void DeleteWordFromCollection(Word word);
    }
}
