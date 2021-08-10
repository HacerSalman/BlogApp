using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Data.Entities;
using BlogApp.Data.Utils;
using BlogApp.Shared.Dtos;

namespace BlogApp.Services.AutoMapper.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ReverseMap();

            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<List<CategoryDto>, List<Category>>().ReverseMap();

        }
    }
}
