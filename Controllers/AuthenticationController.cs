// using System;
// using System.Collections.Generic;
// using System.IdentityModel.Tokens.Jwt;
// using System.Linq;
// using System.Security.Claims;
// using System.Text;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;



// [ApiController]
//     [Route("/api/v1/auth")]
//     public class AuthController : ControllerBase
//     {
//         private readonly AuthService _authService;
//         public AuthController(AuthService authService)
//         {
//             _authService = authService;
//         }

//         [HttpPost("register")]
//         public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
//         {
//             var result = await _authService.RegisterUserService(userRegisterDto);
//             return Created("", result);
//         }

//         [HttpPost("login")]
//         public async Task<IActionResult> Login(UserLoginDto userLoginDto)
//         {
//             var token = await _authService.LoginService(userLoginDto);
//             return Created("", new { Token = token });
//         }

        
//     }
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("/api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
    {
        var result = await _authService.RegisterUserService(userRegisterDto);
        return Ok(new { message = result });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        var token = await _authService.LoginService(userLoginDto);
        if (token == "Invalid email or password")
        {
            return Unauthorized(new { message = token });
        }
        return Ok(new { token = token });
    }
}
