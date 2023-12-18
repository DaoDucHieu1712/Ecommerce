using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Auth
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
