using System.Collections.Generic;
using System.Threading.Tasks;
using tg_api.Modes;

namespace tg_api.Clients
{
    public interface IDictionaryClient
    {
        Task<Word> GetWordByWord(string word_t);
        Task<List<Word>> AllWords();
        void TakeToWordCollection(List<Word> item);
        void DeleteWordFromCollection(string word);
    }
}
