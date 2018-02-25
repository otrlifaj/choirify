using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models.ManyToMany
{
    public class EventSong
    {
        [Key]
        public int Id { get; set; }

        public Song Song { get; set; }

        public Event Event { get; set; }

        public EventSong()
        {

        }
    }
}
