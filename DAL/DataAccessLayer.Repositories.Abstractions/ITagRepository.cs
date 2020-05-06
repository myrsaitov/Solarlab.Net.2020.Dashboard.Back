using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstractions
{
    public interface ITagRepository
    {
        Task<ICollection<Tag>> GetAll();
        Task<Tag> GetById(int tagId);
        Task Add(Tag tag);
        Task Update(Tag tag);
        Task Delete(int tagId);
    }
}
