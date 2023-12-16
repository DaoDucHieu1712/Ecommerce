using ECO.Domain.Entites;
using ECO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Orders
{
    public class OrderRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string? CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? CancelReason { get; set; }
        public string? Note { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
        public List<OrderDetailRequestDTO> OrderDetails { get; set; }
    }
}
