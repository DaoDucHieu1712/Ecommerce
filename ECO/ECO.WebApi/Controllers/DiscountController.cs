using ECO.Application.DTOs.Discount;
using ECO.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _discountService.GetAll());
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
                return Ok(await _discountService.FindById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(DiscountRequestDTO discountRequestDTO)
        {
            try
            {
                await _discountService.Add(discountRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DiscountRequestDTO discountRequestDTO)
        {
            try
            {
                discountRequestDTO.Id = id;
                await _discountService.Add(discountRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _discountService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
