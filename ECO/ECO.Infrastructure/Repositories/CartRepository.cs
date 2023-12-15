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
    public class CartRepository : BaseRepository<Cart, int>, ICartRepository
    {
        public CartRepository(ECOContext context) : base(context)
        {
        }
    }
}
