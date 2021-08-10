using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Dtos
{
   public class UserPasswordChangeDto
    {
        [DisplayName("Current Password")]
        [Required(ErrorMessage = "{0} should not be empty.")]
        [MaxLength(30, ErrorMessage = "{0} must not be larger than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must not be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "{0} should not be empty.")]
        [MaxLength(30, ErrorMessage = "{0} must not be larger than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must not be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Repeat Password")]
        [Required(ErrorMessage = "{0} should not be empty.")]
        [MaxLength(30, ErrorMessage = "{0} must not be larger than {1} characters.")]
        [MinLength(5, ErrorMessage = "{0} must not be less than {1} characters.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage = "Passwords not match")]
        public string RepeatPassword { get; set; }
    }
}
