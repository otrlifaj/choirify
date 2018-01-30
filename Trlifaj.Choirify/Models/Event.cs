using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadán název události."), MaxLength(100, ErrorMessage = "Název události může mít maximálně 100 znaků.")]
        [Display(Name = "Název")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Od")]
        [DataType(DataType.DateTime)]
        public DateTime From { get; set; }

        [Required]
        [Display(Name = "Do")]
        [DataType(DataType.DateTime)]
        public DateTime To { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadáno místo konání události."), MaxLength(150, ErrorMessage = "Místo konání může mít maximálně 150 znaků.")]
        [Display(Name = "Místo")]
        [Column(TypeName = "varchar(150)")]
        public string Place { get; set; }

        [Required(AllowEmptyStrings = true), MaxLength(150, ErrorMessage = "Popis události může mít maximálně 1000 znaků.")]
        [Display(Name = "Popis")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [MaxLength(1000, ErrorMessage = "Odkazy mohou mít maximálně 1000 znaků.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Odkazy")]
        [Column(TypeName = "varchar(1000)")]
        public string Links { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Url fotky")]
        [Column(TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Začátek přihlašování")]
        public DateTime StartOfRegistration { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Konec přihlašování")]
        public DateTime EndOfRegistration { get; set; }

        [Display(Name = "Program")]
        public List<Song> Programme { get; set; }
    }
}
