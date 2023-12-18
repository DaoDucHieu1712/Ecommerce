using ECO.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> StatictisCount()
        {
            try
            {
                return Ok(await _dashboardService.GetStatisticCount()); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{year}")]
        public async Task<IActionResult> GetChartPrice(int year)
        {
            try
            {
                return Ok(await _dashboardService.GetChartTotalPriceByMonth(year));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryStatistic()
        {
            try
            {
                return Ok(await _dashboardService.GetCategoryStatictis());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
