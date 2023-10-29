using ECO.Domain.Common;
using ECO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Order")]
    public class Order : BaseEntity<int>
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public string CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CancelReason { get; set; }
        public string Note { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int PaymentId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public AppUser Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
