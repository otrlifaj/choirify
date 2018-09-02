using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Trlifaj.Choirify.Models.Enums;

namespace Trlifaj.Choirify.Models
{
    public class Singer : BaseEntity
    {
        [Key]
        public int Id { get; set; }

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
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Musíš zadat email."), MaxLength(50, ErrorMessage = "Email může mít maximálně 50 znaků.")]
        [EmailAddress(ErrorMessage = "Emailová adresa je ve špatném formátu.")]
        [Display(Name = "Email")]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musíš zadat číslo OP."), MaxLength(20, ErrorMessage = "Číslo OP může mít maximálně 20 znaků.")]
        [Display(Name = "Číslo OP")]
        [Column(TypeName = "varchar(20)")]
        public string NumberOfIDCard { get; set; }

        [MaxLength(15, ErrorMessage = "Číslo pasu může mít maximálně 30 znaků.")]
        [Display(Name = "Číslo pasu")]
        [Column(TypeName = "varchar(30)")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Musíš zadat adresu."), MaxLength(150, ErrorMessage = "Adresa může mít maximálně 150 znaků.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Adresa")]
        [Column(TypeName = "varchar(150)")]
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Url fotky")]
        [Column(TypeName = "varchar(255)")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Aktivní")]
        public Boolean IsActive { get; set; }

        [Display(Name = "Hlasová skupina")]
        [Column(TypeName = "varchar(2)")]
        public VoiceGroup? VoiceGroup { get; set; }

        public Singer()
        {
            VoiceGroup = null;
            Address = null;
            IsActive = true;
        }

    }
}
