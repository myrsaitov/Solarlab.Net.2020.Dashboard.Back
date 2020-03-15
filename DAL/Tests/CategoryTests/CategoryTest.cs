using AutoMapper;
using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services.Mapping;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CategoryTests
{
    class CategoryTest
    {
    }

    public class CreateCategoryTest
    {
        private readonly IMapper _mapper;
        private Mock<ICategoryRepository> _CategoryRepository = new Mock<ICategoryRepository>();
        private ICategoryService _categoryService;
       
        public CreateCategoryTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceMappings());
            });
            _mapper = mockMapper.CreateMapper();

            Category category = new Category()
            {
                Id = 1,
                Name = "АвтоМото",
            };
           
            //Настройка moq - объекта
            _CategoryRepository.Setup(_ => _.GetById(It.IsAny<int>())).ReturnsAsync(category);
            _categoryService = new BusinessLogic.Services.CategoryService (
                _mapper,
                _CategoryRepository.Object);
        }

        [Fact]
        public void ValidateCategoryName_EmptyName_Negative()
        {
            BusinessLogic.Services.Contracts.Models.CategoryDto emptyNameCategory = new BusinessLogic.Services.Contracts.Models.CategoryDto();
            var result = _categoryService.Create (emptyNameCategory);
            Assert.False(result.Result.Success);
            Assert.Equal(new[] { "CategoryDto поле Name не заполнено" }, result.Result.Errors);
        }
    }
}
