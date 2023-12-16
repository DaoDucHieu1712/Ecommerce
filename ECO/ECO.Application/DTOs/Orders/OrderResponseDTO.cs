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
        public string PaymentId { get; set; }
        public decimal TotalPrice { get; set; }
        public string ShipAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string CancelReason { get; set; }
        public string Note { get; set; }
        public List<OrderDetailRequestDTO> OrderDetails { get; set; }
    }
}
