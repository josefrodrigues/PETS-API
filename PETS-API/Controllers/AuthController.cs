using Microsoft.AspNetCore.Mvc;
using PETS_API.Domain.Models.PetAggregate;
using PETS_API.Application.Services;

namespace PETS_API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "admin" && password == "123456") 
            {
                var token = TokenService.GenerateToken(new Pet());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
