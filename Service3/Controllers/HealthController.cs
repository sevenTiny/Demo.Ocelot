using Microsoft.AspNetCore.Mvc;

namespace Service3.Controllers
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