using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.EventViewModels
{
    public class AdminEventDetailSingerRegistrationViewModel
    {
        public int SingerId { get; set; }
        public int? RegistrationId { get; set; }
        public int EventId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public VoiceGroup Voice { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool? RegistrationPositive { get; set; }
        public string Comment { get; set; }

        public AdminEventDetailSingerRegistrationViewModel(int singerId, int? registrationId, int eventId, string firstName, string surname, VoiceGroup voice, DateTime? registrationDate, bool? registrationPositive, string comment)
        {
            SingerId = singerId;
            RegistrationId = registrationId;
            EventId = eventId;
            FirstName = firstName;
            Surname = surname;
            Voice = voice;
            RegistrationDate = registrationDate;
            RegistrationPositive = registrationPositive;
            Comment = comment;
        
        }
    }
}
