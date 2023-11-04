using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Inventory
{
    public class InventoryRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public bool? IsOnly { get; set; } = false;
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
