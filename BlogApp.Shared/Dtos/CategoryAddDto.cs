using BlogApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "{0} should not be empty.")]
        [MaxLength(70,ErrorMessage = "{0} must not be larger than {1} characters.")]
        [MinLength(3,ErrorMessage = "{0} must not be less than {1} characters.")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [MaxLength(500, ErrorMessage = "{0} must not be larger than {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} must not be less than {1} characters.")]
        public string Description { get; set; }

        [DisplayName("Status")]
        public EntityStatus.Values Status { get; set; }
    }
}
