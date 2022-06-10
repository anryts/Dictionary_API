 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using tg_api.Modes;
using tg_api.Repositories;
using tg_api.Dtos;
using tg_api.Cleints;
using System.Threading.Tasks;

namespace tg_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemContoller : ControllerBase
    {
        private readonly IMemoryRepository repository;
        private readonly DictionaryClient _dictionaryClient;

        public ItemContoller(IMemoryRepository repository, DictionaryClient dictionaryClient)
        {
            this.repository = repository;
            _dictionaryClient = dictionaryClient;

        }


        [HttpGet("{word}")]
        public async Task<List<Word>> GetWord(string word)
        {
            var result = await _dictionaryClient.GetWordByWord(word);
            //test
            //_dictionaryClient.TakeToWordCollection(result);
            return result;
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
