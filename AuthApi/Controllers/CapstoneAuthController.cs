//using AuthApi.Model.DTO;
//using AuthApi.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace AuthApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthController : ControllerBase
//    {
//        private readonly IAuthService _authService;

//        public AuthController(IAuthService authService)
//        {
//            _authService = authService;
//        }

//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
//        {
//            var response = await _authService.RegisterAsync(model);
//            if (response.IsSuccess)
//                return Ok(response);
//            return BadRequest(response);
//        }
//    }
//}
