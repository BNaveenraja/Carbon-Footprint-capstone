//using AuthApi.Data;
//using AuthApi.Model;
//using AuthApi.Model.DTO;
//using AuthApi.Services;
//using Microsoft.AspNetCore.Identity;

//public class AuthService : IAuthService
//{
//    private readonly AppDbContext db;
//    private readonly UserManager<ApplicationUser> userManager;

//    public AuthService(AppDbContext _db, UserManager<ApplicationUser> userManager)
//    {
//        db = _db;
//        this.userManager = userManager;
//    }

//    public async Task<UserDTO> Register(RegistrationRequestDTO requestDTO)
//    {
//        ApplicationUser user = new()
//        {
//            UserName = requestDTO.Email,
//            Email = requestDTO.Email,
//            NormalizedEmail = requestDTO.Email.ToUpper(),
//            Name = requestDTO.Name,
//            PhoneNumber = requestDTO.PhoneNumber,
//        };

//        try
//        {
//            var result = await userManager.CreateAsync(user, requestDTO.Password);
//            if (result.Succeeded)
//            {
//                var userToReturn = db.ApplicationUsers.First(u => u.UserName == requestDTO.Email);

//                UserDTO userDto = new()
//                {
//                    Email = userToReturn.Email,
//                    ID = userToReturn.Id,
//                    Name = userToReturn.Name,
//                    PhoneNumber = userToReturn.PhoneNumber
//                };

//                return userDto;
//            }
//            else
//            {
//                throw new Exception(result.Errors.FirstOrDefault()?.Description ?? "User creation failed.");
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new Exception("An error occurred during registration.", ex);
//        }
//    }

//    public async Task<LoginResponseDto> Login(LoginRequestDTO requestDTO)
//    {
//        var user = db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == requestDTO.UserName.ToLower());

//        if (user == null || !(await userManager.CheckPasswordAsync(user, requestDTO.Password)))
//        {
//            return new LoginResponseDto() { User = null, Token = "" };
//        }

//        UserDTO userDTO = new()
//        {
//            Email = user.Email,
//            ID = user.Id,
//            Name = user.Name,
//            PhoneNumber = user.PhoneNumber
//        };

//        LoginResponseDto loginResponseDto = new LoginResponseDto()
//        {
//            User = userDTO,
//            Token = ""
//        };

//        return loginResponseDto;
//    }
//}
