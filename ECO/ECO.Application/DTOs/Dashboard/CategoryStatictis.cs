using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Dashboard
{
    public class CategoryStatictis
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Percent { get; set; }
    }
}
