using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("DiscountUser")]
    public class DiscountUser : BaseEntity<int>
    {
        public string CustomerId { get; set; }
        public int DiscountId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public AppUser Customer { get; set; }
        [ForeignKey(nameof(DiscountId))]
        public Discount Discount { get; set; }
    }
}
