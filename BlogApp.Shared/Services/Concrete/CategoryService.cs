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

namespace BlogApp.Shared.Services.Concrete
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<CategoryDto> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountByNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> DeleteAsync(int categoryId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories =  await _unitOfWork.Categories.GetAllAsync(null);
           return  _mapper.Map<List<Category>, List<CategoryDto>>(categories);
        }

        public Task<CategoryListDto> GetAllByActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> GetAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryUpdateDto> GetCategoryUpdateDtoAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
