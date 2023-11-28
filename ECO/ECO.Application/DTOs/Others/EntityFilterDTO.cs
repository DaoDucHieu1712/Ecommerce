using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Others
{
    public class EntityFilterDTO<T>
    {
        public List<T>? List { get; set; }
        public int? TotalPages { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool? HasPrevious { get; set; }
        public bool? HasNext { get; set; }
    }
}
