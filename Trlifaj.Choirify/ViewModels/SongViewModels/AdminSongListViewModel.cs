using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.ViewModels.SongViewModels
{
    public class AdminSongListViewModel : SongListViewModel
    {
        [Display(Name="Objednávky")]
        public int CountOfOrders { get; set; }

        public AdminSongListViewModel(Song s) : base(s)
        {

        }

        public AdminSongListViewModel(Song s, int countOfOrders) : this(s)
        {
            CountOfOrders = countOfOrders;
        }
    }
}
