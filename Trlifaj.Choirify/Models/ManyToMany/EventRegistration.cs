﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models.ManyToMany
{
    public class EventRegistration
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Musíš se vyjádřit k účasti.")]
        public Boolean Answer { get; set; }

        [MaxLength(255, ErrorMessage = "Maximální délka poznámky je 255 znaků.")]
        [Display(Name = "Poznámka")]
        [Column(TypeName = "varchar(255)")]
        public string Comment { get; set; }

        [Display(Name = "Šaty")]
        public DressOrderType? DressOrder { get; set; }


        public int? SingerId { get; set; }
        public Singer Singer { get; set; }

        public int? EventId { get; set; }
        public Event Event { get; set; }

        public EventRegistration()
        {

        }
    }
}
