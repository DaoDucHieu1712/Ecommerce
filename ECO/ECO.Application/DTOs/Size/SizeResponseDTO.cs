using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Size
{
    public class SizeResponseDTO
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        public string? Description { get; set; }
    }
}
