using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Cart")]
    public class Cart : BaseEntity<int>
    {
        public string CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public AppUser Customer { get; set; }
        public ICollection<CartItem> Items { get; set;}
    }
}
