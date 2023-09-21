using FlipKart_Backend.DTO;
using FlipKart_Backend.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FlipKart_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] UserDTO user)
        {
            string token = _userService.LoginUser(user);
            if(token == "")
            {
                return Unauthorized();
            }
            return Ok(JsonSerializer.Serialize(token));
        }
    }
}
