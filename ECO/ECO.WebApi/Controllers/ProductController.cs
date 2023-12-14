using ECO.Application.DTOs.Products;
using ECO.Application.DTOs.Response;
using ECO.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _productService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Shop([FromQuery]ProductShopDTO productShopDTO)
        {
            try
            {
                return Ok(await _productService.GetShop(productShopDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Filter([FromQuery] ProductFilterDTO productFilterDTO)
        {
            try
            {
                var rs = await _productService.GetAllProductFilter(productFilterDTO);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestDTO productRequestDTO)
        {
            try
            {
                await _productService.Add(productRequestDTO);
                return Ok("Add successful !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductRecommend(int id)
        {
            try
            {
                return Ok(await _productService.GetProductRecommend(id));
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
                return Ok(await _productService.FindById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductRequestDTO productRequestDTO)
        {
            try
            {
                productRequestDTO.Id = id;
                await _productService.Update(productRequestDTO);
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
                await _productService.Remove(id);
                return Ok("Delete Successful !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
