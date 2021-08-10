using BlogApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Repositories.Abstract
{
    public interface IArticleRepository:IBaseRepository<Article>
    {
    }
}
