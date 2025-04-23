using AuthenticationAPI.Models;
using AuthenticationAPI.Models.DTO;

namespace AuthenticationAPI.Service.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<UserDto> UpdateProfile(int userId, UpdateRequestDto updateRequestDto);
        Task<List<UserDto>> GetUsers();
        Task<List<ApplicationRole>> GetRoles();

    }
}
