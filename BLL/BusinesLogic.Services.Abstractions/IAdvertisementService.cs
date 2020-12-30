using BusinessLogic.Services.Contracts;
using BusinessLogic.Services.Contracts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Abstractions
{

    /// <summary>
    /// Интерфейс сервиса работы с объявлениями
    /// </summary>
    public interface IAdvertisementService
    {
        /// <summary>
        /// Получение списка всех объявлений
        /// </summary>
        /// <returns>OperationResult</returns>
        Task<OperationResult<ICollection<AdvertisementDto>>> GetPaged(int? categoryId, int page, int pageSize);

        /// <summary>
        /// Получение объявления по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор существующего объявления</param>
        /// <returns>OperationResult</returns>
        Task<OperationResult<AdvertisementDto>> GetById(int id);

        Task<OperationResult<AdvertisementDto>> GetAllTags();

        /// <summary>
        /// Создание объявления
        /// </summary>
        /// <param name="advertisementDto">Объявление. Транспортный объект.</param>
        /// <returns>OperationResult</returns>
        Task<OperationResult<bool>> Create(AdvertisementDto advertisementDto);

        /// <summary>
        /// Изменение объявления
        /// </summary>
        /// <param name="advertisementDto">Объявление. Транспортный объект.</param>
        /// <returns>OperationResult</returns>
        Task<OperationResult<bool>> Update(AdvertisementDto advertisementDto);

        /// <summary>
        /// Удаление объявления
        /// </summary>
        /// <param name="id">Идентификатор существующего объявления</param>
        /// <returns>OperationResult</returns>
        Task<OperationResult<bool>> Delete(int id);

        /// <summary>
        /// Добавить комментарий к объявлению
        /// </summary>
        /// <param name="id"></param>
        /// <param name="commentDto"></param>
        /// <returns>OperationResult</returns>
        Task<OperationResult<bool>> AddComment(int id, CommentDto commentDto);


        Task<OperationResult<ICollection<AdvertisementDto>>> GetTagPaged(int? TagId, int page, int pageSize);
    }
}
