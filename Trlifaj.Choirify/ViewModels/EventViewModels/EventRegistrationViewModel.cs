using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;
using Trlifaj.Choirify.Models.ManyToMany;

namespace Trlifaj.Choirify.ViewModels.EventViewModels
{
    public class EventRegistrationViewModel : DressOrderTypesViewModel
    {
        public DateTime RegistrationDeadline { get; set; }

        public int? Id { get; set; }

        public bool IsRegistered { get; set; }

        public bool ShouldOrderDress { get; set; }


        [Required(ErrorMessage = "Musíš se vyjádřit k účasti.")]
        public Boolean Answer { get; set; }

        [MaxLength(255, ErrorMessage = "Maximální délka poznámky je 255 znaků.")]
        [Display(Name = "Poznámka")]
        [Required(ErrorMessage = "V případě neúčasti musíš zadat důvod.")]
        public string Comment { get; set; }

        public VoiceGroup? Voice { get; set; }
        [Display(Name = "Šaty")]
        public DressOrderType? DressOrder { get; set; }

        public int? SingerId { get; set; }

        public int? EventId { get; set; }

        public EventRegistrationViewModel()
        {
            IsRegistered = false;
        }

        public EventRegistrationViewModel(VoiceGroup? voice)
        {
            Voice = voice;
            if (voice == VoiceGroup.A1 || voice == VoiceGroup.A2 || voice == VoiceGroup.S1 || voice == VoiceGroup.S2)
            {
                ShouldOrderDress = true;
            }
            else
            {
                ShouldOrderDress = false;
            }
        }

        public EventRegistrationViewModel(EventRegistration r, VoiceGroup? voice) : this(voice)
        {
            Id = r.Id;
            Answer = r.Answer;
            Comment = r.Comment;
            DressOrder = r.DressOrder;
            SingerId = r.SingerId;
            EventId = r.EventId;
            if (EventId != null && SingerId != null)
            {
                IsRegistered = true;
            }
            else
            {
                IsRegistered = false;
            }
        }
        public EventRegistrationViewModel(EventRegistration r, VoiceGroup? voice, DateTime endOfRegistration) : this(r, voice)
        {
            RegistrationDeadline = endOfRegistration;
        }


        public EventRegistrationViewModel(VoiceGroup? voice, int? eventId, int? singerId, DateTime endOfRegistration) : this(voice)
        {
            EventId = eventId;
            SingerId = singerId;
            RegistrationDeadline = endOfRegistration;
        }


        public EventRegistration ToEventRegistration()
        {
            return new EventRegistration
            {
                Id = Id,
                Answer = Answer,
                Comment = Comment,
                DressOrder = DressOrder,
                SingerId = SingerId,
                EventId = EventId
            };
        }
    }
}