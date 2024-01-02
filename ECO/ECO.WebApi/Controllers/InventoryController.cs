using ECO.Application.DTOs.Inventory;
using ECO.Application.Repositories;
using ECO.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _inventoryService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles ="Admin, Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllByAdmin()
        {
            try
            {
                return Ok(await _inventoryService.GetAll());
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
                return Ok(await _inventoryService.FindById(id));
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
                return Ok(await _inventoryService.FindById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPost]
        public async Task<IActionResult> Create(InventoryRequestDTO inventoryRequestDTO)
        {
            try
            {
                await _inventoryService.Add(inventoryRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InventoryRequestDTO inventoryRequestDTO)
        {
            try
            {
                inventoryRequestDTO.Id = id;
                await _inventoryService.Update(inventoryRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _inventoryService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByProductId(int id)
        {
            try
            {
                return Ok(await _inventoryService.GetAllByProductId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByProductIdByAdmin(int id)
        {
            try
            {
                return Ok(await _inventoryService.GetAllByProductId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet("{id}")]
        public async Task<IActionResult> AddQuantity(int id, int quantity)
        {
            try
            {
                await _inventoryService.AddQuantityInventory(id, quantity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet("{id}")]
        public async Task<IActionResult> DesccreaseQuantityInventory(int id, int quantity)
        {
            try
            {
                await _inventoryService.DescreaseQuantityInventory(id, quantity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
