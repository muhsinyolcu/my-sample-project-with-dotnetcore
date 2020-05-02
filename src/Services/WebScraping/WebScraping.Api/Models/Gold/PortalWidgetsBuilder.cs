using System;
using System.Collections.Generic;

namespace WebScraping.Api.Models.Gold
{
    public class PortalWidgetsBuilder : GoldExchangeTemplateBuilder
    {
        public override List<GoldExchangeInfoModel> FillRequiredItems()
        {
            return new List<GoldExchangeInfoModel>() {
                new GoldExchangeInfoModel(){ GoldName="Gram Altın" },
                new GoldExchangeInfoModel(){ GoldName="22 Ayar Bilezik Gram" },
                new GoldExchangeInfoModel(){ GoldName="Cumhuriyet" },
                new GoldExchangeInfoModel(){ GoldName="Yarım Altın" },
                new GoldExchangeInfoModel(){ GoldName="Çeyrek Altın" },
                new GoldExchangeInfoModel(){ GoldName="Ata Altın" },
                new GoldExchangeInfoModel(){ GoldName="Ons Altın/Dolar" },
            };
        }
    }
}
