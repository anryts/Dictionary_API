using System;
using System.Collections.Generic;
using tg_api.Modes;

namespace tg_api.Repositories
{
    public interface IMemoryRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();

        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}