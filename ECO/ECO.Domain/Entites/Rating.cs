using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Rating")]
    public class Rating : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public string CustomerId { get; set; }
        public string Comment { get; set; }
        public int Star { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public AppUser Customer { get; set; }

    }
}
