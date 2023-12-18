using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Discount
{
    public class UseDiscountDTO
    {
        public string Massage { get; set; }
        public int Percent { get; set; }
        public bool IsUse { get; set; }
    }
}
