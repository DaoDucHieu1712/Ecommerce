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

        public UserService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
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

            var UserToken = new UserToken()
            {
                UserId = user.Id,
                Roles= roles,
                Email= email,
                Token = await _jwtService.GenerateUserTokenAsync(user),
            };

            return UserToken;
        }

        public async Task Register(RegisterDTO user)
        {
                var NewUser = new AppUser()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.Email,
                    BirtDay = user.BirthDay,
                    Gender = user.Gender,
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
