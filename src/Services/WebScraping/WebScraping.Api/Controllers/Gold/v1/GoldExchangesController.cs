using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebScraping.Api.Controllers.Gold.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GoldExchangesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}