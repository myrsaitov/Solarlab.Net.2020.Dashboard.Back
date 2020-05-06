using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.Repositories
{

    public class AdvertTagRepository : IAdvertTagRepository
    {
        #region Private fields

        private readonly Context _dbContext;
        DbSet<AdvertTag> _dbSet;
        #endregion

        #region Ctor

        public AdvertTagRepository(Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<AdvertTag>();
        }


        #endregion

        #region IAdvertTagRepository implementation
        public void Create(AdvertTag item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }




        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<AdvertTag>> GetAll()
        {
            return await _dbContext.AdvertTags.AsNoTracking().ToArrayAsync();
        }


        /// <summary>
        /// Получить объявление по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<AdvertTag>> GetById(int id)
        {
            //// include
            //return _dbContext.AdvertTags
            //    .Include(x => x.Comments)
            //    .Include(x => x.Category)
            //    .SingleOrDefault(x => x.Id == id);
            //without include use only with lazyloading


            return await _dbContext.AdvertTags.Where(x => x.AdvertId == id).ToListAsync();
            
            //return await _dbContext.AdvertTags.FindAsync(id);
        }

        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="tag">Сущность для добавления</param>
        public async Task Add(AdvertTag tag)
        {
            await _dbContext.AdvertTags.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
        }



        public async Task Update(AdvertTag item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }



        /// <summary>
        /// Удалить объявление
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления</param>
        public async Task Delete(int id)
        {
            var entity = await _dbContext.AdvertTags.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.AdvertTags.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }


        #endregion
    }
}
