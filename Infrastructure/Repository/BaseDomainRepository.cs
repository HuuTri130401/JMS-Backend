using Application.IRepository;
using Domain.BaseEntities;
using Infrastructure.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Infrastructure.Repository
{
    public class BaseDomainRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseDomainRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual void SetEntityState(T item, EntityState entityState)
        {
            _context.Entry(item).State = entityState;
        }

        public virtual void Create(T entity)
        {
            var user = LoginContext.Instance.CurrentUser;
            if (user != null)
            {
                entity.CreatedBy = user.UserId;
            }
            _context.Set<T>().Add(entity);
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual void Create(IList<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public virtual async Task CreateAsync(IList<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public virtual void Update(T entity)
        {
            var user = LoginContext.Instance.CurrentUser;
            if (user != null)
            {
                entity.UpdatedBy = user.UserId;
            }
            _context.Set<T>().Update(entity);
        }

        public virtual bool UpdateFieldsSave(T entity, params Expression<Func<T, object>>[] includeProperties)
        {
            var dbEntry = _context.Entry(entity);

            foreach (var includeProperty in includeProperties)
            {
                dbEntry.Property(includeProperty).IsModified = true;
            }
            _context.SaveChanges();
            return true;
        }

        public virtual async Task<bool> UpdateFieldsSaveAsync(T entity, params Expression<Func<T, object>>[] includeProperties)
        {
            return await Task.Run(() =>
            {
                var dbEntry = _context.Entry(entity);

                foreach (var includeProperty in includeProperties)
                {
                    dbEntry.Property(includeProperty).IsModified = true;
                }
                _context.SaveChanges();
                return true;
            });
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Delete(IList<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public virtual IQueryable<T> GetQueryable()
        {
            return _context.Set<T>();
        }

        /// <summary>
        /// Lấy danh sách phân trang
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public virtual Task<PagedList<T>> ExcuteQueryPagingAsync(string commandText, SqlParameter[] sqlParameters)
        {
            return Task.Run(() =>
            {
                PagedList<T> pagedList = new PagedList<T>();
                DataTable dataTable = new DataTable();
                SqlConnection connection = null;
                SqlCommand command = null;
                try
                {
                    connection = (SqlConnection)_context.Database.GetDbConnection();
                    command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = commandText;
                    command.Parameters.AddRange(sqlParameters);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                    pagedList.Items = MappingDataTable.ConvertToList<T>(dataTable);
                    if (pagedList.Items != null && pagedList.Items.Any())
                        pagedList.TotalItem = pagedList.Items.FirstOrDefault().TotalItem;
                    return pagedList;
                }
                finally
                {
                    if (connection != null && connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    if (command != null)
                        command.Dispose();
                }
            });
        }

        public EntityEntry<T> Entry(T item)
        {
            EntityEntry<T> entityEntry = _context.Entry(item);
            return entityEntry;
        }

        public void Update(List<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }
    }
}
