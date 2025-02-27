using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Requests;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Year_Project_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User> _userService;

        public UserController(IUserService<User> userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisteringRequest registerRequest)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = registerRequest.Email,
                    Email = registerRequest.Email,
                    Firstname = registerRequest.Firstname,
                    Lastname = registerRequest.Lastname
                };

                try
                {
                    // Call the RegisterAsync method from UserService
                    var registeredUser = await _userService.RegisterAsync(user, registerRequest.Password);

                    // Return a success response
                    return Ok(new
                    {
                        message = "Registration successful.",
                        user = registeredUser
                    });
                }
                catch (Exception ex)
                {
                    // Return an error response in case of failure
                    return BadRequest(new { message = "Registration failed", error = ex.Message });
                }
            }

            return BadRequest(ModelState);
        }
    }
}