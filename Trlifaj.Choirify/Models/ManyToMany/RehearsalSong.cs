using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.Models.ManyToMany
{
    public class RehearsalSong
    {
        [Key]
        public int? Id { get; set; }

        public int? SongId { get; set; }
        public Song Song { get; set; }

        public int? RehearsalId { get; set; }
        public Rehearsal Rehearsal { get; set; }

        public RehearsalSong()
        {

        }
    }
}
