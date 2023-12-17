using ECO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Orders
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PaymentId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CancelReason { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetailResponseDTO> OrderDetails { get; set; }
    }
}
