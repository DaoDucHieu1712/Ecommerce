using ECO.Application.DTOs.Discount;
using ECO.Application.DTOs.Rating;
using ECO.Application.Services;
using ECO.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _ratingService.GetAll());
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
                return Ok(await _ratingService.FindById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(RatingRequestDTO ratingRequestDTO)
        {
            try
            {
                await _ratingService.Add(ratingRequestDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RatingRequestDTO ratingRequestDTO)
        {
            try
            {
                ratingRequestDTO.Id = id;
                await _ratingService.Add(ratingRequestDTO);
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
                await _ratingService.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
