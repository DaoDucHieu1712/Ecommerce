using ECO.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Domain.Entites
{
    [Table("Resource")]
    public class Resource : BaseEntity<int>
    {
        public string PathId { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}
