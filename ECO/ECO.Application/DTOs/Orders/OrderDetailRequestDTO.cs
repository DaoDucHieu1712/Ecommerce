using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Orders
{
    public class OrderDetailRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int ProductId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
