using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        [Column(TypeName = "varchar(50)")]
        public override string Email { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Účet vytvořen")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Poslední přihlášení")]
        public DateTime LastLogin { get; set; }


        [Display(Name = "Příhlašení povoleno")]
        public Boolean CanLogin { get; set; }

        public int SingerId { get; set; }
        public Singer Singer { get; set; }

        public ApplicationUser()
        {
            CanLogin = false;

        }

    }
}
