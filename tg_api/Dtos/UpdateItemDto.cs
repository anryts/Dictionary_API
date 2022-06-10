using System.ComponentModel.DataAnnotations;

namespace tg_api.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string ItemDescription
        {
            get;
            set;
        }
    }
}
