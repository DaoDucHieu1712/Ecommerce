using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Color")]
    public class Color : BaseEntity<int>
    {
        public Color() {

            Inventories = new HashSet<Inventory>();
        
        }
        public string ColorName { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
