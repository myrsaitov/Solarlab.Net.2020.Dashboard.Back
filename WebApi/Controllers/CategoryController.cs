using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services.Contracts;
using BusinessLogic.Services.Contracts.Models;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController (IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateModel categoryModel)
        {
            var operationResult = await _categoryService.Create(_mapper.Map<CategoryCreateDto>(categoryModel));
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        [HttpGet("List/{page}/{pageSize}")]
        public async Task<ActionResult> GetPaged(int page, int pageSize)
        {
            OperationResult <ICollection<CategoryDto>> operationResult;
            ICollection <CategoryGetModel> categoryGetModel;
            try
            {
                operationResult = await _categoryService.GetPaged (page, pageSize);
                if (!operationResult.Success)

                {
                    return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
                }
                categoryGetModel = _mapper.Map<ICollection<CategoryGetModel>>(operationResult.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return Ok(categoryGetModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            OperationResult<CategoryDto> operationResult;
            CategoryGetModel categoryGetModel;
            try 
            { 
                operationResult = await _categoryService.GetById(id);
                if (!operationResult.Success)

                {
                    return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
                }
                categoryGetModel = _mapper.Map<CategoryGetModel>(operationResult.Result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            return Ok(categoryGetModel);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CategoryUpdateModel categoryModel)
        {

            var operationResult = await _categoryService.Update(_mapper.Map<CategoryDto>(categoryModel));
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var operationResult = await _categoryService.Delete(id);
            if (!operationResult.Success)
            {
              return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);

        }
    }
}