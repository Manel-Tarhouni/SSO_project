using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class

    {
        private readonly AMContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AMContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

    
        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;  
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            var entities = _dbSet.Where(where);
            _dbSet.RemoveRange(entities);
            await Task.CompletedTask;  
        }

       
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

   
        public async Task<TEntity> GetByIdAsync(params object[] keyValues)
        {
            return await _dbSet.FindAsync(keyValues);
        }

        
        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> mydbset = _dbSet;
            if (where != null)
                mydbset = mydbset.Where(where);

            return await mydbset.ToListAsync();
        }


        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<TEntity> GetByEmailAsync(string email)
        {
            if (typeof(TEntity) == typeof(User))
            {
                var userDbSet = _context.Set<User>();
                return await userDbSet.FirstOrDefaultAsync(u => u.Email == email) as TEntity;
            }
            return null;
        }

    }
}
