using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.SongViewModels
{
    public class SingerSongListViewModel : SongListViewModel
    {
        [Display(Name = "Noty")]
        public SheetInfoType? SheetInfo { get; set; }

        public int SingerId { get; set; }

        public SingerSongListViewModel(Song s) : base(s)
        {

        }

        public SingerSongListViewModel(Song s, SheetInfoType? sheetInfo, int singerId) : this(s)
        {
            SheetInfo = sheetInfo;
            SingerId = singerId;
        }
    }
}
