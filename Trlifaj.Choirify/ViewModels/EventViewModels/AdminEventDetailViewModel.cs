using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Helpers;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.EventViewModels
{
    public class AdminEventDetailViewModel : EventDetailEditViewModel
    {
        public List<AdminEventDetailSingerRegistrationViewModel> Registrations { get; set; }

        public List<AdminEventDetailSingerRegistrationViewModel> WithoutAnswer { get; set; }

        public int S1Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.S1 && r.RegistrationPositive == true);
            }
        }

        public int S2Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.S2 && r.RegistrationPositive == true);
            }
        }

        public int A1Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.A1 && r.RegistrationPositive == true);
            }
        }

        public int A2Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.A2 && r.RegistrationPositive == true);
            }
        }

        public int T1Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.T1 && r.RegistrationPositive == true);
            }
        }

        public int T2Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.T2 && r.RegistrationPositive == true);
            }
        }

        public int B1Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.B1 && r.RegistrationPositive == true);
            }
        }

        public int B2Yes
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.B2 && r.RegistrationPositive == true);
            }
        }

        public int S1No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.S1 && r.RegistrationPositive == false);
            }
        }

        public int S2No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.S2 && r.RegistrationPositive == false);
            }
        }

        public int A1No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.A1 && r.RegistrationPositive == false);
            }
        }

        public int A2No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.A2 && r.RegistrationPositive == false);
            }
        }

        public int T1No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.T1 && r.RegistrationPositive == false);
            }
        }

        public int T2No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.T2 && r.RegistrationPositive == false);
            }
        }

        public int B1No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.B1 && r.RegistrationPositive == false);
            }
        }

        public int B2No
        {
            get
            {
                return Registrations.Count(r => r.Voice == VoiceGroup.B2 && r.RegistrationPositive == false);
            }
        }

        public int S1NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.S1);
            }
        }

        public int S2NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.S2);
            }
        }

        public int A1NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.A1);
            }
        }

        public int A2NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.A2);
            }
        }

        public int T1NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.T1);
            }
        }

        public int T2NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.T2);
            }
        }

        public int B1NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.B1);
            }
        }

        public int B2NoAnswer
        {
            get
            {
                return WithoutAnswer.Count(r => r.Voice == VoiceGroup.B2);
            }
        }



        public AdminEventDetailViewModel(Event e, List<AdminEventDetailSingerRegistrationViewModel> registrations, List<AdminEventDetailSingerRegistrationViewModel> withoutAnswer) : base(e)
        {
            Registrations = registrations;
            WithoutAnswer = withoutAnswer;
        }


    }
}
