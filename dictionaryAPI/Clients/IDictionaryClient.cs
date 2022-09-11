using System.Collections.Generic;
using System.Threading.Tasks;
using dictionaryAPI.Models;

namespace dictionaryAPI.Clients
{
    public interface IDictionaryClient
    {
        Task<RootOfEntries> GetWordFromAPI(string word);
        Task<RootOfSentences> GetExampleByWord(string word);

    }
}
