using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.ViewModels
{
    public class LinkViewModel
    {
        public int Id { get; set; }
        public int LinkId { get; set; }

        [MaxLength(255, ErrorMessage = "Odkaz může mít maximálně 255 znaků.")]
        [DataType(DataType.Url)]
        [Display(Name = "Odkaz")]
        [Required(ErrorMessage = "Musíš zadat odkaz")]
        public string Url { get; set; }

        [MaxLength(100, ErrorMessage = "Popis odkazu může mít maximálně 100 znaků.")]
        [Display(Name = "Popis")]
        [Required(ErrorMessage = "Musíš zadat popisek")]
        public string Description { get; set; }

        public string Controller { get; set; }

        public string AddAction { get; set; }

        public string DeleteAction { get; set; }
    }
}
