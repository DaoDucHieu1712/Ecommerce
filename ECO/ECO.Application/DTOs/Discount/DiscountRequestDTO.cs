using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Discount
{
    public class DiscountRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public int Percent { get; set; }
        public DateTime Expire { get; set; }
        public bool IsPublic { get; set; }
    }
}
