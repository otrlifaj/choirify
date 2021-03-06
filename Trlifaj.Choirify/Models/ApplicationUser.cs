﻿using System;
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
        [Column(TypeName = "varchar(50)")]
        public override string Email { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }

        public Boolean IsDeleted { get; set; }

        public Boolean CanLogin { get; set; }

        public Boolean GdprApproved { get; set; }

        public int? SingerId { get; set; }
        public Singer Singer { get; set; }

        public int? ChoirmasterId { get; set; }
        public Choirmaster Choirmaster { get; set; }

        public ApplicationUser()
        {
            CanLogin = false;
            SingerId = null;
            ChoirmasterId = null;
            GdprApproved = false;

        }

    }
}
