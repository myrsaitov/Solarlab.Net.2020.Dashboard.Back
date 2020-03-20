using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstractions
{
    public interface IAdvertisementRepository
    {



        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="advertisementId">Идентификатор сущности</param>
        /// <returns></returns>
        Task<Advertisement> GetById(int advertisementId);



        /// <summary>
        /// Добавить 
        /// </summary>
        /// <param name="advertisement">Сущность для добавления</param>
        /// <returns></returns>
        Task Add(Advertisement advertisement);

        /// <summary>
        /// Обновить 
        /// </summary>
        /// <param name="advertisement">Сущность для обновления</param>
        /// <returns></returns>
        Task Update(Advertisement advertisement);

        /// <summary>
        /// Удалить категорию
        /// </summary>
        /// <param name="advertisementId">Идентификатор категории для удаления</param>
        /// <returns></returns>
        Task Delete(int advertisementId);

        /// <summary>
        /// Получить постранично
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Количество записей на странице</param>
        /// <returns></returns>
        Task<ICollection<Advertisement>> GetPaged(int page, int pageSize);



    }
}
