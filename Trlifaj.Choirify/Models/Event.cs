using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models
{
    public class Event : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadán název události."), MaxLength(100, ErrorMessage = "Název události může mít maximálně 100 znaků.")]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime To { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public EventType EventType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadáno místo konání události."), MaxLength(150, ErrorMessage = "Místo konání může mít maximálně 150 znaků.")]
        [Column(TypeName = "varchar(150)")]
        public string Place { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Musí být zadán nějaký popis události"), MaxLength(150, ErrorMessage = "Popis události může mít maximálně 1000 znaků.")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        public IEnumerable<Link> Links { get; set; }

        [DataType(DataType.ImageUrl)]
        [Column(TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartOfRegistration { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndOfRegistration { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Organizer { get; set; }


        public Event()
        {
            Links = new List<Link>();
        }
    }
}
