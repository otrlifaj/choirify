using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trlifaj.Choirify.ViewModels.AccountViewModels
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "{0} musí mít minimálně {2} a maximálně {1} znaků.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Kód pro dvoufázové ověření")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Zapamatovat si toto zařízení?")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
