using AutoMapper;
using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services.Contracts;
using BusinessLogic.Services.Contracts.Models;
using BusinessLogic.Services.Validators;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;


        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult<bool>> Create(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    throw new ArgumentNullException(nameof(categoryDto));
                }

                Category entity = _mapper.Map<Category>(categoryDto);
                await _categoryRepository.Add(entity);
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failed(new[] { e.Message });
            }
            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<ICollection<CategoryDto>>> GetPaged(int page, int pageSize)
        {
            ICollection<CategoryDto> entitiesDto;
            try
            {
                if (page == 0)
                {
                    throw new ArgumentNullException(nameof(page));
                }
                if (pageSize == 0)
                {
                    throw new ArgumentNullException(nameof(pageSize));
                }
                ICollection<Category> entities = await _categoryRepository.GetPaged(page, pageSize);
                entitiesDto = _mapper.Map<ICollection<CategoryDto>>(entities);
            }
            catch (Exception e)
            {

                return OperationResult<ICollection<CategoryDto>>.Failed(new[] { e.Message });
            }


            return OperationResult<ICollection<CategoryDto>>.Ok(entitiesDto);
        }

        public async Task<OperationResult<CategoryDto>> GetById(int id)
        {
            CategoryDto categoryDto;
            try
            {

                if (id == 0)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                Category entity = await _categoryRepository.GetById(id);
                categoryDto = _mapper.Map<CategoryDto>(entity);

            }
            catch (Exception e)
            {
                return OperationResult<CategoryDto>.Failed(new[] { e.Message });
            }

            return OperationResult<CategoryDto>.Ok(categoryDto);
        }

        public async Task<OperationResult<bool>> Update(CategoryDto categoryDto)
        {
            try
            {
                var category = await _categoryRepository.GetById(categoryDto.Id);
                _mapper.Map<CategoryDto, Category>(categoryDto, category);

                await _categoryRepository.Update(category);
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failed(new[] { e.Message });
            }
            return OperationResult<bool>.Ok(true);
        }

        public async Task<OperationResult<bool>> Delete(int id)
        {
            try
            {
                await _categoryRepository.Delete(id);
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failed(new[] { e.Message });
            }
            return OperationResult<bool>.Ok(true);
        }

    }
}
