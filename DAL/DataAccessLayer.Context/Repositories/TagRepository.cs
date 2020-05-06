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

    public class TagRepository : ITagRepository
    {
        #region Private fields

        private readonly Context _dbContext;
        DbSet<Tag> _dbSet;
        #endregion

        #region Ctor

        public TagRepository(Context dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<Tag>();
        }


        #endregion

        #region ITagRepository implementation
        public void Create(Tag item)
        {
            _dbSet.Add(item);
            _dbContext.SaveChanges();
        }




        /// <summary>
        /// Получить все объявления
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Tag>> GetAll()
        {
            return await _dbContext.Tags.AsNoTracking().ToArrayAsync();
        }


        /// <summary>
        /// Получить объявление по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Tag> GetById(int id)
        {
            //// include
            //return _dbContext.Tags
            //    .Include(x => x.Comments)
            //    .Include(x => x.Category)
            //    .SingleOrDefault(x => x.Id == id);
            //without include use only with lazyloading
            return await _dbContext.Tags.FindAsync(id);
        }

        /// <summary>
        /// Добавить объявление
        /// </summary>
        /// <param name="tag">Сущность для добавления</param>
        public async Task Add(Tag tag)
        {
            await _dbContext.Tags.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить объявление
        /// </summary>
        /// <param name="tag">Сущность для обновления</param>
        /*public Task Update(Tag tag)
        {
            _dbContext.Tags.Update(tag);
            return Task.CompletedTask;
        }*/

        public async Task Update(Tag item)
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
            var entity = await _dbContext.Tags.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.Tags.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }


        #endregion
    }
}
