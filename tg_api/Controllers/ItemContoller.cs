using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tg_api.Clients;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using tg_api.DataManipulation;
using tg_api.Repositories;

namespace tg_api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    [Authorize]
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
            return getPartsOfEntries.ReturnVoicePronunce(tmp);
        }

        [HttpGet("translate"), AllowAnonymous]
        public async Task<string> GetTranslation(string sentence, string origin_lang, string target_lang)
        {
            return GoogleTranslate.GoogleTranslate.TranslateSentence(sentence, origin_lang, target_lang);
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
            var result = await _repository.GetAllWords(name_of_collection);
            return result;
        }

        [HttpPost("toCollectionSingleWord")]
        public async Task PutWordToDB(string word, string name_of_collection)
        {
            _repository.PutWordToCollection(word, name_of_collection);
        }

        [HttpPost("toCollectionAnotherCollection")]
        public async Task PutCollectionToDB (List<string> collection, string name_of_collection)
        {
            _repository.PutCollectionToCollection(collection, name_of_collection);
        }

        [HttpDelete("deleteFromCollection")]
        public async Task DeleteItem(string word, string name_of_collection)
        {
            var tmp = await _dictionaryClient.GetWordFromAPI(word);
            _repository.DeleteWordFromCollection(word, name_of_collection);
        }

    }
}
