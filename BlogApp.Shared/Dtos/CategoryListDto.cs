using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Data.Entities;

namespace BlogApp.Shared.Dtos
{
    public class CategoryListDto
    {
        public IList<Category> Categories { get; set; }
    }
}
