using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models.ManyToMany
{
    public class RehearsalAttendance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Účast")]
        public Boolean Attended { get; set; }

        public Singer Singer { get; set; }

        public Rehearsal Rehearsal { get; set; }

        public RehearsalAttendance()
        {
            Attended = false;
        }
    }
}
