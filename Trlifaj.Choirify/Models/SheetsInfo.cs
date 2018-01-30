using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models
{
    public class SheetsInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Stav")]
        [EnumDataType(typeof(SheetInfoType))]
        public SheetInfoType Status { get; set; }

        public Song Song { get; set; }

        public ApplicationUser Singer { get; set; }
    }
}
