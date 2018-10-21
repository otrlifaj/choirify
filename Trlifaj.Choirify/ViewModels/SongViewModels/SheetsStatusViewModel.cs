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
    public class SheetsStatusViewModel
    {
        public int SongId { get; set; }
        public bool Current { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SheetsAvailable { get; set; }
        public int MissingCopies
        {
            get
            {
                var missingCopies = SingersWhoOrderedCopy.Count - SheetsAvailable;
                if (missingCopies < 0)
                {
                    return 0;
                }
                else
                {
                    return missingCopies;
                }
            }
        }
        public List<SingerInfoViewModel> SingersWhoHaveCopy { get; set; }
        public List<SingerInfoViewModel> SingersWhoDontHaveCopy { get; set; }
        public List<SingerInfoViewModel> SingersWhoOrderedCopy { get; set; }
        [Display(Name = "Odkazy")]
        public List<Link> Links { get; set; }

        public SheetsStatusViewModel(Song song, List<SingerInfoViewModel> Ordered, List<SingerInfoViewModel> HaveCopy, List<SingerInfoViewModel> NoCopy)
        {
            SongId = song.Id;
            Current = song.Current;
            Author = song.Author;
            Name = song.Name;
            Description = song.Description;
            SheetsAvailable = song.SheetsAvailable;
            SingersWhoOrderedCopy = Ordered;
            SingersWhoHaveCopy = HaveCopy;
            SingersWhoDontHaveCopy = NoCopy;
            Links = song.Links;
        }
    }

    public class SingerInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Display(Name = "Příjmení")]
        public string Surname { get; set; }
        [Display(Name = "Hlas")]
        public VoiceGroup Voice { get; set; }

        public string VoiceString
        {
            get
            {
                return Voice.ToString();
            }
        }
        public string TableFormat
        {
            get
            {
                return $"{FirstName} {Surname} ({VoiceString})";
            }
        }

        public SheetInfoType Status { get; set; }

        public Boolean SelectedForAction { get; set; }

        public SingerInfoViewModel(int id, string firstName, string surname, VoiceGroup? voice, SheetInfoType status)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Voice = voice.Value;
            Status = status;
            SelectedForAction = false;
        }

        public SingerInfoViewModel()
        {

        }
    }
}
