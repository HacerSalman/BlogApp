using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogApp.Shared.Repositories.Abstract;
using BlogApp.Data.Entities;
using BlogApp.Data.Context;

namespace BlogApp.Shared.Repositories.Concrete
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetById(int categoryId)
        {
            return await BlogAppDbContext.Categories.SingleOrDefaultAsync(c => c.Id == categoryId);
        }

        private BlogAppDbContext BlogAppDbContext
        {
            get
            {
                return _context as BlogAppDbContext;
            }
        }
    }
}
