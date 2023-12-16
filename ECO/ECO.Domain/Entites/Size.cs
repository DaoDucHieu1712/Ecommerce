using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Size")]
    public class Size : BaseEntity<int>
    {
        public Size()
        {
            Inventories = new HashSet<Inventory>();
        }
        public string SizeName { get; set; }
        public string? Description { get; set; }
        public ICollection<Inventory> Inventories { get; set; }

    }
}
