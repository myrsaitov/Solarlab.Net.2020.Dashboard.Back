using AutoMapper;
using BusinessLogic.Services.Contracts.Models;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Mapping
{
    /// <summary>
    /// Профиль автомаппера.
    /// </summary>
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {



            CreateMap<Tag, TagDto>();
            CreateMap<AdvertTag, TagDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(m => m.TagId))
                .ForMember(d => d.TagText, opt => opt.MapFrom(m => m.Tag.TagText));
            CreateMap<Category, CategoryDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Advertisement, AdvertisementDto>();
                //.ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Category != null ? s.Category.Id : (int?)null));
            CreateMap<CommentDto, Comment>()
                .ForMember(d => d.CommentDate, opt => opt.Ignore());
            CreateMap<AdvertisementDto, Advertisement>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Tags, opt => opt.Ignore())
                .ForMember(d => d.Comments, opt => opt.Ignore())
                .ForMember(d => d.Category, opt => opt.Ignore());
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryCreateDto, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Childs, opt => opt.Ignore())
                .ForMember(d => d.ParentCategory, opt => opt.Ignore());
            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Childs, opt => opt.Ignore())
                .ForMember(d => d.ParentCategory, opt => opt.Ignore());


        }
    }
}
