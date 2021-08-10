using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Shared.Dtos;


namespace BlogApp.Shared.Services.Abstract
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetAsync(int categoryId);
        Task<IList<CategoryDto>> GetAllAsync();
        Task<IList<CategoryDto>> GetAllByActiveAsync();
    
        Task<CategoryDto> AddAsync(CategoryAddDto categoryAddDto,string createdByName);
        Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<CategoryDto> DeleteAsync(int categoryId, string modifiedByName);
        Task<int> CountAsync();
        Task<int> CountByActiveAsync();
    }
}
