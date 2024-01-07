using backend_dotnet.Core.Dtos.Auth;
using JwtAuth.Core.Dtos;
using JwtAuth.Core.Entities;
using JwtAuth.Core.Interfaces;
using JwtAuth.Core.OtherObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;

namespace JwtAuth.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // Route For Seeding My roles to DB
        [HttpPost]
        [Route("Semear Planos")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedRoles = await _authService.SeedPlansAsync();

            return Ok(seedRoles);
        }

        // Route For Registering
        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> Register([FromBody] RegisterDto resgisterDto)
        {
            var registerResult = await _authService.ResgisterAsync(resgisterDto);

            if (registerResult.IsSuccess)
                return Ok(registerResult);

            return BadRequest(registerResult);
        }

        // Route For login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var loginResult = await _authService.LoginAsync(loginDto);

            if (loginResult.IsSuccess)
                return Ok(loginResult);
            return BadRequest(loginResult);
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<UserInfoResult>>> GetUsersList()
        {
            var users = await _authService.GetUsersListAsync();
            return Ok(users);
        }


        ////opção que pode ser acessada para efetuar pagamento e se tornar gold
        //[HttpPost]
        //[Route("mudar-gold")]
        //public async Task<IActionResult> ChangeGold([FromBody] UpdatePermissionDto updatePermissionDto)
        //{
        //    var makeGoldResult = await _authService.ChangeGoldAsync(updatePermissionDto);

        //    if (makeGoldResult.IsSuccess)
        //        return Ok(makeGoldResult);
        //    return BadRequest(makeGoldResult);
        //}

        ////opção que pode ser acessada para efetuar pagamento e se tornar deluxe
        //[HttpPost]
        //[Route("make-deluxe")]
        //public async Task<IActionResult> ChangeDeluxe([FromBody] UpdatePermissionDto updatePermissionDto)
        //{
        //    var makeDeluxeResult = await _authService.ChangeDeluxeAsync(updatePermissionDto);

        //    if (makeDeluxeResult.IsSuccess)
        //        return Ok(makeDeluxeResult);
        //    return BadRequest(makeDeluxeResult);
        //}
    }
}
