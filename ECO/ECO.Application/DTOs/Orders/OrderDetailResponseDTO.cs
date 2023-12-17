using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Orders
{
    public class OrderDetailResponseDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int InventoryId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
