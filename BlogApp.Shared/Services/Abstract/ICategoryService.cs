using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Shared.Dtos;
using BlogApp.Shared.Response;

namespace BlogApp.Shared.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IResponseDatat<CategoryDto>> GetAsync(int categoryId);
        Task<IResponseDatat<IList<CategoryDto>>> GetAllAsync();
        Task<IResponseDatat<IList<CategoryDto>>> GetAllByActiveAsync();
    
        Task<IResponseDatat<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto,string createdByName);
        Task<IResponseDatat<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResponseDatat<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);
        Task<IResponseDatat<int>> CountAsync();
        Task<IResponseDatat<int>> CountByActiveAsync();
    }
}
