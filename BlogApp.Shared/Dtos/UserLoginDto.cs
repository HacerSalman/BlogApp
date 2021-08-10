using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Dtos
{
    public class UserLoginDto
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} should not be empty.")]
        [MaxLength(512, ErrorMessage = "{0} must not be larger than {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} must not be less than {1} characters.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} should not be empty.")]
        [MaxLength(16, ErrorMessage = "{0} must not be larger than {1} characters.")]
        [MinLength(6, ErrorMessage = "{0} must not be less than {1} characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}
