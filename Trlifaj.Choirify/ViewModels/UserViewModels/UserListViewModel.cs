using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.UserViewModels
{
    public class UserListViewModel : PopulatedDropdownsViewModel
    {
        public string UserId { get; set; }

        public int? SingerId { get; set; }

        public int? ChoirmasterId { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Display(Name = "Příjmení")]
        public string Surname { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Poslední přihlášení")]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy hh:mm}")]
        public DateTime LastLogin { get; set; }

        [Display(Name = "Přístup povolen")]
        public Boolean CanLogin { get; set; }

        [Display(Name = "GDPR")]
        public Boolean GdprApproved { get; set; }

        public Boolean IsChoirmaster
        {
            get
            {
                return (ChoirmasterId != null);
            }
        }

        public Boolean IsSinger
        {
            get
            {
                return (SingerId != null);
            }
        }

    }
}
