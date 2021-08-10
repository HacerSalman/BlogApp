using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Shared.Abstract;
using BlogApp.Shared.Repositories.Concrete;
using BlogApp.Shared.Repositories.Abstract;
using BlogApp.Data.Context;

namespace BlogApp.Shared.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly BlogAppDbContext _context;
        private ArticleRepository _articleRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;

        public UnitOfWork(BlogAppDbContext context)
        {
            _context = context;
        }

        public IArticleRepository Articles => _articleRepository ?? new ArticleRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new CommentRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
