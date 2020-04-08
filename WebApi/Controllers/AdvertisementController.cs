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
using WebApi.Models.Advertisements;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Comments;

namespace WebApi.Controllers
{
    /// <summary>
    /// Контроллер объявлений
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        readonly IAdvertisementService _advertisementService;
        readonly IMapper _mapper;

        public AdvertisementController(IAdvertisementService advertisementService, IMapper mapper)
        {
            _advertisementService = advertisementService;
            _mapper = mapper;
        }



        /// <summary>
        /// Получить объявление
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>IActionResult</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Range(1, Int32.MaxValue)]int id)
        {
            var operationResult = await _advertisementService.GetById(id);
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }



        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="advertisementModel">модель объявления</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Required]AdvertisementCreateModel advertisementModel)
        {
            var operationResult = await _advertisementService.Create(_mapper.Map<AdvertisementDto>(advertisementModel));
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }








        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="id">идентификтор</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([Range(1, Int32.MaxValue)]int id)
        {
            var operationResult = await _advertisementService.Delete(id);
            if (!operationResult.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, operationResult.GetErrors());
            }
            return Ok(operationResult.Result);
        }

        /// <summary>
        /// Получить список объявлений
        /// </summary>
        /// <param name="page">страница</param>
        /// <param name="pageSize">размер страницы</param>
        /// <param name="categoryId">идентификатор категории</param>
        /// <returns></returns>
        [HttpGet("List/{page}/{pageSize}/{categoryId}")]
        public async Task<IActionResult> GetPaged(int page, int pageSize, int? categoryId)
        {
            return Ok(); //TODO: закончить
        }

        //тот же GetPaged лучше сделать так:              
        /*
        [HttpGet("List")]
        public async Task<IActionResult> GetPaged(
            [FromQuery]int page,
            [FromQuery]int pageSize,
            [FromQuery]int? categoryId)
        {
            return Ok(); //TODO: закончить
        }
        */

        /// <summary>
        /// Добавить коментарий
        /// </summary>
        /// <param name="commentModel">модель коментария</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{id}/Comment")]
        public async Task<IActionResult> AddComment(CommentModel commentModel)
        {
            return Ok(); //TODO: закончить
        }


        
    }
}