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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat jméno."), MaxLength(30, ErrorMessage = "Jméno může mít maximálně 30 znaků.")]
        [Display(Name = "Jméno")]
        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Musíš zadat příjmení."), MaxLength(40, ErrorMessage = "Příjmení může mít maximálně 40 znaků.")]
        [Display(Name = "Příjmení")]
        [Column(TypeName = "varchar(40)")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Musíš zadat datum narození.")]
        [DataType(DataType.Date)]
        [Display(Name = "Datum narození")]
        // TODO: ensure that date is in past
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Musíš zadat telefonní číslo."), MaxLength(20, ErrorMessage = "Telefonní číslo může mít maximálně 20 znaků.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Telefonní číslo je ve špatném formátu.")]
        [Display(Name = "Telefon")]
        [Column(TypeName = "varchar(20)")]
        public override string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        [Column(TypeName = "varchar(50)")]
        public override string Email { get; set; }

        [Required(ErrorMessage = "Musíš zadat číslo OP."), MaxLength(15, ErrorMessage = "Číslo OP může mít maximálně 20 znaků.")]
        [Display(Name = "Číslo OP")]
        [Column(TypeName = "varchar(20)")]
        public string NumberOfIDCard { get; set; }

        [Required(ErrorMessage = "Musíš zadat adresu."), MaxLength(100, ErrorMessage = "Adresa může mít maximálně 150 znaků.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Adresa")]
        [Column(TypeName = "varchar(150)")]
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Url fotky")]
        [Column(TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Účet vytvořen")]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Poslední přihlášení")]
        public DateTime LastLogin { get; set; }

        [Required]
        [Display(Name = "Aktivní")]
        public Boolean IsActive { get; set; }

        [Required]
        [Display(Name = "Zpěvák")]
        public Boolean IsSinger { get; set; }

        [Display(Name = "Příhlašení povoleno")]
        public Boolean CanLogin { get; set; }

        [Display(Name = "Hlasová skupina")]
        public VoiceGroup? VoiceGroup { get; set; }

        public ApplicationUser()
        {
            IsSinger = true;
            IsActive = true;
            CanLogin = false;
            VoiceGroup = null;
            Address = null;
        }

    }
}
