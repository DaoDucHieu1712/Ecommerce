using ECO.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECO.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseAPIController : Controller
    {
        protected readonly UserManager<AppUser> UserManager;

        protected BaseAPIController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        protected async Task<AppUser> GetCurrentUser() => await UserManager.FindByIdAsync(GetUserId());

        protected string GetUserId() => User?.Identity?.Name ?? "";

        protected IActionResult ReturnBadRequest(ILogger _logger, Exception e)
        {
            _logger.LogError("Get Property Failed " + e);
            return BadRequest(e.Message);
        }
    }
}
