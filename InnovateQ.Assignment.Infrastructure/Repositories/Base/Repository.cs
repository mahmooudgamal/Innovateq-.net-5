using InnovateQ.Assignment.Core.Repositories.Base;
using InnovateQ.Assignment.Infrastructure.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InnovateqContext _innovateqContext;

        public Repository(InnovateqContext innovateqContext)
        {
            _innovateqContext = innovateqContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _innovateqContext.Set<T>().AddAsync(entity);
            await _innovateqContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _innovateqContext.Set<T>().Remove(entity);
            await _innovateqContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _innovateqContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _innovateqContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _innovateqContext.Set<T>().Update(entity);
            await _innovateqContext.SaveChangesAsync();
        }
    }
}
