using ECO.Application.DTOs.Category;
using ECO.Application.Services;
using ECO.DataTable;
using ECO.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public  CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _categoryService.GetAll());
;           }
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
                return Ok(await _categoryService.FindById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                await _categoryService.Add(categoryRequestDTO);
                return Ok("Add successfull !");
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id , CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                categoryRequestDTO.Id = id;
                await _categoryService.Update(categoryRequestDTO);
                return Ok("Update Successful !");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _categoryService.Remove(id);
                return Ok("Delete Successful !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FilterPaging(DataRequest req)
        {
            try
            {
                return Ok(_categoryService.GetPaging(req));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
