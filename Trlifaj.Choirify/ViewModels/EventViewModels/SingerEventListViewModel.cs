using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.ManyToMany;

namespace Trlifaj.Choirify.ViewModels.EventViewModels
{
    public class SingerEventListViewModel : EventListViewModel
    {
        public EventRegistrationViewModel Registration { get; set; }



        public SingerEventListViewModel() : base()
        {

        }

        public SingerEventListViewModel(Event @event) : base(@event)
        {

        }

        public SingerEventListViewModel(Event @event, EventRegistrationViewModel registration, int activeSingers, int registrationsYes, int registrationsNo) : this (@event)
        {
            Registration = registration;
            ActiveSingers = activeSingers;
            RegistrationsYes = registrationsYes;
            RegistrationsNo = registrationsNo;
        }
    }
}
