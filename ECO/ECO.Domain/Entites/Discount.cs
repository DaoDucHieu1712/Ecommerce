using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Discount")]
    public class Discount : BaseEntity<int>
    {
        public Discount() {
            DiscountUsers = new HashSet<DiscountUser>();
        }
        public string Code { get; set; }
        public int Percent { get; set; }
        public int Quantity { get; set; }
        public DateTime Expire { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<DiscountUser> DiscountUsers { get; set;}
    }
}
