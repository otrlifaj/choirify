using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models
{
    public class Link : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1000, ErrorMessage = "Odkaz může mít maximálně 1000 znaků.")]
        [Column(TypeName = "varchar(1000)")]
        public string Url { get; set; }

        [MaxLength(100, ErrorMessage = "Popis odkazu může mít maximálně 100 znaků.")]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.Url)]
        public string Description { get; set; }
    }
}
