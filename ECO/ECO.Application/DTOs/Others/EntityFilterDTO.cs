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
        public int? total { get; set; }
        public int? pageIndex { get; set; }
    }
}
