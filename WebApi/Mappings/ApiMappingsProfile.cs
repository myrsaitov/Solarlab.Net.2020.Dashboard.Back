using AutoMapper;
using BusinessLogic.Services.Contracts.Models;
using WebApi.Models.Advertisements;
using WebApi.Models.Tags;
using WebApi.Models.Comments;
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

            /*
            CreateMap<AdvertisementCreateModel, AdvertisementDto>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Comments, opt => opt.Ignore())
                .ForMember(d => d.Category, opt => opt.Ignore());



            CreateMap<TagModel, TagDto>();

            CreateMap<CategoryCreateModel, CategoryDto>()
            .ForMember(d => d.ParentCategory, map => map.Ignore())
            .ForMember(d => d.Childs, map => map.Ignore());

           // CreateMap<CategoryCreateModel, CategoryCreateDto>();

            CreateMap<AdvertisementDto, AdvertisementGetModel>()
            .ForMember(d => d.Title, opt => opt.Ignore())
            .ForMember(d => d.Body, opt => opt.Ignore())
            .ForMember(d => d.CategoryId, opt => opt.Ignore())
            .ForMember(d => d.Tags, opt => opt.Ignore());

           // CreateMap<CategoryDto, AdvertisementChildGetModel>();

            CreateMap<AdvertisementUpdateModel, CategoryDto>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.ParentCategory, map => map.Ignore())
            .ForMember(d => d.Name, map => map.Ignore())
             .ForMember(d => d.ParentCategoryId, map => map.Ignore())
            .ForMember(d => d.Childs, map => map.Ignore());

            */


            CreateMap<AdvertisementCreateModel, AdvertisementDto>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.Category, map => map.Ignore())
            .ForMember(d => d.Comments, map => map.Ignore());

            CreateMap<AdvertisementDto, AdvertisementGetModel>()
            .ForMember(d => d.Tags, map => map.Ignore());


            CreateMap<AdvertisementUpdateModel, AdvertisementDto>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.Category, map => map.Ignore())
            .ForMember(d => d.Comments, map => map.Ignore());








            CreateMap<CommentModel, CommentDto>();
            CreateMap<LoginModel, TagDto>();







            // From Lera original

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
