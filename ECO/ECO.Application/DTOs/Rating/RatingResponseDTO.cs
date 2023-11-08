using ECO.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Rating
{
    public class RatingResponseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
    }
}
