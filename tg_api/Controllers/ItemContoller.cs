 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using tg_api.Modes;
using tg_api.Cleints;
using System.Threading.Tasks;
using tg_api.DataManipulation;
using MongoDB.Driver;
using tg_api.Clients;

namespace tg_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemContoller : ControllerBase
    {
        private readonly DictionaryClient _dictionaryClient;
        private readonly IDictionaryClient repository;
        public Word tmp = new();
        List<Word> words = new List<Word>();
        public ItemContoller(DictionaryClient dictionaryClient, IDictionaryClient repository)
        {
            //this.words = words;
            _dictionaryClient = dictionaryClient;
            this.repository = repository;

        }


        [HttpGet("{word}")]
        public async Task<WordResponesForTG> GetWord(string word)
        {
            tmp = await _dictionaryClient.GetWordByWord(word);
            TransferFromWordToResponse transfer = new();
            return transfer.GetResponseFromWord(tmp);
        }


        [HttpGet("getExample{word}")]
        public async Task<string> GetExample(string word)
        {
           var result =  await _dictionaryClient.GetExampleByWord(word);
            getExamples examples = new();
            return examples.ReturnRandomExample(result);
        }

        [HttpGet("getCollection")]
        public async Task<List<Word>> GetAllWordsFromDB(string name_of_collection)
        {
            var result = await repository.AllWords(name_of_collection);
            return result;
        }

        // POST /items
        //[HttpPost("{word}")]
        //public async Task CreateItem(string word)
        //{
        //    var result = await _dictionaryClient.GetWordByWord(word);

        //    _dictionaryClient.TakeToWordCollection(result);
        //    return;
        //}

        //Put /items/{id
    
    [HttpPost("toCollection")]
    public  async Task PutWordToDB(string word, string name_of_collection)
    {
        var tmp = await _dictionaryClient.GetWordByWord(word);
            repository.TakeToWordCollection(tmp, name_of_collection);

    }

    //delete /items/{id}
    [HttpDelete("{word}")]
        public async Task DeleteItem(string word)
        {
            var tmp = await _dictionaryClient.GetWordByWord(word);
            repository.DeleteWordFromCollection(tmp);   
        }

    }
}
