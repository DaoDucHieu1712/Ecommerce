using ECO.Infrastructure.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace ECO.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpDelete("{url}")]
        public async Task<IActionResult> DeleteImage(string url)
        {
            try
            {
                var path = Path.GetFullPath(url);
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                    return Ok("Delete Successful !");
                }
                else
                {
                    return StatusCode(500, "Delete fail !!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile fileImage)
        {
            try
            {
                string fileName = Path.GetFileName(fileImage.FileName);
                string type_file = fileName.Split(".")[1];
                string PathId = Guid.NewGuid().ToString();
                string name_file = $"{PathId}.{type_file}";
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "Images", name_file);
                if (fileImage.Length > 0 && fileImage.Length <= 4000000)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileImage.CopyToAsync(stream);
                    }
                    return Ok(filePath);
                }
                else
                {
                    return StatusCode(500, "File can not large than 4MB");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
