using ECO.Application.DTOs.Orders;
using ECO.Application.Services;
using ECO.Domain.Enums;
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyOrder([FromQuery] OrderFilterDTO orderFilterDTO)
        {
            try
            {
                var userId = User?.Identity?.Name ?? "";
                return Ok(await _orderService.MyOrder(userId, orderFilterDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                return Ok(await _orderService.FindById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id , OrderStatus status)
        {
            try
            {
                await _orderService.UpdateOrderStatus(id, status);
                return Ok("Update successful !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentStatus(int id, PaymentStatus status)
        {
            try
            {
                await _orderService.UpdateOrderPayment(id, status);
                return Ok("Update successful !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
