using ECO.Domain.Entites;
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

        private readonly ECOContext _context;

        public FileController(ECOContext context)
        {
            _context = context;
        }

        [HttpDelete("{pathId}")]
        public async Task<IActionResult> DeleteImage(string pathId)
        {
            try
            {
                var resource = await _context.Resources.Where(x => x.PathId== pathId).FirstOrDefaultAsync();
                if(resource == null)
                {
                    return StatusCode(500, "Không tìm thấy ảnh !!!");
                }
                _context.Resources.Remove(resource);
                await _context.SaveChangesAsync();

                var path = Path.GetFullPath(resource.Url);
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
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images", name_file);
                if (fileImage.Length > 0 && fileImage.Length <= 4000000)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileImage.CopyToAsync(stream);
                    }

                    var rs = new Resource
                    {
                        PathId= PathId,
                        Url= filePath,
                        FileName= fileName,
                    };

                    await _context.Resources.AddAsync(rs);
                    await _context.SaveChangesAsync();
                    return Ok(await _context.Resources.FirstOrDefaultAsync(x=> x.Id == rs.Id));
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
