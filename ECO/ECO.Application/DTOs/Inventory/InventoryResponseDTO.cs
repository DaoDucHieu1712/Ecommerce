using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Inventory
{
    public class InventoryResponseDTO
    {
        public int Id { get; set; }
        public string InventoryName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SizeId { get; set; }
        public string? SizeName { get; set; }
        public int? ColorId { get; set; }
        public string? ColorName { get; set; }
        public bool? IsOnly { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
