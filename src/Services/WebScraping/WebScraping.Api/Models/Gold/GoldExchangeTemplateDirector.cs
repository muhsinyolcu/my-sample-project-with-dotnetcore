namespace WebScraping.Api.Models.Gold
{
    public class GoldExchangeTemplateDirector
    {
        public void GenerateTemplate(GoldExchangeTemplateBuilder gETBuilder)
        {
            gETBuilder.FillRequiredItems();
        }
    }
}
