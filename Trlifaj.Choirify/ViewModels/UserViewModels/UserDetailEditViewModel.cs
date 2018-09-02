using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.UserViewModels
{
    public class UserDetailEditViewModel : CountriesAndVoiceGroupsViewModel
    {

        public string UserId { get; set; }

        public int SingerId { get; set; }


        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Účet vytvořen")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Poslední přihlášení")]
        public DateTime LastLogin { get; set; }

        [Display(Name = "Povolit přístup")]
        public Boolean CanLogin { get; set; }


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

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Url fotky")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Aktivní")]
        public Boolean IsActive { get; set; }

        [Display(Name = "Hlasová skupina")]
        public VoiceGroup? VoiceGroup { get; set; }

        [Display(Name = "Role")]
        public List<string> SelectedRoles { get; set; }


    }
}
