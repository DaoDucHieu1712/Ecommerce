using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("OrderDetail")]
    public class OrderDetail : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        [ForeignKey(nameof(InventoryId))]
        public Inventory Inventory { get; set; }
    }
}
