using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musíš zadat název skladby."), MaxLength(60, ErrorMessage ="Maximální délka názvu skladby je 60 znaků.")]
        [Display(Name = "Název")]
        [Column(TypeName = "varchar(60)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musíš zadat autora skladby."), MaxLength(100, ErrorMessage = "Maximální délka jména autora skladby je 100 znaků.")]
        [Display(Name = "Autor")]
        [Column(TypeName = "varchar(100)")]
        public string Author { get; set; }
        
        [MaxLength(200, ErrorMessage = "Maximální délka popisu je 200 znaků.")]
        [Display(Name = "Popis")]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        [MaxLength(1000, ErrorMessage = "Odkazy mohou mít maximálně 1000 znaků.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Odkazy")]
        [Column(TypeName = "varchar(1000)")]
        public string Links { get; set; }

        [Display(Name = "Délka trvání")]
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

        [Display(Name = "Dostupných kopií")]
        public int SheetsAvailable { get; set; }

    }
}
