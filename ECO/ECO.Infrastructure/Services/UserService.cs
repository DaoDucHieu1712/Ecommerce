using AutoMapper;
using ECO.Application.DTOs.Auth;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class UserService : IUserService
    {

        protected readonly UserManager<AppUser> _userManager;
        protected readonly IJwtService _jwtService;
        protected readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IJwtService jwtService, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _configuration = configuration;
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

        public Task ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            throw new NotImplementedException();
        }

        public Task ForgetPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetCurrentUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
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

            var roles = await _userManager.GetRolesAsync(user);

            return new UserToken()
            {
                UserName = user.UserName,
                Token = await _jwtService.GenerateUserTokenAsync(user),
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
        }
    }
}
