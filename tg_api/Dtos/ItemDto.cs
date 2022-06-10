using System;
using System.ComponentModel.DataAnnotations;

namespace tg_api.Dtos
{
    public record ItemDto
    {
        public Guid ID { get; init; }


        [Required]
        public string ItemDescription
        {
            get ; 
            set ;
        }

        }

    }

