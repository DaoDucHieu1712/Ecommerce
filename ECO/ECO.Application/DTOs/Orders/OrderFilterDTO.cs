using ECO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Orders
{
    public class OrderFilterDTO
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int? OrderId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public OrderStatus? Status { get; set; }
        public string? SortType { get; set; }
    }
}
