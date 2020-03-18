using DataAccess.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContext
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly Context.Context _dbContext;

        public UnitOfWork(Context.Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
