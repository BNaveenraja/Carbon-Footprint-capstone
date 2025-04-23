using AuthenticationAPI.Models.DTO;
using AuthenticationAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace EcoLife.AuthAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetUsers()
        {
            _response.Result = await _authService.GetUsers();
            return Ok(_response);
        }


        [HttpGet("Roles")]
        public async Task<IActionResult> GetRoles()
        {
            _response.Result = await _authService.GetRoles();
            return Ok(_response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }


        [HttpPut("Update/{userid}")]
        public async Task<IActionResult> Update(int userid, UpdateRequestDto model)
        {
            _response.Result = await _authService.UpdateProfile(userid, model);
            if (_response.Result == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Error while updating";
                return BadRequest(_response);
            }

            _response.Message = "Updated profile";
            return Ok(_response);
        }

    }
}
