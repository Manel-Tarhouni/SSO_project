using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Requests;

namespace AM.ApplicationCore.Interfaces
{
    public interface IUserService<TEntity> where TEntity : class
    {
        Task<User> RegisterAsync(User user, string PasswordHash);
        Task<User> LoginAsync(LoginRequest loginRequest);
        Task LogoutAsync(Guid userId);
      //  Task<User> LoginWithExternalIdpAsync(string externalProvider, string externalIdpUserId);

    }
}
