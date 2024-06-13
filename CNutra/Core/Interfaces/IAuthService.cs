using backend_dotnet.Core.Dtos.Auth;
using JwtAuth.Core.Dtos;

namespace JwtAuth.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthServiceResponseDto> SeedPlansAsync();
        Task<AuthServiceResponseDto> ResgisterAsync(RegisterDto registerDto);
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<IEnumerable<UserInfoResult>> GetUsersListAsync();

        //Task<AuthServiceResponseDto> ChangePlanAsync(UpdatePermissionDto updatePermissionDto);
        
        
        //Task<AuthServiceResponseDto> ChangeGoldAsync(UpdatePermissionDto updatePermissionDto);
        //Task<AuthServiceResponseDto> ChangeDeluxeAsync(UpdatePermissionDto updatePermissionDto);
    }
}
