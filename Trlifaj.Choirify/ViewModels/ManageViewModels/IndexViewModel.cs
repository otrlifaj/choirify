using System;
using System.ComponentModel.DataAnnotations;

namespace Trlifaj.Choirify.ViewModels.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Uživatelské jméno")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat jméno."), MaxLength(30, ErrorMessage = "Jméno může mít maximálně 30 znaků.")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat příjmení."), MaxLength(40, ErrorMessage = "Příjmení může mít maximálně 40 znaků.")]
        [Display(Name = "Příjmení")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Musíš zadat datum narození.")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum narození")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Musíš zadat telefonní číslo."), MaxLength(20, ErrorMessage = "Telefonní číslo může mít maximálně 20 znaků.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefonní číslo je ve špatném formátu.")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Musíš zadat číslo OP."), MaxLength(15, ErrorMessage = "Číslo OP může mít maximálně 20 znaků.")]
        [Display(Name = "Číslo OP")]
        public string NumberOfIDCard { get; set; }

        [MaxLength(15, ErrorMessage = "Číslo pasu může mít maximálně 30 znaků.")]
        [Display(Name = "Číslo pasu (nepovinné)")]
        public string PassportNumber { get; set; }


        [Required(ErrorMessage = "Musíš zadat adresu."), MaxLength(150, ErrorMessage = "Adresa může mít maximálně 150 znaků.")]
        [Display(Name = "Adresa")]
        public string Address { get; set; }

        public string StatusMessage { get; set; }
    }
}
