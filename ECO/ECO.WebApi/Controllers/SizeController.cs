using ECO.Application.DTOs.Size;
using ECO.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizeController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _sizeService.GetAll());
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
                return Ok(await _sizeService.FindById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllByAdmin()
        {
            try
            {
                return Ok(await _sizeService.GetAll());
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
                return Ok(await _sizeService.FindById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


        [Authorize(Roles = "Admin, Staff")]
        [HttpPost]
        public async Task<IActionResult> Create(SizeRequestDTO sizeRequestDTO)
        {
            try
            {
                await _sizeService.Add(sizeRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Admin, Staff")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SizeRequestDTO sizeRequestDTO)
        {
            try
            {
                sizeRequestDTO.Id = id;
                await _sizeService.Update(sizeRequestDTO);
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
                await _sizeService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
