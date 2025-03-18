using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.Authentication;
using Microsoft.AspNetCore.Authorization;
using E_LearningPlatform.Models;


namespace E_LearningPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication jwtAuth;

        public AuthenticationController(IAuthentication jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }

        [AllowAnonymous]
        [HttpPost("Authentication")]
        public IActionResult Authentication([FromBody] User user)
        {
            var token = jwtAuth.Authenticate(user.Email, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }
           
            return Ok(token);
        }
    }
}
