using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers.User.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        //FOR next versions
        public IActionResult Index()
        {
            return Ok();
        }
    }
}