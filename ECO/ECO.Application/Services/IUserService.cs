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

        public DataResult<AppUser> GetUsersPaging(DataRequest request);
    }
}
