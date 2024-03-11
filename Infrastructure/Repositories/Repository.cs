using Infrastructure.Context.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Queries;
using Npgsql;

namespace Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int? id)
        {
            return await _entities.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }

        public virtual async Task<bool> InsertAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        protected async Task<List<T>> CustomQuery(string connectionString, string queryString, Func<NpgsqlDataReader, List<T>> funcResult)
        {
            using (NpgsqlConnection connection = new(connectionString))
            {
                NpgsqlCommand command = new(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                try
                {
                    List<T> resultList = funcResult(reader);
                    return resultList;
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
        }
    }
}
