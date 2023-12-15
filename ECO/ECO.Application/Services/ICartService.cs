using ECO.Application.DTOs.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.Services
{
    public interface ICartService : IBaseService<CartResponseDTO, CartRequestDTO, int>
    {
        public Task<CartResponseDTO> GetCartByUser(string id);
        public Task AddToCart(CartItemRequestDTO cartItemRequestDTO);
        public Task IncreaseQuantityCartItem(int itemid);
        public Task DescreaseQuantityCartItem(int itemid);
        public Task RemoveCartItem(int itemid);
        public Task UseDiscount(string code);
        public Task ClearCart(string userId);
    }
}
