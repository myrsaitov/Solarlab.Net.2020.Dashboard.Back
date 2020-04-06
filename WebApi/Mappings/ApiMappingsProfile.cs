using AutoMapper;
using BusinessLogic.Services.Contracts.Models;
using WebApi.Models.Advertisements;
using WebApi.Models.Tags;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Mappings
{
    /// <summary>
    /// Профиль автомаппера.
    /// </summary>
    public class ApiMappingsProfile : Profile
    {
        public ApiMappingsProfile ()
        {


            CreateMap<AdvertisementCreateModel, AdvertisementDto>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Comments, opt => opt.Ignore())
                .ForMember(d => d.Category, opt => opt.Ignore());
            CreateMap<TagModel, TagDto>();





            /* CreateMap<CategoryCreateModel, CategoryDto>()
             .ForMember(d => d.ParentCategory, map => map.Ignore())
             .ForMember(d => d.Childs, map => map.Ignore());

             CreateMap<CategoryCreateModel, CategoryCreateDto>();

             CreateMap<CategoryDto, CategoryGetModel>();

             CreateMap<CategoryDto, CategoryChildGetModel>();

             CreateMap<CategoryUpdateModel, CategoryDto>()
             .ForMember(d => d.ParentCategory, map => map.Ignore())
             .ForMember(d => d.Childs, map => map.Ignore());*/
        }
    }
}
