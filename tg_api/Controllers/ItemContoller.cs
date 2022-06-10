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
        public async Task<Word> GetWord()
        {
            var result = await _dictionaryClient.GetWordByWord("hello");
            return result;
        }


        //[HttpGet]
        //public IEnumerable<ItemDto> GetItems()
        //{
        //    var items = repository.GetItems().Select(item => item.AsDto());
        //    return items;
        //}

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            return repository.GetItem(id) is null ? NotFound() : repository.GetItem(id).AsDto();
        }

        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new Item()
            {
                ID = Guid.NewGuid(),
                ItemDescription = itemDto.ItemDescription
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.ID }, item.AsDto());
        }

        //Put /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
                return NotFound();


            // ? witout using with
            existingItem.ItemDescription = itemDto.ItemDescription;

            repository.UpdateItem(existingItem);

            return NoContent();
        }

        //delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem is null)
                return NotFound();
            repository.DeleteItem(id);
            return NoContent();
        }

    }
}
