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
            var t = (tmp.Select(word => word.phonetics.Where(x => x.audio !="")).FirstOrDefault());
            //var t1 = tmp.Select(x => x.meanings);
            //var t2 = t1.Select(x => x.Where(x => x.definitions != null));
            var for_textSpech = tmp.Select(word => word.phonetics.Where(x => x.text != null)).FirstOrDefault();
            var for_textphonectick = tmp.Select(word => word.meanings.Where(x => x.partOfSpeech != null)).FirstOrDefault();
            List<string> _synonyms = new();
           
            List<string[]> words = new();
            foreach (var m in tmp)
            {
                
                foreach(var n in m.meanings)
                {

                    
                    var part_Of_speech = n.partOfSpeech;
                    var example = n.example;
                    if (n.definitions != null)
                    {
                       
                       foreach (var definition in n.definitions)
                        {


                            words.Add(new string[] { part_Of_speech, definition.definition, example }); ;

                        }

                        //words.Add(smallwords);
                        foreach (var nt in n.synonyms)
                        {
                            if(nt != null)
                                _synonyms.Add(nt.ToString());
                        }
                    }
                   
                }
            }




            var result = new WordResponesForTG
            {
                word = tmp.Select(word => word.word).FirstOrDefault(),
                audio = t.Select(x => x.audio).FirstOrDefault(),
                meanings = words,
                synonyms = _synonyms,
                text_phonetic = for_textSpech.Select(x => x.text).FirstOrDefault(),
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
        public async Task CreateItem(string word)
        {
            var result = await _dictionaryClient.GetWordByWord(word);
            
            _dictionaryClient.TakeToWordCollection(result);
            return;
        }

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
