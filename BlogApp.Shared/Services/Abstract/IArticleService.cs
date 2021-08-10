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
        Task<ArticleListDto> GetAllAsync();
        Task<ArticleListDto> GetAllByNonDeletedAsync();
        Task<ArticleListDto> GetAllByNonDeletedAndActiveAsync();
        Task<ArticleListDto> GetAllByCategoryAsync(int categoryId);
        Task<ArticleDto> AddAsync(ArticleAddDto articleAddDto, string createdByName);
        Task<ArticleDto> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName);
        Task<ArticleDto> DeleteAsync(int articleId, string modifiedByName);
        Task<int> CountAsync();
    }
}
