using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class RoleService<TEntity>: IRoleService <TEntity> where TEntity : class
    {
        private readonly IGenericRepository<Role> _roleRepository;
        public RoleService(IGenericRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task AddRoleAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveChangesAsync(); 
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
            await _roleRepository.SaveChangesAsync(); 
        }

        public async Task DeleteRoleAsync(Role role)
        {
            await _roleRepository.DeleteAsync(role);
            await _roleRepository.SaveChangesAsync(); 
        }

      
        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            return await _roleRepository.GetByIdAsync(roleId);
        }

        
        public async Task<Role> GetRoleAsync(Expression<Func<Role, bool>> predicate)
        {
            return await _roleRepository.GetAsync(predicate);
        }

       
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

      
        public async Task<IEnumerable<Role>> GetRolesAsync(Expression<Func<Role, bool>> predicate)
        {
            return await _roleRepository.GetManyAsync(predicate);
        }
    }
}


