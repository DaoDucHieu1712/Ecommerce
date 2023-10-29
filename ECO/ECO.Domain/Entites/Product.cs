using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Product")]
    public class Product : BaseEntity<int>
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            Ratings = new HashSet<Rating>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
