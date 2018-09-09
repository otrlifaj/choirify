using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.AccountViewModels
{
    public class RegisterViewModel : PopulatedDropdownsViewModel
    {

        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musíš zadat heslo.")]
        [StringLength(100, ErrorMessage = "{0} musí mít minimálně {2} a maximálně {1} znaků.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdit heslo")]
        [Compare("Password", ErrorMessage = "Hesla se neshodují.")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat jméno."), MaxLength(30, ErrorMessage = "Jméno může mít maximálně 30 znaků.")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat příjmení."), MaxLength(40, ErrorMessage = "Příjmení může mít maximálně 40 znaků.")]
        [Display(Name = "Příjmení")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Musíš zadat datum narození.")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum narození")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Musíš zadat telefonní číslo."), MaxLength(20, ErrorMessage = "Telefonní číslo může mít maximálně 20 znaků.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefonní číslo je ve špatném formátu.")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Musíš zadat číslo OP."), MaxLength(15, ErrorMessage = "Číslo OP může mít maximálně 20 znaků.")]
        [Display(Name = "Číslo OP")]
        public string NumberOfIDCard { get; set; }

        public string Address
        {
            get
            {
                var value = string.Format("{0}, {1}, {2}, {3}", Street, City, ZipCode, Country);
                return value;
            }
        }

        [Required(ErrorMessage = "Musíš zadat ulici.")]
        [Display(Name = "Ulice")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Musíš zadat město.")]
        [Display(Name = "Město")]
        public string City { get; set; }

        [Required(ErrorMessage = "Musíš zadat PSČ.")]
        [Display(Name = "PSČ")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Musíš zadat zemi.")]
        [Display(Name = "Země")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Zpěvák")]
        public Boolean IsSinger { get; set; } = true;

        [Display(Name = "Hlasová skupina")]
        public VoiceGroup? VoiceGroup { get; set; }
        
        [Display(Name = "Souhlas se zpracováním osobních údajů")]
        public Boolean GdprApproved { get; set; } = false;
    }
}
