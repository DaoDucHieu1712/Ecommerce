using ECO.Application.DTOs.Auth;
using ECO.Application.DTOs.Response;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    public class UserController : BaseAPIController
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        public UserController(UserManager<AppUser> userManager, IUserService userService, IJwtService jwtService) : base(userManager)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var appUser = await _userService.Login(loginDTO.Email, loginDTO.Password);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                await _userService.Register(registerDTO);
                return Ok("Đăng ký thành công !!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ServiceResponse GetUsersPagingTEST(DataRequest request)
        {
            ServiceResponse response = new();
            response.Onsuccess(_userService.GetUsersPaging(request));
            return response;
        }
    }
}
