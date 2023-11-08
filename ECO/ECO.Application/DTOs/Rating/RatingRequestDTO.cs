using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Rating
{
    public class RatingRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CustomerId { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
    }
}
