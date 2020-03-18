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
    public class CommentRepository : ICommentRepository
    {
        private readonly Context.Context _context;
        DbSet<Comment> _dbSet;

        public CommentRepository(Context.Context context)
        {
            _context = context;
            _dbSet = context.Set<Comment>();
        }

        public void Create(Comment item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        /// <summary>
        /// Получить по id
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task<Comment> GetById(int commentId)
        {
            return await _context.Set<Comment>().FindAsync(commentId);
        }



        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task Add(Comment comment)
        {
            await _context.Comment.AddAsync(comment);
        }

        public async Task Remove(Comment item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить 
        /// </summary>
        /// <param name="item"></param>
        public async Task Update(Comment item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



        /// <summary>
        /// Удалить 
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns></returns>
        public async Task Delete(int commentId)
        {
            var comment = await _context.Comment.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comment.Remove(comment);
            }
        }


    }
}
