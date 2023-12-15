using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("CartItem")]
    public class CartItem : BaseEntity<int>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string Type { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(InventoryId))]
        public Inventory Inventory { get; set; }
    }
}
