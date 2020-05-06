﻿using BusinessLogic.Services.Abstractions;
using BusinessLogic.Services.Contracts;
using BusinessLogic.Services.Contracts.Models;
using BusinessLogic.Services.Validators;
using DataAccess.Repositories.Abstractions;
using DataAccess.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using BusinessLogic.Contracts.CustomExceptions;




namespace BusinessLogic.Services
{
    /// <summary>
    /// Реализация сервиса работы с объявлениями
    /// </summary>
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAdvertTagRepository _adverttagRepository;

        public AdvertisementService(
            IMapper mapper,
            IAdvertisementRepository advertisementRepository,
            ICategoryRepository categoryRepository,
            ITagRepository tagRepository,
            IAdvertTagRepository adverttagRepository)
        {
            _mapper = mapper;
            _advertisementRepository = advertisementRepository;
            _categoryRepository = categoryRepository;
            _tagRepository = tagRepository;
        }

        /// <inheritdoc />
        public async Task<OperationResult<ICollection<AdvertisementDto>>> GetPaged(int? categoryId, int page, int pageSize)
        {
            ICollection<Advertisement> entities;
            if (categoryId.HasValue)
            {
                var categories = await _categoryRepository.GetAllChildIds(categoryId.Value);
                categories.Add(categoryId.Value);
                entities = await _advertisementRepository.GetPaged(categories.ToArray(), page, pageSize);
            }
            else
            {
                entities = await _advertisementRepository.GetPaged(page, pageSize);
            }
            return OperationResult<ICollection<AdvertisementDto>>.Ok(_mapper.Map<ICollection<AdvertisementDto>>(entities));
        }

        /// <inheritdoc />
        public async Task<OperationResult<AdvertisementDto>> GetById(int id)
        {
            Advertisement entity = await _advertisementRepository.GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(id, "Объявление");
            }
            return OperationResult<AdvertisementDto>.Ok(_mapper.Map<AdvertisementDto>(entity));
        }



        public async Task<OperationResult<bool>> Create(AdvertisementDto advertisementDto)
        {
            try
            {
                if (advertisementDto == null)
                {
                    throw new ArgumentNullException(nameof(advertisementDto));
                }

                //AdvertTag _adverttag;
                //_adverttag.AdvertId
                //await _advertagRepository.Add();
                int dbId;

                foreach (var tagDto in advertisementDto.Tags)
                {
                    dbId = await _tagRepository.Add(_mapper.Map<Tag>(tagDto));
                    
                }

                Advertisement entity = _mapper.Map<Advertisement>(advertisementDto);
                await _advertisementRepository.Add(entity);

            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failed(new[] { e.Message });
            }
            return OperationResult<bool>.Ok(true);
        }














        /// <inheritdoc />
        public async Task<OperationResult<bool>> Update(AdvertisementDto advertisementDto)
        {
            try
            {
                var advert = await _advertisementRepository.GetById(advertisementDto.Id);
                _mapper.Map<AdvertisementDto, Advertisement>(advertisementDto, advert);

                await _advertisementRepository.Update(advert);
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failed(new[] { e.Message });
            }
            return OperationResult<bool>.Ok(true);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> Delete(int id)
        {
            try
            {
                await _advertisementRepository.Delete(id);
            }
            catch (Exception e)
            {
                return OperationResult<bool>.Failed(new[] { e.Message });
            }
            return OperationResult<bool>.Ok(true);
        }

        /// <inheritdoc />
        public async Task<OperationResult<bool>> AddComment(int id, CommentDto commentDto)
        {
            CommentDtoValidator commentDtoValidator = new CommentDtoValidator();
            ValidationResult result = await commentDtoValidator.ValidateAsync(commentDto);
            if (!result.IsValid)
            {
                return OperationResult<bool>.Failed(result.Errors.Select(x => x.ErrorMessage).ToArray());
            }
            else
            {
                Comment comment = _mapper.Map<Comment>(commentDto);
                comment.CommentDate = DateTime.UtcNow;

                var advert = await _advertisementRepository.GetById(id);
                advert.Comments.Add(comment);

                await _advertisementRepository.Update(advert);
                return OperationResult<bool>.Ok(true);
            }
        }
    }
}
