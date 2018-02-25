﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models.ManyToMany
{
    public class EventAttendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Boolean Attended { get; set; }

        public ApplicationUser Singer { get; set; }

        public Event Event { get; set; }

        public EventAttendance()
        {

        }
    }
}
