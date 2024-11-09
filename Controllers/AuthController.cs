using Microsoft.AspNetCore.Mvc;
using ColetaneaDiscos.Services;
//using Microsoft.AspNetCore.Identity.Data;
using ColetaneaDiscos.Models;

namespace ColetaneaDiscos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (IsValidUser(loginRequest))
            {
                var token = _tokenService.GenerateToken(loginRequest.UserId);
                return Ok(new {token });
            }

            return Unauthorized();
        }

        private bool IsValidUser(LoginRequest loginRequest)
        {
            //Verificar as credenciais do usuario
            return true;
        }

    }
}