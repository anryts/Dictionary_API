 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using tg_api.Modes;
using tg_api.Cleints;
using System.Threading.Tasks;

namespace tg_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemContoller : ControllerBase
    {
        private readonly DictionaryClient _dictionaryClient;

        public ItemContoller(DictionaryClient dictionaryClient)
        {
            //this.repository = repository;
            _dictionaryClient = dictionaryClient;

        }


        [HttpGet("{word}")]
        public async Task<WordResponesForTG> GetWord(string word)
        {
            var tmp = await _dictionaryClient.GetWordByWord(word);
            
            //var t = (tmp.Select(word => word.phonetics.Where(x => x.audio !="")).FirstOrDefault());
            ////var t1 = tmp.Select(x => x.meanings);
            ////var t2 = t1.Select(x => x.Where(x => x.definitions != null));
            //var for_textSpech = tmp.Select(word => word.phonetics.Where(x => x.text != null)).FirstOrDefault();
            //var for_textphonectick = tmp.Select(word => word.meanings.Where(x => x.partOfSpeech != null)).FirstOrDefault();
            List<string> _synonyms = new();
            List<string[]> words = new();
            
            foreach (var part in tmp.meanings)
            {
                if (part.example != null)
                {
                    foreach (var definition in part.definitions)
                    {
                        words.Add(new string[2] { part.example, definition.definition });
                        
                        foreach(var syn in definition.synonyms)
                        {
                            _synonyms.Add(syn.ToString());
                        }
                    }
                }
               
            }



            var result = new WordResponesForTG
            {
                word = tmp.word,
                audio = tmp.phonetics.Select(x => x.audio).FirstOrDefault(),
                meanings = words,
                synonyms = _synonyms,
                text_phonetic = tmp.phonetics[1].text
            };
            //var result = new WordResponse()
            //{
            //    word = tmp.Select(word => word.word),
            //    phonetics = tmp.Select(word => word.phonetics.Where(x => x.audio != null )).FirstOrDefault(),
            //    meanings = tmp.Select(word => word.meanings.Where(x => x.definitions != null && x.synonyms!=null)).FirstOrDefault()

            //};

            return result;
            //return result;
        }


        //[HttpGet]
        //public IEnumerable<ItemDto> GetItems()
        //{
        //    var items = repository.GetItems().Select(item => item.AsDto());
        //    return items;
        //}

        [HttpGet]
        public async Task<List<List<Word>>> GetAllWords()
        {
            var result = await _dictionaryClient.AllWords();
            return result;
        }

        // POST /items
        [HttpPost("{word}")]
        //public async Task CreateItem(string word)
        //{
        //    var result = await _dictionaryClient.GetWordByWord(word);
            
        //    _dictionaryClient.TakeToWordCollection(result);
        //    return;
        //}

        //Put /items/{id}
        //[HttpPut("{id}")]
        //public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        //{
        //    var existingItem = repository.GetItem(id);
        //    if (existingItem is null)
        //        return NotFound();


        //    // ? witout using with
        //    existingItem.ItemDescription = itemDto.ItemDescription;

        //    repository.UpdateItem(existingItem);

        //    return NoContent();
        //}

        //delete /items/{id}
        [HttpDelete("{word}")]
        public async Task DeleteItem(string word)
        {
             _dictionaryClient.DeleteWordFromCollection(word);   
        }

    }
}
