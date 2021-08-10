using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Shared.Abstract;
using BlogApp.Shared.Dtos;
using BlogApp.Shared.Services.Abstract;
using BlogApp.Data.Entities;
using BlogApp.Data.Enums;
using BlogApp.Shared.Response;

namespace BlogApp.Shared.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<CategoryAddDto, Category>(categoryAddDto);
            category.Modifier = createdByName;
            category.Owner = createdByName;
            var result = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<Category, CategoryDto>(result);
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Categories.CountAsync();
        }

        public async Task<int> CountByActiveAsync()
        {
            return await _unitOfWork.Categories.CountAsync(_ => _.Status == EntityStatus.Values.ACTIVE );
        }


        public async Task<CategoryDto> DeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetById(categoryId);         
            category.Modifier = modifiedByName;
            category.Status = EntityStatus.Values.DELETED;
            var result = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<Category, CategoryDto>(result);
        }

        public async Task<IList<CategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null);
            return _mapper.Map<IList<Category>, IList<CategoryDto>>(categories);
        }

        public async Task<IList<CategoryDto>> GetAllByActiveAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(_=> _.Status == EntityStatus.Values.ACTIVE);
            return _mapper.Map<IList<Category>, IList<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetAsync(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetById(categoryId);
            return _mapper.Map<Category, CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto);
            category.Modifier = modifiedByName;
            var result = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<Category, CategoryDto>(result);
        }
    }
}
