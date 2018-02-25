using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.ViewModels.UserViewModels
{
    public class UserDetailViewModel : CountriesAndVoiceGroupsViewModel
    {
        public ApplicationUser User { get; set; }
    }
}
