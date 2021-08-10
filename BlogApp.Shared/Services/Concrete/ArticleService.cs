using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Shared.Abstract;
using BlogApp.Shared.Dtos;
using BlogApp.Shared.Services.Abstract;

namespace BlogApp.Shared.Services.Concrete
{
    public class ArticleService:IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ArticleDto> AddAsync(ArticleAddDto articleAddDto, string createdByName)
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

        public Task<ArticleDto> DeleteAsync(int articleId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleListDto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleListDto> GetAllByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleListDto> GetAllByNonDeletedAndActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleListDto> GetAllByNonDeletedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> GetAsync(int articleId)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDto> UpdateAsync(ArticleUpdateDto articleUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
