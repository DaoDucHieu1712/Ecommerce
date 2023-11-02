using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Color
{
    public class ColorRequestDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
