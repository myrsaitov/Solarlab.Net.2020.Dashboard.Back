﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstractions
{
    public interface IAdvertTagRepository
    {
        Task<ICollection<AdvertTag>> GetAll();
        Task<List<AdvertTag>> GetById(int tagId);
        Task Add(AdvertTag adverttag);
        Task Update(AdvertTag adverttag);
        Task Delete(int adverttagId);
        Task<int> GetTagsCountById(int tagId);
        Task<List<AdvertTag>> GetAdvById(int? tagId);
    }
}
