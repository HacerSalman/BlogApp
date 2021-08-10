using Microsoft.EntityFrameworkCore;
using BlogApp.Shared.Repositories.Abstract;
using BlogApp.Data.Entities;

namespace BlogApp.Shared.Repositories.Concrete
{
    public class ArticleRepository:BaseRepository<Article>,IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {
        }

    }
}
