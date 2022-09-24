using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using dictionaryAPI.Clients;
using dictionaryAPI.DataManipulation;
using dictionaryAPI.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace dictionaryAPI.Controllers
{
    [Route("api/v1")]
    [ApiController]
    //[Authorize]
    public class ItemContoller : ControllerBase
    {
        private readonly IDictionaryClient _dictionaryClient;
        private readonly IDBRepository _repository;
        public ItemContoller(IDictionaryClient dictionaryClient, IDBRepository repository)
        {
            _dictionaryClient = dictionaryClient;
            _repository = repository;
        }
        
        [HttpGet("audio")]
        public async Task<string> GetWord(string word)
        {
            var tmp = await _dictionaryClient.GetWordFromAPI(word);
            return GetPartsOfEntries.ReturnVoicePronunce(tmp);
        }

        [HttpGet("translate"), AllowAnonymous]
        public Task<string> GetTranslation(string sentence, string originLang, string targetLang)
        {
            return  Task.FromResult(GoogleTranslate.GoogleTranslate.TranslateSentence(sentence, originLang, targetLang));
        }
        

        [HttpGet("shortDefinition")]
        public async Task<List<string>> GetSimpleDefinition(string word)
        {
            var tmp = await _dictionaryClient.GetWordFromAPI(word);
            return GetPartsOfEntries.ReturnDefinitionWithPronunciation(tmp);
        }

        [HttpGet("synonym")]
        public async Task<string> GetSynonym(string word)
        {
            var result = await _dictionaryClient.GetWordFromAPI(word);
            return GetPartsOfEntries.RandomSynonym(result);
        }

        [HttpGet("example")]
        public async Task<string> GetExample(string word)
        {
            var result = await _dictionaryClient.GetExampleByWord(word);
            return GetPartsOfEntries.ReturnRandomExample(result);
        }

        

        [HttpGet("getCollection")]
        public async Task<List<string>> GetAllWordsFromDb(string nameOfCollection)
        {
            var result = await _repository.GetAllWords(nameOfCollection);
            return result;
        }

        [HttpPost("toCollectionSingleWord")]
        public Task PutWordToDb(string word, string nameOfCollection)
        {
            _repository.PutWordToCollection(word, nameOfCollection);
            return Task.CompletedTask;
        }

        [HttpPost("toCollectionAnotherCollection")]
        public Task PutCollectionToDb (List<string> collection, string nameOfCollection)
        {
            _repository.PutCollectionToCollection(collection, nameOfCollection);
            return Task.CompletedTask;
        }

        [HttpDelete("deleteFromCollection")]
        public async Task DeleteItem(string word, string nameOfCollection)
        {
            //need to do something with this
            //var tmp = await _dictionaryClient.GetWordFromAPI(word);
            _repository.DeleteWordFromCollection(word, nameOfCollection);
        }

    }
}
