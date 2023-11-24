using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Discount
{
    public class DiscountResponseDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Percent { get; set; }
        public int Quantity { get; set; }
        public DateTime Expire { get; set; }
        public bool IsPublic { get; set; }
    }
}

