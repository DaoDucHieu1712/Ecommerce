using AutoMapper;
using ECO.Application.DTOs.Auth;
using ECO.Application.Repositories;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using ECO.Infrastructure.MailHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECO.Infrastructure.Services
{
    public class UserService : IUserService
    {

        protected readonly UserManager<AppUser> _userManager;
        protected readonly IJwtService _jwtService;
        private readonly ICartRepository _cartRepository;
        protected readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IJwtService jwtService, ICartRepository cartRepository, IConfiguration configuration, IEmailService emailService, IMapper mapper)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _cartRepository = cartRepository;
            _configuration = configuration;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<AppUser> Authenicate(string username, string password)
        {
            //var user = await _userManager.FindByNameAsync(username);
            //if (user != null)
            //{
            //    var claims = await _userManager.GetClaimsAsync(user);
            //    var hashedPassword = claims.First(e => e.Type.Equals("Password")).Value;
            //    // Compare password
            //    if (hashedPassword == HashPassword(password))
            //    {
            //        return user;
            //    }
            //}
            return null;
        }

        public async Task ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var _user = await _userManager.FindByEmailAsync(changePasswordDTO.Email);
            if (_user == null || !await _userManager.CheckPasswordAsync(_user, changePasswordDTO.OldPassword))
            {
                throw new Exception("Hãy kiểm tra lại mật khẩu hoặc email !!");
            }
            if (changePasswordDTO.NewPassword != changePasswordDTO.ConfirmPassword) throw new Exception("Xác nhận mật khẩu không khớp với mật khẩu !");

            await _userManager.ChangePasswordAsync(_user, changePasswordDTO.OldPassword, changePasswordDTO.NewPassword);

        }

        public async Task ForgetPassword(string email)
        {
            var _user = await _userManager.FindByEmailAsync(email);
            if (_user == null) throw new Exception("Email không tồn tại !!");
            var token = await _userManager.GeneratePasswordResetTokenAsync(_user);
            var resetPasswordLink = "http://localhost:3000/reset-password?token=" + HttpUtility.UrlEncode(token) + "&email=" + HttpUtility.UrlEncode(_user.Email);
            var emailModel = await GetEmailForResetPassword(email, resetPasswordLink);
            await _emailService.SendEmailAsync(emailModel);
        }

        private async Task<MailModel> GetEmailForResetPassword(string emailReceive, string resetpasswordLink)
        {
            MailModel result = new MailModel();
            List<string> emailTos = new List<string>();
            emailTos.Add(emailReceive);
            result.Subject = EmailTemplateSubjectConstant.ResetPasswordSubject;
            string bodyEmail = string.Format(EmailTemplateBodyConstant.ResetPasswordBody, emailReceive, resetpasswordLink);
            result.Body = bodyEmail + EmailTemplateBodyConstant.SignatureFooter;
            result.To = emailTos;
            return await Task.FromResult(result);
        }

        public async Task<UserDTO> GetCurrentUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("Không tìm thấy người dùng nào !");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public DataResult<AppUser> GetUsersPaging(DataRequest request)
        {
            return _userManager.Users.ToDataResult(request);
        }

        public async Task<UserToken> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            {
                throw new Exception("Email or Password is wrong !!");
            }

            if(user.EmailConfirmed== false)
            {
                throw new Exception("Vui lòng xác nhận email !!");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var url = "/";
            if (roles[0] == "Admin" || roles[0] == "Staff")
            {
                url = "/admin";
            }
            return new UserToken()
            {
                UserName = user.UserName,
                Token = await _jwtService.GenerateUserTokenAsync(user),
                RedirectUrl = url
            };
        }

        public async Task Register(RegisterDTO user)
        {
            var NewUser = new AppUser()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email.Split('@')[0],
                BirthDay = user.BirthDay,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            var _user = await _userManager.FindByEmailAsync(user.Email);
            if (_user != null) throw new Exception("Email đã tồn tại !!");
            if (user.Password != user.ConfirmPassword) throw new Exception("Hãy kiểm tra lại mật khẩu !");
            var result = await _userManager.CreateAsync(NewUser, user.Password);
            if (!result.Succeeded) throw new Exception("Đăng ký thất bại !!");
            var roleRs = await _userManager.AddToRoleAsync(NewUser, "Customer");
            if (!roleRs.Succeeded) throw new Exception("Not Add To Role");
            //Mail confirm
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);
            var ConfirmEmailLink = $"http://localhost:3000/confirm-email?userId={HttpUtility.UrlEncode(NewUser.Id)}&token={HttpUtility.UrlEncode(code)}";
            MailModel rs = new MailModel();
            List<string> emailTos = new List<string>();
            emailTos.Add(user.Email);
            rs.Subject = EmailTemplateSubjectConstant.ConfirmEmailBody;
            string bodyEmail = string.Format(EmailTemplateBodyConstant.ConfirmEmailBody, user.Email, ConfirmEmailLink);
            rs.Body = bodyEmail + EmailTemplateBodyConstant.SignatureFooter;
            rs.To = emailTos;
            await _emailService.SendEmailAsync(rs);
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            return _mapper.Map<UserDTO>(await _userManager.FindByEmailAsync(email));
        }

        public Task UpdateProfile(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
            if (user == null) throw new Exception("Đã xảy ra lỗi , vui lòng thử lại !");
            if (resetPasswordDTO.Password != resetPasswordDTO.ConfirmPassword) throw new Exception("Nhập lại mật khẩu mới không khớp với mật khẩu đặt lại !");
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDTO.Token, resetPasswordDTO.Password);
            if (!resetPassResult.Succeeded)
            {
                throw new Exception("Token đã hết hạn !");
            }
        }

        public async Task ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                throw new Exception("Đã hết hạn xác nhận email !");
            }

            var _user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(_user, code);
            if (!result.Succeeded) throw new Exception("Xác nhận Email thất bại !!");
        }
    }
}
