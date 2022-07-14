using System.Collections.Generic;
using System.Threading.Tasks;
using tg_api.Models;

namespace tg_api.Clients
{
    public interface IDictionaryClient
    {
        Task<RootOfEntries> GetWordFromAPI(string word);
        Task<RootOfSentences> GetExampleByWord(string word);

    }
}
