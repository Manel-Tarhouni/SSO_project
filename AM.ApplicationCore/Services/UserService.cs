using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Requests;
using Microsoft.AspNetCore.Identity;

namespace AM.ApplicationCore.Services
{
    public class UserService : IUserService<User>
    {
        protected readonly IGenericRepository<User> _UserRepository;
        protected readonly ICustomPasswordHasher _PasswordHasher;

        private readonly UserManager<User> _userManager;
       

        public UserService(IGenericRepository<User> UserRepository,ICustomPasswordHasher passwordHasher, UserManager<User> userManager)
        {
            _UserRepository = UserRepository;
            _PasswordHasher = passwordHasher;
            _userManager = userManager;
        }


        public async Task<User> RegisterAsync(User user, string PasswordHash)
        {
            var result = await _userManager.CreateAsync(user, PasswordHash);
            if (result.Succeeded)
            {
                return user;
            }
            var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Registration failed: {errorMessage}");
            
        }




        /*   public async Task<User> RegisterAsync(User user)
           {
               var passwordHash = _PasswordHasher.Hash(user.Password);
               var user1 = new User

               {   Email=user.Email,
                   Firstname = user.Firstname,
                   Lastname = user.Lastname,
                   Password = passwordHash,

               };

             await _UserRepository.AddAsync(user);
             //  await _UserRepository.SaveChangesAsync(); 

               return user;
           }*/





        public async Task<User> LoginAsync(LoginRequest loginRequest)
        {
           var user=  await _UserRepository.GetByEmailAsync(loginRequest.email) ;
            if (user == null)
            {
                throw new Exception("Invalid login credentials. User not found.");
            } 
        /*   var result= _PasswordHasher.VerifyPassword(user.Password, loginRequest.password);
            if (result)
            {
                //generating tokens :p
            }
            else
            {
                throw new UnauthorizedAccessException("Invalid login credentials. Incorrect password.");

            }*/
            return user;
        }

        public Task LogoutAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
