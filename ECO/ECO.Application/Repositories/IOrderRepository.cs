using ECO.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order, int>
    {
    }
}
