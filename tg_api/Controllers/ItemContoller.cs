using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tg_api.Clients;
using System.Threading.Tasks;
using tg_api.DataManipulation;
using tg_api.Models;
using tg_api.Repositories;

namespace tg_api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ItemContoller : ControllerBase
    {
        private readonly IDictionaryClient _dictionaryClient;
        private readonly IDBRepository _repository;
        public Word tmp = new();
        public ItemContoller(IDictionaryClient dictionaryClient, IDBRepository repository)
        {
            _dictionaryClient = dictionaryClient;
            _repository = repository;
        }


        
        [HttpGet("audio")]
        public async Task<string> GetWord(string word)
        {
           var tmp = await _dictionaryClient.GetWordFromAPI(word);
            return getPartsOfEntries.ReturnVoicePronunce(tmp);
        }


        [HttpGet("shortDefinition")]
        public async Task<List<string>> GetSimpleDefinition(string word)
        {
            var tmp = await _dictionaryClient.GetWordFromAPI(word);
            return getPartsOfEntries.ReturnDefinitionWithPronunciation(tmp);
        }

        [HttpGet("synonym")]
        public async Task<string> GetSynonym(string word)
        {
            var result = await _dictionaryClient.GetWordFromAPI(word);
            return getPartsOfEntries.RandomSynonym(result);
        }

        [HttpGet("example")]
        public async Task<string> GetExample(string word)
        {
            var result = await _dictionaryClient.GetExampleByWord(word);
            return getPartsOfEntries.ReturnRandomExample(result);
        }

        

        [HttpGet("getCollection")]
        public async Task<List<string>> GetAllWordsFromDB(string name_of_collection)
        {
            var result = await _repository.AllWords(name_of_collection);
            return result;
        }

        [HttpPost("toCollection")]
        public async Task PutWordToDB(string word, string name_of_collection)
        {
            _repository.TakeWordToCollection(word, name_of_collection);
        }

        [HttpDelete("deleteFromCollection")]
        public async Task DeleteItem(string word, string name_of_collection)
        {
            var tmp = await _dictionaryClient.GetWordFromAPI(word);
            _repository.DeleteWordFromCollection(word, name_of_collection);
        }

    }
}
