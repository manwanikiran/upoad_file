using System.Diagnostics;
using File_Upload_exp.Models;
using Microsoft.AspNetCore.Mvc;

namespace File_Upload_exp.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string[] _allowedExtensions = new string[] { ".xlsx" };
        private string _uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            if(!Directory.Exists(_uploadDirectory))
            {
                Directory.CreateDirectory(_uploadDirectory);
            }
        }

        [HttpPost]
        public IActionResult File_upload(IFormFile formFile)
        {
           
            if (formFile == null || formFile == Empty)
            {
                return BadRequest("Invlaid file");
            }

            var fileExtension = Path.GetExtension(formFile.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Invalid File type");
            }

           var filename= Path.GetFileName(formFile.FileName);
            Console.WriteLine("the filename is "+filename);
           var filepath = Path.Combine(_uploadDirectory,filename);
            Console.WriteLine("the file path is " + filepath);

            var stream = new FileStream(filepath,FileMode.Create);
            formFile.CopyTo(stream);
            return Ok($"file uploaded successfully:{filepath}");
        }

    }
}
