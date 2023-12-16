using ECO.Application.DTOs.Carts;
using ECO.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            try
            {
                var userId = User?.Identity?.Name ?? "";
                var cart = await _cartService.GetCartByUser(userId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItemRequestDTO cartItemRequestDTO)
        {
            try
            {
                await _cartService.AddToCart(cartItemRequestDTO);
                return Ok("Add to cart successful !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> IncreaseQuantityCartItem(int id)
        {
            try
            {
                await _cartService.IncreaseQuantityCartItem(id);
                return Ok("Increase quantity success !");
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DecreseaQuantityCartItem(int id)
        {
            try
            {
                await _cartService.DescreaseQuantityCartItem(id);
                return Ok("Descrease quantity success !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCartItem(int id)
        {
            try
            {
                await _cartService.RemoveCartItem(id);
                return Ok("Descrease quantity success !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ClearCart()
        {
            try
            {
                var userId = User?.Identity?.Name ?? "";
                await _cartService.ClearCart(userId);
                return Ok("Descrease quantity success !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
