using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THPDocument.Models
{
    public class ChangePasswordModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string PasswordNew { get; set; }

        [Compare("PasswordNew", ErrorMessage = "Confirm password is incorrect, Please try again!")]
        public string ConfirmPassword { get; set; }
    }
}