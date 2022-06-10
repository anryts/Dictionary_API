using System;
using System.Collections.Generic;
using System.Linq;
using tg_api.Dtos;
using tg_api.Modes;

namespace tg_api.Repositories
{
    public class MemoryRepository : IMemoryRepository
    {
        public  List<Item> items = new List<Item>
        {
            new Item{ID = Guid.NewGuid(), ItemDescription = "test receipt" }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.ID == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
          
                 int index = items.FindIndex(existingItem =>existingItem.ID ==item.ID);
                 items[index] = item;       
        }

        public void DeleteItem(Guid id)
        {
            int index = items.FindIndex(existingItem => existingItem.ID == id);
            items.RemoveAt(index);
        }
    }
}
