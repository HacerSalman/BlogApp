using BlogApp.Shared.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Shared.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleRepository Articles { get; } 
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
 
        Task<int> SaveAsync();
    }
}
