using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Data.Entities;

namespace BlogApp.Shared.Dtos
{
    public class ArticleListDto
    {
        public IList<Article> Articles { get; set; }
    }
}
