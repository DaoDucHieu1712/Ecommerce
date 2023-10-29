using ECO.Application.DTOs.Auth;
using ECO.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface IJwtService
    {
        public Task<string> GenerateUserTokenAsync(AppUser user);
    }
}
