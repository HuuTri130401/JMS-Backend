using Domain.BaseEntities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.IRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetQueryable();
        void Create(T entity);
        Task CreateAsync(T entity);
        void Create(IList<T> entities);
        Task CreateAsync(IList<T> entities);
        void Update(T entity);
        void Update(List<T> entities);
        void Delete(T entity);
        void Delete(IList<T> entities);
        void SetEntityState(T item, EntityState entityState);
        EntityEntry<T> Entry(T item);
        Task<PagedList<T>> ExcuteQueryPagingAsync(string commandText, SqlParameter[] sqlParameters);
        Task<T> ExecuteQueryAsync(string commandText, Guid id);
        bool UpdateFieldsSave(T entity, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> UpdateFieldsSaveAsync(T entity, params Expression<Func<T, object>>[] includeProperties);
    }
}
