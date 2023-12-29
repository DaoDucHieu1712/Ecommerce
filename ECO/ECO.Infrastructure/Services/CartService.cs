using AutoMapper;
using ECO.Application.DTOs.Carts;
using ECO.Application.Repositories;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Infrastructure.Services
{
    public class CartService : ICartService
    {

        private readonly ICartRepository _cartRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IInventoryRepository inventoryRepository, ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _inventoryRepository = inventoryRepository;
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task Add(CartRequestDTO entity)
        {
            await _cartRepository.Add(_mapper.Map<Cart>(entity));
        }

        public async Task AddToCart(CartItemRequestDTO cartItemRequestDTO)
        {
            var check = await _cartItemRepository
                .FindSingle(x => x.ProductId == cartItemRequestDTO.ProductId 
                && x.CartId == cartItemRequestDTO.CartId 
                && x.InventoryId == cartItemRequestDTO.InventoryId);

            var _inventory = await _inventoryRepository.FindSingle(x => x.Id == cartItemRequestDTO.InventoryId);

            if (check != null)
            {
                if (_inventory.Quantity == check.Quantity) throw new Exception("Không thể mua quá số lượng của sản phẩm !!");
                check.Quantity = check.Quantity + 1;
                await _cartItemRepository.Update(check, "CreatedAt");
            }
            else
            {
                await _cartItemRepository.Add(_mapper.Map<CartItem>(cartItemRequestDTO));
            }
        }

        public async Task ClearCart(string userId)
        {
            var cart = await _cartRepository.FindSingle(x => x.CustomerId == userId, x => x.Items);
            foreach (var item in cart.Items)
            {
                await _cartItemRepository.Remove(item);
            }
        }

        public async Task DescreaseQuantityCartItem(int itemid)
        {
            var CartItem = await _cartItemRepository.FindSingle(x => x.Id == itemid);
            if (CartItem.Quantity > 1)
            {
                CartItem.Quantity = CartItem.Quantity - 1;
                await _cartItemRepository.Update(CartItem, "CreatedAt");
            }
            else if(CartItem.Quantity == 1) 
            {
                await _cartItemRepository.Remove(CartItem);
            }
        }

        public Task<CartResponseDTO> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartResponseDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CartResponseDTO> GetCartByUser(string id)
        {
            var cart = await _cartRepository.FindAll(x => x.CustomerId == id)
                .Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefaultAsync();
            return _mapper.Map<CartResponseDTO>(cart);
        }

        public DataResult<CartResponseDTO> GetPaging(DataRequest req)
        {
            throw new NotImplementedException();
        }

        public async Task IncreaseQuantityCartItem(int itemid)
        {
            var CartItem = await _cartItemRepository.FindSingle(x => x.Id == itemid);
            var _inventory = await _inventoryRepository.FindSingle(x => x.Id == CartItem.InventoryId);
            if (_inventory.Quantity == CartItem.Quantity) throw new Exception("Không thể mua quá số lượng của sản phẩm !!");
            CartItem.Quantity = CartItem.Quantity + 1;
            await _cartItemRepository.Update(CartItem, "CreatedAt");
        }

        public async Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveCartItem(int itemid)
        {
            var item = await _cartItemRepository.FindSingle(x => x.Id == itemid);
            await _cartItemRepository.Remove(item);
        }

        public async Task Update(CartRequestDTO entity)
        {
            await _cartRepository.Update(_mapper.Map<Cart>(entity), "CreatedAt");
        }

        public Task UseDiscount(string code)
        {
            throw new NotImplementedException();
        }
    }
}
