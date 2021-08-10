﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Data.Entities;
using BlogApp.Data.Enums;

namespace BlogApp.Shared.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Title")]
        [Required(ErrorMessage = "{0} field should not be empty.")]
        [MaxLength(100, ErrorMessage = "The {0} field must not be larger than {1} characters.")]
        [MinLength(5, ErrorMessage = "The {0} field must not be less than {1} characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} field should not be empty.")]
        [MinLength(20, ErrorMessage = "The {0} field must not be less than {1} characters.")]
        [DisplayName("Content")]
        public string Content { get; set; }

        [DisplayName("Seo Author")]
        [Required(ErrorMessage = "{0} field should not be empty.")]
        [MaxLength(50, ErrorMessage = "The {0} field must not be larger than {1} characters.")]
        [MinLength(0, ErrorMessage = "The {0} field must not be less than {1} characters.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Description")]
        [Required(ErrorMessage = "{0} field should not be empty.")]
        [MaxLength(150, ErrorMessage = "The {0} field must not be larger than {1} characters.")]
        [MinLength(0, ErrorMessage = "The {0} field must not be less than {1} characters.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Tags")]
        [Required(ErrorMessage = "{0} field should not be empty.")]
        [MaxLength(70, ErrorMessage = "The {0} field must not be larger than {1} characters.")]
        [MinLength(5, ErrorMessage = "The {0} field must not be less than {1} characters.")]
        public string SeoTags { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "{0} field should not be empty.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Status")]
        public EntityStatus.Values Status { get; set; }

    }
}
