using ECO.Application.Repositories;
using ECO.Domain.Entites;
using ECO.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Repositories
{
    public class DiscountRepository : BaseRepository<Discount, int>, IDiscountRepository
    {
        public DiscountRepository(ECOContext context) : base(context)
        {
        }
    }
}
