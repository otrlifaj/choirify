using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models
{
    public class News : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Vytvořeno")]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        [Display(Name = "Aktuální")]
        public Boolean Current { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Chybí nadpis."), MaxLength(200, ErrorMessage = "Nadpis může mít maximálně 200 znaků.")]
        [Display(Name = "Nadpis")]
        [Column(TypeName = "varchar(200)")]
        public string Headline { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Chybí znění aktuality."), MaxLength(10000, ErrorMessage = "Aktualita může mít maximálně 10000 znaků.")]
        [Display(Name = "Aktualita")]
        [Column(TypeName = "varchar(10000)")]
        [DataType(DataType.MultilineText)]
        public string Article { get; set; }

        [MaxLength(1000, ErrorMessage = "Url fotky může mít maximálně 1000 znaků.")]
        [Display(Name = "Url fotky")]
        [Column(TypeName = "varchar(1000)")]
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
