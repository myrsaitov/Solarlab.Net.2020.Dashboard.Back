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
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Childs, opt => opt.Ignore());
            //CreateMap<Comment, CommentDto>();

            CreateMap<Advertisement, AdvertisementDto>()
                .ForMember(d => d.Tags, opt => opt.Ignore());

           // CreateMap<CommentDto, Comment>()
                //.ForMember(d => d.CommentDate, opt => opt.Ignore());
            CreateMap<AdvertisementDto, Advertisement>()
                .ForMember(d => d.Id, opt => opt.Ignore())
                .ForMember(d => d.Tags, opt => opt.Ignore())
                //.ForMember(d => d.Comments, opt => opt.Ignore())
                .ForMember(d => d.Category, opt => opt.Ignore());

            
            CreateMap<CategoryDto, Category>()
                .ForMember(d => d.Childs, opt => opt.Ignore());

            CreateMap<CategoryCreateDto, Category>()
            .ForMember(d => d.ParentCategory, map => map.Ignore())
            .ForMember(d => d.Childs, map => map.Ignore());
        }
    }
}
