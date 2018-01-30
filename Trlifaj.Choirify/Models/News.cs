using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Vytvořeno")]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [Display(Name = "Aktuální")]
        public Boolean Current { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Chybí nadpis."), MaxLength(100, ErrorMessage = "Nadpis může mít maximálně 100 znaků.")]
        [Display(Name = "Nadpis")]
        [Column(TypeName = "varchar(100)")]
        public string Headline { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Chybí znění aktuality."), MaxLength(100, ErrorMessage = "Aktualita může mít maximálně 1500 znaků.")]
        [Display(Name = "Aktualita")]
        [Column(TypeName = "varchar(1500)")]
        [DataType(DataType.MultilineText)]
        public string Article { get; set; }

        [MaxLength(255, ErrorMessage = "Url fotky může mít maximálně 255 znaků.")]
        [Display(Name = "Url fotky")]
        [Column(TypeName = "varchar(255)")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public ApplicationUser Author { get; set; }

        public News()
        {
            Current = true;
            Created = DateTime.Now;
        }
    }
}
