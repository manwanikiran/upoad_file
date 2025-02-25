using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace File_Upload_exp
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Display()
        {
            return Ok("display");

        }

        [HttpGet]
        public IActionResult  GetData()
        {
            return ok("get data ");
            
        }





    }
}
