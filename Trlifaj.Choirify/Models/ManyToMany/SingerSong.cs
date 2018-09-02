using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models.ManyToMany
{
    public class SingerSong
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Stav")]
        [EnumDataType(typeof(SheetInfoType))]
        public SheetInfoType Status { get; set; }

        public Song Song { get; set; }

        public Singer Singer { get; set; }

        public SingerSong()
        {

        }
    }
}
