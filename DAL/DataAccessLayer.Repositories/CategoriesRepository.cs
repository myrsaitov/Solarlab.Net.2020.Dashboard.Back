using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class CategoriesRepository : ICategoryRepository
    {
        DbContext _context;
        DbSet<Category> _dbSet;

        public CategoriesRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Category>();
        }

        public void Create(Category item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public Category FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<Category> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<Category> Get(Func<Category, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public void Remove(Category item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Category item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
