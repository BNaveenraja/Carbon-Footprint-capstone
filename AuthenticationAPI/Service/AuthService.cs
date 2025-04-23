using AuthenticationAPI.Data;
using AuthenticationAPI.Models;
using AuthenticationAPI.Models.DTO;
using AuthenticationAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MicroServicesExample.Services.AuthApi.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public AuthService(UserDbContext db, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
            _roleManager = roleManager;
        }

        public Task<List<UserDto>> GetUsers()
        {

            return _db.Users
       .Select(user => new UserDto
       {
           Id = user.Id,
           Name = user.UserName,
           Email = user.Email,
           PhoneNumber = user.PhoneNumber
       })
       .ToListAsync();
        }
        public Task<List<ApplicationRole>> GetRoles()
        {
            return _db.Roles.ToListAsync();
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUser.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }
            var role = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, role);
            UserDto userDto = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.UserName,
                PhoneNumber = user.PhoneNumber,
            };
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token,
                role = role[0]
            };
            return loginResponseDto;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                PhoneNumber = registrationRequestDto.PhoneNumber
                // You can add other properties here if your ApplicationUser has them
                // For example: Name = registrationRequestDto.Name (if 'Name' exists in ApplicationUser)
            };

            try
            {
                // Create the user with password
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

                if (result.Succeeded)
                {
                    // Determine role based on email domain
                    string roleName = user.NormalizedEmail.EndsWith("@ADMINECO.COM") ? "Admin" : "User";

                    // Check if role exists, if not, create it
                    if (!await _roleManager.RoleExistsAsync(roleName))
                    {
                        await _roleManager.CreateAsync(new ApplicationRole { Name = roleName });
                    }

                    // Add user to the role
                    await _userManager.AddToRoleAsync(user, roleName);

                    return ""; // success
                }
                else
                {
                    // Return the first error from Identity if creation fails
                    return result.Errors.FirstOrDefault()?.Description ?? "Unknown error during user creation.";
                }
            }
            catch (Exception ex)
            {
                // Return exception message for debugging
                return ex.InnerException?.Message ?? ex.Message;
            }
        }


        public async Task<UserDto> UpdateProfile(int userid, UpdateRequestDto updateRequestDto)
        {

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userid);
            if (user != null)
            {
                user.UserName = updateRequestDto.Email;
                user.Email = updateRequestDto.Email;
                user.NormalizedEmail = updateRequestDto.Email.ToUpper();
                user.UserName = updateRequestDto.Name;
                user.PhoneNumber = updateRequestDto.PhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    UserDto userResponse = new UserDto()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Name = user.UserName,
                        PhoneNumber = user.PhoneNumber
                    };
                    return userResponse;
                }
            }
            return null;
        }
    }
}
