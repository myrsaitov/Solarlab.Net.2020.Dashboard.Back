using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий с категориям
    /// </summary>
    public interface ICategoryRepository
    {
      
        Task<Category> GetById(int id);

        Task<ICollection<Category>> GetAll();

        Task Add(Category category);
        
        Task Update(Category category);
      
        Task Delete(int id);
    }
}