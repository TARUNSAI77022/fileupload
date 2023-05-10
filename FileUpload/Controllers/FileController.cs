using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    public class FileController : Controller
    {
        private readonly string wwwrootDirectory =
           Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile myFile)
        {
            if (myFile != null)
            {
                var uploadsDirectory = Path.Combine(wwwrootDirectory, "upload");
                var path = Path.Combine(
                   uploadsDirectory,
                   DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName));
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }

            }
            return View();
        }
    }
}
