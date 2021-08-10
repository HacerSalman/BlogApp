﻿using System;
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
        Task<CategoryUpdateDto> GetCategoryUpdateDtoAsync(int categoryId);
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryListDto> GetAllByActiveAsync();
    
        Task<CategoryDto> AddAsync(CategoryAddDto categoryAddDto,string createdByName);
        Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<CategoryDto> DeleteAsync(int categoryId, string modifiedByName);
        Task<int> CountAsync();
    }
}