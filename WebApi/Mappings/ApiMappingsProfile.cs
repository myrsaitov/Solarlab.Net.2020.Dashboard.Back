using AutoMapper;
using BusinessLogic.Services.Contracts.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Mappings
{
    public class ApiMappingsProfile : Profile
    {
        public ApiMappingsProfile ()
        {
            CreateMap<CategoryCreateModel, CategoryDto>()
            .ForMember(d => d.ParentCategory, map => map.Ignore())
            .ForMember(d => d.Childs, map => map.Ignore());

            CreateMap<CategoryCreateModel, CategoryCreateDto>();

            CreateMap<CategoryDto, CategoryGetModel>();

            CreateMap<CategoryDto, CategoryChildGetModel>();

            CreateMap<CategoryUpdateModel, CategoryDto>()
            .ForMember(d => d.ParentCategory, map => map.Ignore())
            .ForMember(d => d.Childs, map => map.Ignore());
        }
    }
}
