using ECO.Application.DTOs.Auth;
using ECO.Application.DTOs.Response;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using ECO.Infrastructure.MailHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    public class UserController : BaseAPIController
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UserController(UserManager<AppUser> userManager, IEmailService emailService, IUserService userService, IJwtService jwtService) : base(userManager)
        {
            _userService = userService;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var appUser = await _userService.Login(loginDTO.Email, loginDTO.Password);
                return Ok(appUser);
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

        [HttpPost]
        public async Task<IActionResult> SendEmailTest(MailModel mailModel)
        {
            try
            {
                await _emailService.SendEmailAsync(mailModel);
                return Ok(new 
                {
                    Code = 200,
                    Message = "OK",
                    IsSucceed = true,
                    Data = "Email đã được gửi thành công"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            try
            {
                var userId = User?.Identity?.Name ?? "";
                return Ok(await _userService.GetCurrentUser(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
