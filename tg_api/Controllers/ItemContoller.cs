using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using tg_api.Cleints;
using System.Threading.Tasks;
using tg_api.DataManipulation;
using tg_api.Clients;
using tg_api.Models;

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


        //[HttpGet()]
        //public async Task<string> ()

        [HttpGet("audio")]
        public async Task<string> GetWord(string word)
        {
             var tmp = await _dictionaryClient.GetWordFromAPI(word);
            TransferFromWordToResponse transfer = new();
            return getPartsOfEntries.ReturnVoicePronunce(tmp);
        }


    //    [HttpGet("getExample{word}")]
    //    public async Task<string> GetExample(string word)
    //    {
    //       var result =  await _dictionaryClient.GetExampleByWord(word);
    //        getExamples examples = new();
    //        return examples.ReturnRandomExample(result);
    //    }

    //    [HttpGet("getCollection")]
    //    public async Task<List<Word>> GetAllWordsFromDB(string name_of_collection)
    //    {
    //        var result = await repository.AllWords(name_of_collection);
    //        return result;
    //    }

       
    
    //[HttpPost("toCollection")]
    //public  async Task PutWordToDB(string word, string name_of_collection)
    //{
    //    var tmp = await _dictionaryClient.GetWordFromAPI(word);
    //        repository.TakeToWordCollection(tmp, name_of_collection);

    //}

    ////delete /items/{id}
    //[HttpDelete("{word}")]
    //    public async Task DeleteItem(string word)
    //    {
    //        var tmp = await _dictionaryClient.GetWordFromAPI(word);
    //        repository.DeleteWordFromCollection(tmp);   
    //    }

    }
}
