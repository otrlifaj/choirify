using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.UserViewModels
{
    public class UserListViewModel : CountriesAndVoiceGroupsViewModel
    {
        public string UserId { get; set; }

        public int SingerId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Display(Name = "Příjmení")]
        public string Surname { get; set; }

        [Display(Name = "Hlasová skupina")]
        public VoiceGroup? VoiceGroup { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Poslední přihlášení")]
        public DateTime LastLogin { get; set; }

        [Display(Name = "Přístup povolen")]
        public Boolean CanLogin { get; set; }


    }
}
