using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    public class AppUser : IdentityUser
    {
        public AppUser() {

            Orders = new HashSet<Order>();
            Ratings = new HashSet<Rating>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
