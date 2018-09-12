using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.ViewModels.SongViewModels
{
    public class SongListViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Musíš zadat název skladby."), MaxLength(60, ErrorMessage = "Maximální délka názvu skladby je 60 znaků.")]
        [Display(Name = "Název")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musíš zadat autora skladby."), MaxLength(100, ErrorMessage = "Maximální délka jména autora skladby je 100 znaků.")]
        [Display(Name = "Autor")]
        public string Author { get; set; }

        [Display(Name = "Aktuální")]
        public Boolean Current { get; set; }

        public SongListViewModel()
        {

        }

        public SongListViewModel(Song s)
        {
            Id = s.Id;
            Name = s.Name;
            Author = s.Author;
            Current = s.Current;
        }

        public Song ToSong()
        {
            return new Song
            {
                Id = Id,
                Name = Name,
                Author = Author,
                Current = Current,
            };
        }
    }
}
