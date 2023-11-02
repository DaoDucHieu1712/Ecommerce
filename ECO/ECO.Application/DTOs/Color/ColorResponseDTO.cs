using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Color
{
    public class ColorResponseDTO
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
    }
}
