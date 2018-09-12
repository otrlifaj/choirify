using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.ViewModels.UserViewModels
{
    public class UserDetailEditViewModel : PopulatedDropdownsViewModel
    {

        public string UserId { get; set; }

        public int? SingerId { get; set; }

        public int? ChoirmasterId { get; set; }


        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Účet vytvořen")]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy hh:mm}")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Poslední přihlášení")]
        [DisplayFormat(DataFormatString = "{0:d/M/yyyy hh:mm}")]
        public DateTime LastLogin { get; set; }

        [Display(Name = "Povolit přístup")]
        public Boolean CanLogin { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat jméno."), MaxLength(30, ErrorMessage = "Jméno může mít maximálně 30 znaků.")]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat příjmení."), MaxLength(40, ErrorMessage = "Příjmení může mít maximálně 40 znaků.")]
        [Display(Name = "Příjmení")]
        public string Surname { get; set; }

        [Display(Name = "GDPR")]
        public Boolean GdprApproved { get; set; }

        [Display(Name = "Role")]
        public List<string> SelectedRoles { get; set; }

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
