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
    public class EventListViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadán název události."), MaxLength(100, ErrorMessage = "Název události může mít maximálně 100 znaků.")]
        [Display(Name = "Název")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Od")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dddd d.M.yyyy H:mm}")]
        public DateTime From { get; set; }

        [Required]
        [Display(Name = "Do")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dddd d.M.yyyy H:mm}")]
        public DateTime To { get; set; }

        [Required]
        [Display(Name = "Typ")]
        public EventType? EventType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musí být zadáno místo konání události."), MaxLength(150, ErrorMessage = "Místo konání může mít maximálně 150 znaků.")]
        [Display(Name = "Místo")]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Začátek přihlašování")]
        [DisplayFormat(DataFormatString = "{0:dddd d.M.yyyy H:mm}")]
        public DateTime StartOfRegistration { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Konec přihlašování")]
        [DisplayFormat(DataFormatString = "{0:dddd d.M.yyyy H:mm}")]
        public DateTime EndOfRegistration { get; set; }


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

        public EventListViewModel()
        {

        }

        public EventListViewModel(Event e)
        {
            Id = e.Id;
            Name = e.Name;
            From = e.From;
            To = e.To;
            EventType = e.EventType;
            Place = e.Place;
            StartOfRegistration = e.StartOfRegistration;
            EndOfRegistration = e.EndOfRegistration;
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
