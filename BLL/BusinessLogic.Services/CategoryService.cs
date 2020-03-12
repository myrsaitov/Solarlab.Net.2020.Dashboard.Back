using AutoMapper;
using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services.Contracts;
using BusinessLogic.Services.Contracts.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        

        public CategoryService (IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult<bool>> Create(CategoryDto categoryDto)
        {
            try
            {
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
            ICollection<Category> entities = await _categoryRepository.GetPaged(page, pageSize);

            return OperationResult<ICollection<CategoryDto>>.Ok(_mapper.Map<ICollection<CategoryDto>>(entities));
        }

        public async Task<OperationResult<CategoryDto>> GetById(int id)
        {
            Category entity = await _categoryRepository.GetById(id);
            return OperationResult<CategoryDto>.Ok(_mapper.Map<CategoryDto>(entity));
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
