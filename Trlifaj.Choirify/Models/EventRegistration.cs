using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models
{
    public class EventRegistration
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Musíš se vyjádřit k účasti.")]
        public Boolean IsPositive { get; set; }

        [MaxLength(255, ErrorMessage = "Maximální délka poznámky je 255 znaků.")]
        [Display(Name = "Poznámka")]
        [Column(TypeName = "varchar(255)")]
        public string Comment { get; set; }

        [Display(Name = "Šaty")]
        public DressOrderType? DressOrder { get; set; }

        public ApplicationUser Singer { get; set; }

        public Event Event { get; set; }

    }
}
