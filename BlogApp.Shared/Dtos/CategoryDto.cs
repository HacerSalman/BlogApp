using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Data.Entities;
using BlogApp.Data.Enums;

namespace BlogApp.Shared.Dtos
{
    public class CategoryDto
    {
        public  int Id { get; set; }
        public  DateTime CreateTime { get; set; }
        public  DateTime UpdateTime { get; set; }
        public  EntityStatus.Values Status { get; set; } 
        public  string Owner { get; set; } 
        public  string Modifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
