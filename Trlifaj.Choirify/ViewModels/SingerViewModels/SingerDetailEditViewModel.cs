using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.SingerViewModels
{
    public class SingerDetailEditViewModel : PopulatedDropdownsViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat jméno."), MaxLength(30, ErrorMessage = "Jméno může mít maximálně 30 znaků.")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat příjmení."), MaxLength(40, ErrorMessage = "Příjmení může mít maximálně 40 znaků.")]
        [Display(Name = "Příjmení")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Musíš zadat datum narození.")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum narození")]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Musíš zadat telefonní číslo."), MaxLength(20, ErrorMessage = "Telefonní číslo může mít maximálně 20 znaků.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefonní číslo je ve špatném formátu.")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musíš zadat číslo OP."), MaxLength(20, ErrorMessage = "Číslo OP může mít maximálně 20 znaků.")]
        [Display(Name = "Číslo OP")]
        public string NumberOfIDCard { get; set; }

        [MaxLength(30, ErrorMessage = "Číslo pasu může mít maximálně 30 znaků.")]
        [Display(Name = "Číslo pasu")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Musíš zadat adresu."), MaxLength(150, ErrorMessage = "Adresa může mít maximálně 150 znaků.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Aktivní")]
        public Boolean IsActive { get; set; }

        [Display(Name = "Hlasová skupina")]
        public VoiceGroup? VoiceGroup { get; set; }

        public SingerDetailEditViewModel()
        {

        }

        public SingerDetailEditViewModel(Singer s)
        {
            Id = s.Id;
            FirstName = s.FirstName;
            Surname = s.Surname;
            PhoneNumber = s.PhoneNumber;
            Email = s.Email;
            IsActive = s.IsActive;
            VoiceGroup = s.VoiceGroup;
            Address = s.Address;
            DateOfBirth = s.DateOfBirth;
            NumberOfIDCard = s.NumberOfIDCard;
            PassportNumber = s.PassportNumber;
        }

        public Singer ToSinger()
        {
            return new Singer
            {
                Id = Id,
                FirstName = FirstName,
                Surname = Surname,
                PhoneNumber = PhoneNumber,
                Email = Email,
                IsActive = IsActive,
                VoiceGroup = VoiceGroup,
                Address = Address,
                DateOfBirth = DateOfBirth,
                NumberOfIDCard = NumberOfIDCard,
                PassportNumber = PassportNumber
            };
        }

    }
}
