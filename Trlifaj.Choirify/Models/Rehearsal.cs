using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models
{
    public class Rehearsal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Chybí datum zkoušky.")]
        [Display(Name = "Datum")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [MaxLength(1500, ErrorMessage = "Popis může mít maximálně 1500 znaků.")]
        [Display(Name = "Popis")]
        [Column(TypeName = "varchar(1500)")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<ApplicationUser> SingersWhoAttended { get; set; }

        public Rehearsal()
        {
            SingersWhoAttended = new List<ApplicationUser>();
        }
    }
}
