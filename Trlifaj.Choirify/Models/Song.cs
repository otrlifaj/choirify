using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models
{
    public class Song : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musíš zadat název skladby."), MaxLength(60, ErrorMessage ="Maximální délka názvu skladby je 60 znaků.")]
        [Column(TypeName = "varchar(60)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musíš zadat autora skladby."), MaxLength(100, ErrorMessage = "Maximální délka jména autora skladby je 100 znaků.")]
        [Column(TypeName = "varchar(100)")]
        public string Author { get; set; }

        public Boolean Current { get; set; }

        [MaxLength(200, ErrorMessage = "Maximální délka popisu je 200 znaků.")]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        public List<Link> Links { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

        public int SheetsAvailable { get; set; }

        [Column(TypeName = "varchar(20)")]
        public SheetType SheetType { get; set; } = SheetType.Unified;

        public Song()
        {
            Links = new List<Link>();
        }
    }
}
