using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IRoleService<TEntity> where TEntity : class
    {
        Task AddRoleAsync(Role role); 
        Task UpdateRoleAsync(Role role); 
        Task DeleteRoleAsync(Role role); 
        Task<Role> GetRoleByIdAsync(Guid roleId); 
        Task<Role> GetRoleAsync(Expression<Func<Role, bool>> predicate); 
        Task<IEnumerable<Role>> GetAllRolesAsync(); 
        Task<IEnumerable<Role>> GetRolesAsync(Expression<Func<Role, bool>> predicate);
    }
}
