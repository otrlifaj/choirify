using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Helpers;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.SongViewModels
{
    public class SongDetailEditViewModel : SheetTypesViewModel
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

        [MaxLength(200, ErrorMessage = "Maximální délka popisu je 200 znaků.")]
        [Display(Name = "Popis")]
        public string Description { get; set; }

        [Display(Name = "Délka trvání")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:%m}m {0:%s}s")]
        public TimeSpan Duration { get; set; }

        [Display(Name = "Dostupných kopií")]
        public int SheetsAvailable { get; set; }

        [Display(Name = "Typ not")]
        public SheetType? SheetType { get; set; }

        [Display(Name = "Odkazy")]
        public List<Link> Links { get; set; }

        public SongDetailEditViewModel()
        {

        }

        public SongDetailEditViewModel(Song s)
        {
            Id = s.Id;
            Name = s.Name;
            Author = s.Author;
            Current = s.Current;
            Description = s.Description;
            Duration = s.Duration;
            SheetsAvailable = s.SheetsAvailable;
            SheetType = s.SheetType;
            Links = s.Links ?? new List<Link>();
        }

        public Song ToSong()
        {
            return new Song
            {
                Id = Id,
                Name = Name,
                Author = Author,
                Current = Current,
                Description = Description,
                Duration = Duration,
                SheetsAvailable = SheetsAvailable,
                SheetType = SheetType ?? Models.Enums.SheetType.Unified,
                Links = Links
            };
        }

        public string SheetTypeString
        {
            get
            {
                return EnumConverter.GetSheetTypeNameString(this.SheetType.Value);
            }
        }
    }
}
