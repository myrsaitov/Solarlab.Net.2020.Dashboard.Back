using AutoMapper;
using BusinessLogic.Services.Contracts.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Mapping
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        { 
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryCreateDto, Category>()
            .ForMember(d => d.ParentCategory, map => map.Ignore())
            .ForMember(d => d.Childs, map => map.Ignore());
        }
    }
}
