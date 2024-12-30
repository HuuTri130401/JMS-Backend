using Application.IRepository;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AppUnitOfWork : BaseUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public AppUnitOfWork(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override IGenericRepository<T> Repository<T>()
        {
            return new BaseDomainRepository<T>(_dbContext);
        }
    }
}
