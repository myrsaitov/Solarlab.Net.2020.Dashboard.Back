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
        public async Task<IActionResult> Create(CategoryModel categoryModel)
        {
            var operationResult = await _categoryService.Create(_mapper.Map<CategoryDto>(categoryModel));
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        [HttpGet("List/{page}/{pageSize}/{categoryId}")]
        public async Task<ActionResult> GetPaged(int page, int pageSize)
        {
            var operationResult = await _categoryService.GetPaged(page, pageSize);
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var operationResult = await _categoryService.GetById(id);
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CategoryModel categoryModel)
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