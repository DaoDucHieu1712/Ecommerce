using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Carts
{
    public class CartResponseDTO
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public virtual List<CartItemResponseDTO> Items { get; set; }
    }
}
