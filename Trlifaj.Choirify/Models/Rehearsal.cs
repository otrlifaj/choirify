﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models
{
    public class Rehearsal : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Chybí datum zkoušky.")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [MaxLength(3000, ErrorMessage = "Popis může mít maximálně 3000 znaků.")]
        [Column(TypeName = "varchar(3000)")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Rehearsal()
        {

        }
    }
}
