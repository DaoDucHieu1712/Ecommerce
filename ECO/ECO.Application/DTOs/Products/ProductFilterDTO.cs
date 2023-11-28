using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Products
{
    public class ProductFilterDTO
    {
        public int? PageIndex { get; set; }
        public string? Name { get; set; }
        public decimal? ToPrice { get; set; }
        public decimal? FromPrice { get; set; }
        public int? CategoryId { get; set; }
        public string? SortType { get; set; }
    }
}
