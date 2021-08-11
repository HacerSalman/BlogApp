using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Shared.Dtos;

namespace BlogApp.Shared.Services.Abstract
{
    public interface IArticleService
    {
        Task<ArticleDto> GetAsync(int articleId);
        Task<IList<ArticleDto>> GetAllAsync();
        Task<IList<ArticleDto>> GetAllByNonDeletedAsync();
        Task<IList<ArticleDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IList<ArticleDto>> GetAllByCategoryAsync(int categoryId);
        Task<ArticleDto> AddAsync(ArticleAddDto articleAddDto, string createdByName);
        Task<ArticleDto> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<ArticleDto> DeleteAsync(int articleId, string modifiedByName);
        Task<int> CountAsync();
    }
}
