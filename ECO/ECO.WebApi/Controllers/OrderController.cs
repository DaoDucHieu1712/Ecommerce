using ECO.Application.DTOs.Orders;
using ECO.Application.Services;
using ECO.Domain.Enums;
using ECO.Infrastructure.Services;
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
        private readonly IVnPayService _vnPayService;

        public OrderController(IOrderService orderService, IVnPayService vnPayService)
        {
            _orderService = orderService;
            _vnPayService = vnPayService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderRequestDTO orderRequestDTO)
        {
            try { 
                orderRequestDTO.CustomerId = User?.Identity?.Name ?? "";
                var od = await _orderService.CreateAndGet(orderRequestDTO);
                return Ok(od);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles ="Admin, Staff")]
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

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdByAdmin(int id)
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatus(int id , OrderStatus status, string? reason)
        {
            try
            {
                await _orderService.UpdateOrderStatus(id, status , reason);
                return Ok("Update successful !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, PaymentMethod method, PaymentStatus status)
        {
            try
            {
                await _orderService.UpdatePayment(id, method, status);
                return Ok("Update successful !!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetUrlPayment(VnPayRequestDTO vnPayRequestDTO)
        {
            try
            {
                var url = _vnPayService.CreatePaymentUrl(HttpContext, vnPayRequestDTO);
                return Ok(url);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> PaymentCallBack(int id)
        {
            try
            {
                var response = _vnPayService.PaymentExecute(Request.Query);

                if (response == null || response.VnPayResponseCode != "00")
                {
                    await _orderService.UpdatePayment(id, PaymentMethod.Bank, PaymentStatus.Fail);
                    return Redirect("http://localhost:3000/payment-fail");
                }
                await _orderService.UpdatePayment(id, PaymentMethod.Bank, PaymentStatus.Success);
                return Redirect("http://localhost:3000/payment-success");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
