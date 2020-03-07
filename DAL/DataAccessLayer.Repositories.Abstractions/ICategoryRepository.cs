using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        void Create(Category item);
        Category FindById(int id);
        IEnumerable<Category> Get();
        IEnumerable<Category> Get(Func<Category, bool> predicate);
        void Remove(Category item);
        void Update(Category item);
    }
}
