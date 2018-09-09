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
    public class EventDetailEditViewModel : EventTypesViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadán název události."), MaxLength(100, ErrorMessage = "Název události může mít maximálně 100 znaků.")]
        [Display(Name = "Název")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Od")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy hh:mm}")]
        public DateTime From { get; set; }

        [Required]
        [Display(Name = "Do")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy hh:mm}")]
        public DateTime To { get; set; }

        [Required]
        [Display(Name = "Typ")]
        public EventType? EventType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadáno místo konání události."), MaxLength(150, ErrorMessage = "Místo konání může mít maximálně 150 znaků.")]
        [Display(Name = "Místo")]
        public string Place { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = "Musí být zadán nějaký popis události"), MaxLength(150, ErrorMessage = "Popis události může mít maximálně 1000 znaků.")]
        [Display(Name = "Popis")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Začátek přihlašování")]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy hh:mm}")]
        public DateTime StartOfRegistration { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Konec přihlašování")]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy hh:mm}")]
        public DateTime EndOfRegistration { get; set; }

        [Display(Name = "Pořadatel")]
        public string Organizer { get; set; }

        public EventDetailEditViewModel()
        {

        }

        public EventDetailEditViewModel(Event e)
        {
            Id = e.Id;
            Name = e.Name;
            From = e.From;
            To = e.To;
            EventType = e.EventType;
            Place = e.Place;
            StartOfRegistration = e.StartOfRegistration;
            EndOfRegistration = e.EndOfRegistration;
            Description = e.Description;
            Organizer = e.Organizer;
        }

        public Event ToEvent()
        {
            return new Event
            {
                Id = Id,
                Name = Name,
                From = From,
                To = To,
                EventType = EventType ?? Models.Enums.EventType.Concert,
                Place = Place,
                StartOfRegistration = StartOfRegistration,
                EndOfRegistration = EndOfRegistration,
                Description = Description,
                Organizer = Organizer
            };
        }

        public string EventTypeString
        {
            get
            {
                return EnumConverter.GetEventTypeNameString(this.EventType.Value);
            }
        }
    }
}
