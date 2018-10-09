using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.ViewModels.EventViewModels
{
    public class AdminEventListViewModel : EventListViewModel
    {

        public AdminEventListViewModel(Event e, int activeSingers, int registrationsYes, int registrationsNo) : base(e)
        {
            ActiveSingers = activeSingers;
            RegistrationsYes = registrationsYes;
            RegistrationsNo = registrationsNo;
        }
    }
}
