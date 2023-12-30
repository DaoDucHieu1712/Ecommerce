using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Auth
{
    public class UserToken
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RedirectUrl { get; set; }
    }
}
