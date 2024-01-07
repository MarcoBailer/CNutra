using backend_dotnet.Core.Dtos.Auth;
using JwtAuth.Core.Dtos;
using JwtAuth.Core.Entities;
using JwtAuth.Core.Interfaces;
using JwtAuth.Core.OtherObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuth.Core.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user is null)
                return new AuthServiceResponseDto()
                {
                    IsSuccess = false,
                    Message = "Credenciais Inválidas"
                };

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordCorrect)
                return new AuthServiceResponseDto()
                {
                    IsSuccess = false,
                    Message = "Credenciais Inválidas"
                };

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
            };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GenerateJwtToken(authClaims);

            return new AuthServiceResponseDto()
            {
                IsSuccess = true,
                Message = token
            };
        }


        public async Task<AuthServiceResponseDto> ResgisterAsync(RegisterDto registerDto)
        {
            var isExistsUser = await _userManager.FindByNameAsync(registerDto.UserName);

            if (isExistsUser != null)
                return new AuthServiceResponseDto()
                {
                    IsSuccess = false,
                    Message = "Usuário já existe"
                };

            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                PhoneNumber = registerDto.Phone.ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerDto.Password);

            if (!createUserResult.Succeeded)
            {
                var errorString = "Falha ao cria usuário - motivo : ";
                foreach (var error in createUserResult.Errors)
                {
                    errorString += " # " + error.Description;
                }
                return new AuthServiceResponseDto()
                {
                    IsSuccess = false,
                    Message = errorString
                };
            }

            // Add a Default USER to all users
            await _userManager.AddToRoleAsync(newUser, StaticUserPlan.STANDARD);

            return new AuthServiceResponseDto()
            {
                IsSuccess = true,
                Message = "Usuário criado com sucesso",
                Plano = StaticUserPlan.STANDARD
            };
        }

        public async Task<AuthServiceResponseDto> SeedPlansAsync()
        {
            bool isDeluxePlanExist = await _roleManager.RoleExistsAsync(StaticUserPlan.DELUXE);
            bool isGoldPlanExist = await _roleManager.RoleExistsAsync(StaticUserPlan.GOLD);
            bool isStandardPlanExist = await _roleManager.RoleExistsAsync(StaticUserPlan.STANDARD);

            if (isDeluxePlanExist && isGoldPlanExist && isStandardPlanExist)
                return new AuthServiceResponseDto()
                {
                    IsSuccess = true,
                    Message = "Semento de Role já feito"
                };

            await _roleManager.CreateAsync(new IdentityRole(StaticUserPlan.STANDARD));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserPlan.GOLD));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserPlan.DELUXE));

            return new AuthServiceResponseDto()
            {
                IsSuccess = true,
                Message = "Semeamento de Planos feito com sucesso"
            };
        }

        public async Task<IEnumerable<UserInfoResult>> GetUsersListAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            List<UserInfoResult> userInfoResults = new List<UserInfoResult>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userInfo = GenerateUserInfoObject(user, roles);
                userInfoResults.Add(userInfo);
            }

            return userInfoResults;
        }

        private UserInfoResult GenerateUserInfoObject(ApplicationUser user, IEnumerable<string> roles)
        {
            return new UserInfoResult()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
            };
        }

        //public async Task<AuthServiceResponseDto> ChangeGoldAsync(UpdatePermissionDto updatePermissionDto)
        //{
        //    var user = await _userManager.FindByNameAsync(updatePermissionDto.UserName);

        //    if (user is null)
        //        return new AuthServiceResponseDto()
        //        {
        //            IsSuccess = false,
        //            Message = "Nome de Usuario Inválido"
        //        };

        //    await _userManager.AddToRoleAsync(user, StaticUserRole.GOLD);

        //    return new AuthServiceResponseDto()
        //    {
        //        IsSuccess = true,
        //        Message = "Usuario agora possue plano gold"
        //    };
        //}

        //public async Task<AuthServiceResponseDto> ChangeDeluxeAsync(UpdatePermissionDto updatePermissionDto)
        //{
        //    var user = await _userManager.FindByNameAsync(updatePermissionDto.UserName);

        //    if (user is null)
        //        return new AuthServiceResponseDto()
        //        {
        //            IsSuccess = false,
        //            Message = "Nome de Usuario Inválido"
        //        };

        //    await _userManager.AddToRoleAsync(user, StaticUserRole.DELUXE);

        //    return new AuthServiceResponseDto()
        //    {
        //        IsSuccess = true,
        //        Message = "Usuario agora possue plano deluxe"
        //    };
        //}

        private string GenerateJwtToken(List<Claim> authClaims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenObject = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
                );

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);

            return token;
        }
    }
}
