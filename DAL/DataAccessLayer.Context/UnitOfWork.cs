using DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;

        public UnitOfWork(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
