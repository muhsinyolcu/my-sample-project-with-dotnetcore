using System.Collections.Generic;

namespace WebScraping.Api.Models.Gold
{
    public abstract class GoldExchangeTemplateBuilder
    {
        public abstract List<GoldExchangeInfoModel> FillRequiredItems();
    }
}
