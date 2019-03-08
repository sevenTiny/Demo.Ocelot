using Microsoft.AspNetCore.Mvc;

namespace Service2.Controllers
{
    [Produces("application/json")]
    [Route("api/Health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content("ok");
        }
    }
}