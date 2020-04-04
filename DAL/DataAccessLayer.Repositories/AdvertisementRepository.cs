using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
 
    public class AdvertisementRepository : IAdvertisementRepository
    {
        #region Private fields

        private readonly Context.Context _dbContext;

        #endregion

        #region Ctor

        public AdvertisementRepository(Context.Context dbContext)
        {
            _dbContext = dbContext;
        }


        #endregion

        #region IAdvertisementRepository implementation

        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Advertisement>> GetAll()
        {
            return await _dbContext.Advertisements.AsNoTracking().ToArrayAsync();
        }

        /// <summary>
        /// Получить объявления постранично
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Количество записей на странице</param>
        /// <returns></returns>
        public async Task<ICollection<Advertisement>> GetPaged(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _dbContext.Advertisements
                .Include(x => x.Comments)
                .Include(x => x.Category)
                //.Include(x => x.Category.ChildCategories)
                .Include(x => x.Category.ParentCategory)
                .Include(x => x.Tags)
                .AsNoTracking()
                .Skip(skip)
                .Take(pageSize)
                .ToArrayAsync();
        }

        /// <summary>
        /// Получить объявления попадающие в категрии постранично
        /// </summary>
        /// <param name="categoriesId">Набор идентификаторов категорий</param>
        /// <param name="page">Номер страницы</param>
        /// <param name="pageSize">Количество записей на странице</param>
        /// <returns></returns>
        public async Task<ICollection<Advertisement>> GetPaged(int[] categoriesId, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _dbContext.Advertisements
                .AsNoTracking()
                .Where(x => categoriesId.Contains(x.Category.Id))
                .Skip(skip)
                .Take(pageSize).ToArrayAsync();

        }

        /// <summary>
        /// Получить объявление по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Advertisement> GetById(int id)
        {
            //// include
            //return _dbContext.Advertisements
            //    .Include(x => x.Comments)
            //    .Include(x => x.Category)
            //    .SingleOrDefault(x => x.Id == id);
            //without include use only with lazyloading
            return await _dbContext.Advertisements.FindAsync(id);
        }

        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="advertisement">Сущность для добавления</param>
        public async Task Add(Advertisement advertisement)
        {
            await _dbContext.Advertisements.AddAsync(advertisement);
        }

        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="advertisement">Сущность для обновления</param>
        public Task Update(Advertisement advertisement)
        {
            _dbContext.Advertisements.Update(advertisement);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления</param>
        public async Task Delete(int id)
        {
            var entity = await _dbContext.Advertisements.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Advertisements.Remove(entity);
            }
        }


        #endregion
    }
}
