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

        public async Task<IResponseDatat<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = _mapper.Map<CategoryAddDto, Category>(categoryAddDto);
            category.Modifier = createdByName;
            category.Owner = createdByName;
            var result = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();
            var rs =   _mapper.Map<Category, CategoryDto>(result);
            return new ResponseData<CategoryDto>(ResponseStatus.SUCCESS, rs);
        }

        public async Task<IResponseDatat<int>> CountAsync()
        {
            var count = await _unitOfWork.Categories.CountAsync();
            return new ResponseData<int>(ResponseStatus.SUCCESS, count);
        }

        public async Task<IResponseDatat<int>> CountByActiveAsync()
        {
            var count =  await _unitOfWork.Categories.CountAsync(_ => _.Status == EntityStatus.Values.ACTIVE );
            return new ResponseData<int>(ResponseStatus.SUCCESS, count);
        }


        public async Task<IResponseDatat<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await _unitOfWork.Categories.GetById(categoryId); 
            if(category == null)
                return new ResponseData<CategoryDto>(ResponseStatus.ERROR, message: "Category not found", data: null);

            category.Modifier = modifiedByName;
            category.Status = EntityStatus.Values.DELETED;
            var result = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            var rs = _mapper.Map<Category, CategoryDto>(result);
            return new ResponseData<CategoryDto>(ResponseStatus.SUCCESS, rs);
        }

        public async Task<IResponseDatat<IList<CategoryDto>>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null);
            if (categories.Count > -1)
            {
                var result =  _mapper.Map<IList<Category>, IList<CategoryDto>>(categories);
                return new ResponseData<IList<CategoryDto>>(ResponseStatus.SUCCESS, result);       
            }
            return new ResponseData<IList<CategoryDto>>(ResponseStatus.ERROR, message:"Category not found", data:null);
           
        }

        public async Task<IResponseDatat<IList<CategoryDto>>> GetAllByActiveAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(_=> _.Status == EntityStatus.Values.ACTIVE);
            if (categories.Count > -1)
            {
                var result = _mapper.Map<IList<Category>, IList<CategoryDto>>(categories);
                return new ResponseData<IList<CategoryDto>>(ResponseStatus.SUCCESS, result);
            }
            return new ResponseData<IList<CategoryDto>>(ResponseStatus.ERROR, message: "Not found any category", data: null);

        }

        public async Task<IResponseDatat<CategoryDto>> GetAsync(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetById(categoryId);
            if (category == null)
                return new ResponseData<CategoryDto>(ResponseStatus.ERROR, message: "Not found any category", data: null);
            var result =  _mapper.Map<Category, CategoryDto>(category);
            return new ResponseData<CategoryDto>(ResponseStatus.SUCCESS, result);
        }

        public async Task<IResponseDatat<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto);
            if (category == null)
                return new ResponseData<CategoryDto>(ResponseStatus.ERROR, message: "Category not found", data: null);

            category.Modifier = modifiedByName;
            var result = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            var rs = _mapper.Map<Category, CategoryDto>(result);
            return new ResponseData<CategoryDto>(ResponseStatus.SUCCESS, rs);
        }
    }
}
