using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araujo.Library.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AraujoDbContext _dbContext;
        public BaseRepository(AraujoDbContext araujoLibrary)
        {
            _dbContext = araujoLibrary;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
