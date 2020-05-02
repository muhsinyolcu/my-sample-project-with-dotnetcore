using Common.Core.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraping.Api.Models.Gold;

namespace WebScraping.Api.Services.Gold
{
    public interface IGoldExchangesService
    {
        Task<ServiceResult<List<GoldExchangeInfoModel>>> GetGoldExchangeInfos();
    }
}
