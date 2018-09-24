using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models.ManyToMany
{
    public class SingerSong
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public SheetInfoType Status { get; set; }

        public int? SongId { get; set; }
        public Song Song { get; set; }

        public int? SingerId { get; set; }
        public Singer Singer { get; set; }

        public SingerSong()
        {

        }
    }
}
