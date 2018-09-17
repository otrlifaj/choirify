using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;

namespace Trlifaj.Choirify.ViewModels.EventViewModels
{
    public class AdminEventListViewModel : EventListViewModel
    {
        public int ActiveSingers { get; set; }
        public int RegistrationsYes { get; set; }
        public int RegistrationsNo { get; set; }

        public int RegistrationsTotal
        {
            get
            {
                return RegistrationsYes + RegistrationsNo;
            }
        }

        public int WithoutAnswer
        {
            get
            {
                return ActiveSingers - RegistrationsTotal;
            }
        }

        public AdminEventListViewModel(Event e, int activeSingers, int registrationsYes, int registrationsNo) : base(e)
        {
            ActiveSingers = activeSingers;
            RegistrationsYes = registrationsYes;
            RegistrationsNo = registrationsNo;
        }
    }
}
