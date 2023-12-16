using ECO.Application.DTOs.Orders;
using ECO.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequestDTO orderRequestDTO)
        {
            try { 
                orderRequestDTO.CustomerId = User?.Identity?.Name ?? "";
                await _orderService.Add(orderRequestDTO);
                return Ok("Tạo đơn hàng thành công !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder([FromQuery]OrderFilterDTO orderFilterDTO)
        {
            try
            {
                return Ok(await _orderService.GetAllOrder(orderFilterDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MyOrder(string id, [FromQuery] OrderFilterDTO orderFilterDTO)
        {
            try
            {
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
