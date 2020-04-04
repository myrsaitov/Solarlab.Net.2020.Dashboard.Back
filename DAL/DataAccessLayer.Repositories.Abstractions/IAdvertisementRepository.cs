using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория объявлений
    /// </summary>
    public interface IAdvertisementRepository
    {
        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Advertisement>> GetAll();

        /// <summary>
        /// Получить объявления постранично
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Количество записей на странице</param>
        /// <returns></returns>
        Task<ICollection<Advertisement>> GetPaged(int page, int pageSize);

        /// <summary>
        /// Получить объявления попадающие в категрии постранично
        /// </summary>
        /// <param name="categoriesId">Набор идентификаторов категорий</param>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Количество записей на странице</param>
        /// <returns></returns>
        Task<ICollection<Advertisement>> GetPaged(int[] categoriesId, int page, int pageSize);

        /// <summary>
        /// Получить объявление по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Advertisement> GetById(int id);

        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="advertisement">Сущность для добавления</param>
        Task Add(Advertisement advertisement);

        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="advertisement">Сущность для обновления</param>
        Task Update(Advertisement advertisement);

        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления</param>
        Task Delete(int id);
    }
}