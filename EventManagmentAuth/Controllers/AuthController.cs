using EventManagmentAuth.Services.IService;
using EventsCore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagmentAuth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        protected ResponseDto _response = new();
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(SignUpDTO signUpDTO)
        {
            string res = await authService.Register(signUpDTO);
            if(res != "Success")
            {
                _response.IsSuccess = false;
                _response.Message = res;
                return BadRequest(_response);
            }

            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var res = await authService.Login(loginDTO);
            if(res.user == null){
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                BadRequest(_response);
            }
            _response.Result = res;
            return Ok(_response);
        }
        [HttpPost("assignrole")]
        public async Task<IActionResult>AssignRole(SignUpDTO signUpDTO)
        {
            var res = await authService.AssignRole(signUpDTO.email , signUpDTO.Role.ToLower().Trim());
            if (res == false)
            {
                _response.IsSuccess = false;
                _response.Message= "role false";
                return BadRequest(_response);   
            }
            return Ok(_response);
        }
    }
}
