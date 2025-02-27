using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface ITokenService<TEntity> where TEntity : class
    {
        Task<string> EncodeAsync(Guid userId, string email, TimeSpan expiryDuration);
        Task RevokeAsync(string token);
      
        Task<Token> CreateTokenAsync(User user);
    }
}
