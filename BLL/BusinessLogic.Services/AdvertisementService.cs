using BusinessLogic.Services.Abstractions;
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
            _adverttagRepository = adverttagRepository;
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
            AdvertisementDto entityDto;

            try
            {

                Advertisement entity = await _advertisementRepository.GetById(id);

                if (entity == null)
                {
                    throw new EntityNotFoundException(id, "Объявление");
                }

                entityDto = _mapper.Map<AdvertisementDto>(entity);

                var entityAdvertTag = await _adverttagRepository.GetById(id);

                int TagIndex = 0;


                Tag _tagentity;
                TagDto _tagdtoentity;

                entityDto.Tags = new List<TagDto>();

                foreach (var advtag in entityAdvertTag)
                {
                    TagIndex = advtag.TagId;
                    _tagentity = await _tagRepository.GetById(TagIndex);
                    _tagdtoentity = _mapper.Map<TagDto>(_tagentity);
                    entityDto.Tags.Add(_tagdtoentity);
                }
            }
            catch (Exception e)
            {
                return OperationResult<AdvertisementDto>.Failed(new[] {e.Message});
            }

            return OperationResult<AdvertisementDto>.Ok(entityDto);
        }

  

        public async Task<OperationResult<bool>>Create(AdvertisementDto advertisementDto)
        {
            try
            {
                if (advertisementDto == null)
                {
                    throw new ArgumentNullException(nameof(advertisementDto));
                }
                Advertisement entity = _mapper.Map<Advertisement>(advertisementDto);
                int dvertisement_dbId = await _advertisementRepository.Add(entity);

                // Если из UI пришли tag, иначе ничего не делаем
                if(advertisementDto.Tags.Count()  > 0)
                {
                    var _adverttag = _mapper.Map<AdvertTag>(advertisementDto.Tags.Last());
                    _adverttag.AdvertId = dvertisement_dbId;

                    //int tag_dbId;
                    foreach (var tagDto in advertisementDto.Tags)
                    {
                        _adverttag.TagId = await _tagRepository.Add(_mapper.Map<Tag>(tagDto));
                        await _adverttagRepository.Add(_adverttag);
                    }
                }
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

                //Advertisement entity = _mapper.Map<Advertisement>(advertisementDto);


                // int dvertisement_dbId = await _advertisementRepository.Add(entity);
                int dvertisement_dbId = advertisementDto.Id;


                // Удаляем старые связи
                await _adverttagRepository.Delete(dvertisement_dbId);


                // Если из UI пришли tag, иначе ничего не делаем
                if (advertisementDto.Tags.Count() > 0)
                {
                    var _adverttag = _mapper.Map<AdvertTag>(advertisementDto.Tags.Last());
                    _adverttag.AdvertId = dvertisement_dbId;

                    //int tag_dbId;
                    foreach (var tagDto in advertisementDto.Tags)
                    {
                        _adverttag.TagId = await _tagRepository.Add(_mapper.Map<Tag>(tagDto));
                        await _adverttagRepository.Add(_adverttag);
                    }
                }


                await _advertisementRepository.Update(advert);
                //await _advertisementRepository.Update(entity);

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
                // Удаляем старые связи
                await _adverttagRepository.Delete(id);

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

        public async Task<OperationResult<AdvertisementDto>> GetAllTags()
        {
            AdvertisementDto entityDto;

            try
            {

                //Advertisement entity = await _advertisementRepository.GetById(36);

                Advertisement entity = new Advertisement();

               entityDto = _mapper.Map<AdvertisementDto>(entity);

               // var entityAdvertTag = await _adverttagRepository.GetById(36);

               // int TagIndex = 0;


               // Tag _tagentity;
                TagDto _tagdtoentity;

                ICollection<Tag> TagsEnt;
                TagsEnt = await _tagRepository.GetAll();
                entityDto.Tags = new List<TagDto>();
                foreach (var alltag in TagsEnt)
                {
                    _tagdtoentity = _mapper.Map<TagDto>(alltag);
                    entityDto.Tags.Add(_tagdtoentity);
                }
            }
            catch (Exception e)
            {
                return OperationResult<AdvertisementDto>.Failed(new[] { e.Message });
            }

            return OperationResult<AdvertisementDto>.Ok(entityDto);
        }


    }
}
