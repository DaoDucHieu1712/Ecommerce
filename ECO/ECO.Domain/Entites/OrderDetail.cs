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
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
        [ForeignKey(nameof(SizeId))]
        public Size Size { get; set; }
        [ForeignKey(nameof(ColorId))]
        public Color Color { get; set; }
    }
}
