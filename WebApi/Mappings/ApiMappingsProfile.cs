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
            CreateMap<CategoryModel, CategoryDto>();  
        }
    }
}
