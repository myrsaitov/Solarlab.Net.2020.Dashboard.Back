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
    public class CommentsRepository : ICommentsRepository
    {
        private readonly Context.Context _context;
        DbSet<Comments> _dbSet;

        public CommentsRepository(Context.Context context)
        {
            _context = context;
            _dbSet = context.Set<Comments>();
        }

        public void Create(Comments item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// Получить по id
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<Comments> GetById(int commentId)
        {
            return await _context.Set<Comments>().FindAsync(commentId);
        }



        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="comments"></param>
        /// <returns></returns>
        public async Task Add(Comments comments)
        {
            await _context.Comments.AddAsync(comments);
        }

        public async Task Remove(Comments item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить 
        /// </summary>
        /// <param name="item"></param>
        public async Task Update(Comments item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



        /// <summary>
        /// Удалить 
        /// </summary>
        /// <param name="commentsId"></param>
        /// <returns></returns>
        public async Task Delete(int commentsId)
        {
            var comments = await _context.Comments.FindAsync(commentsId);
            if (comments != null)
            {
                _context.Comments.Remove(comments);
            }
        }


    }
}
