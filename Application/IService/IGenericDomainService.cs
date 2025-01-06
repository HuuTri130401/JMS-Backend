using AutoMapper;
using Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.IService
{
    public interface IGenericDomainService<E, T> where E : BaseEntity where T : BaseSearch
    {
        Task<PagedList<E>> GetPagedListData(T baseSearch);
        Task<IList<E>> GetListAsync(Expression<Func<E, bool>> expression);
        Task<IList<E>> GetListAsync(Expression<Func<E, bool>> expression, Expression<Func<E, E>> select);
        IQueryable<E> Query { get; }
        Task<E> GetByIdAsync(Guid id);
        Task<E> GetByIdAsync(Guid id, IConfigurationProvider mapperConfiguration);
        Task<E> GetSingleAsync(Expression<Func<E, bool>> expression);
        Task<bool> CreateAsync(E item);
        Task<bool> CreateAsync(IList<E> items);
        Task<bool> UpdateAsync(E item);
        Task<bool> UpdateAsync(IList<E> items);
        Task<bool> UpdateFieldAsync(IList<E> items, params Expression<Func<E, object>>[] includeProperties);
        Task<bool> UpdateFieldAsync(E item, params Expression<Func<E, object>>[] includeProperties);
        Task<bool> DeleteAsync(Guid id);
        Task<E> DeleteDataAsync(Guid id);
    }
}
