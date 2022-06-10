using tg_api.Dtos;
using tg_api.Modes;

namespace tg_api
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                ID = item.ID,
                ItemDescription = item.ItemDescription
            };
        }
    }
}
