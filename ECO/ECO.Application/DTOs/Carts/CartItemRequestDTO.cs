using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Carts
{
    public class CartItemRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string Type { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
