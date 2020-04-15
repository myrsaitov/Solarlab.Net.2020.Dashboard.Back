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
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AbvertisementController : BaseController
    {
        readonly IAdvertisementService _advertisementService;
        readonly IMapper _mapper;

        public AbvertisementController(IAdvertisementService advertisementService, IMapper mapper) : base(mapper)
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
            return await ProcessOperationResult(async () => await _advertisementService.GetById(id));
        }

        /// <summary>
        /// Создать объявление
        /// </summary>
        /// <param name="model">модель</param>
        /// <returns>IActionResult</returns>
        [HttpPost]
        public async Task<IActionResult> Create([Required] AdvertisementCreateModel model)
        {
            return ProcessOperationResult(await _advertisementService.Create(Mapper.Map<AdvertisementDto>(model)));
        }

        /// <summary>
        /// Удалить объявление 
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Range(1, Int32.MaxValue)]int id)
        {
            return ProcessOperationResult(await _advertisementService.Delete(id));
        }

        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="model">модель</param>
        /// <returns>IActionResult</returns>
        [HttpPut]
        public async Task<IActionResult> Update([Required] AdvertisementUpdateModel model)
        {
            return ProcessOperationResult(await _advertisementService.Update(Mapper.Map<AdvertisementDto>(model)));
        }

        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="pageSize">объем страницы</param>
        /// <param name="categoryId">идентификатор страницы</param>
        /// <returns>IActionResult</returns>
        [HttpGet("list")]
        public async Task<IActionResult> GatPaged(
            [FromQuery, Required, Range(1, Int32.MaxValue)]int page,
            [FromQuery, Required, Range(1, Int32.MaxValue)]int pageSize,
            [FromQuery, Range(1, Int32.MaxValue)]int? categoryId)
        {
            return ProcessOperationResult(await _advertisementService.GetPaged(categoryId, page, pageSize));
        }

        /// <summary>
        /// Добавать комментарий
        /// </summary>
        /// <param name="advertisementId">идентификатор объявления</param>
        /// <param name="model">модель комментария</param>
        /// <returns>IActionResult</returns>
        [HttpPost("{advertisementId}/comments")]
        public async Task<IActionResult> AddComment(
            int advertisementId,
            [Required] AddCommentModel model)
        {
            return ProcessOperationResult(await _advertisementService.AddComment(advertisementId, Mapper.Map<CommentDto>(model)));
        }
    }
}