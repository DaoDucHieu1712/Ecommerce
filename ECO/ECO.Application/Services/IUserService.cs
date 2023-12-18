using ECO.Application.DTOs.Auth;
using ECO.DataTable;
using ECO.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IUserService
    {
        public Task<AppUser> Authenicate(string username, string password);
        public Task<UserToken> Login(string username, string password);
        public Task Register(RegisterDTO user);
        public Task ChangePassword(ChangePasswordDTO changePasswordDTO);
        public DataResult<AppUser> GetUsersPaging(DataRequest request);
        public Task<UserDTO> GetCurrentUser(string id);
        public Task ForgetPassword(string email);
        public Task ResetPassword(ResetPasswordDTO resetPasswordDTO);
        public Task<UserDTO> GetUserByEmail(string email);
        public Task UpdateProfile(UserDTO userDTO);
        
    }
}
