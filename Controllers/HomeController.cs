using Microsoft.AspNetCore.Mvc;

namespace PayLess.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("health")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
