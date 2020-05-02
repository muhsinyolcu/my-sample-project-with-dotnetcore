using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebScraping.Api.Services.Gold;

namespace WebScraping.Api.Controllers.Gold.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GoldExchangesController : BaseApiController
    {
        private readonly IGoldExchangesService _goldExchangesService;
        public GoldExchangesController(IGoldExchangesService goldExchangesService)
        {
            _goldExchangesService = goldExchangesService;
        }

        [HttpGet("getgoldexchangeinfos")]
        public IActionResult GetGoldExchangeInfos()
        {
            var goldExchanges = _goldExchangesService.GetGoldExchangeInfos().Result;
            return HttpEntity(goldExchanges);
        }
    }
}