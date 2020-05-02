using Common.Core.Enums;
using Common.Core.Helpers;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebScraping.Api.Models.Gold;

namespace WebScraping.Api.Services.Gold
{
    public class GoldExchangesService : IGoldExchangesService
    {
        private readonly string _portalWidgetsV3ForeksGoldLink = "https://portal-widgets-v3.foreks.com/gold";
        public async Task<ServiceResult<List<GoldExchangeInfoModel>>> GetGoldExchangeInfos()
        {
            var serviceResult = new ServiceResult<List<GoldExchangeInfoModel>>();
            try
            {
                var result = await ScrapGoldExhangeInfos();
                if (result == null)
                    serviceResult.StatusCode = (int)StatusCodesEnum.BadRequest;

                serviceResult.Result = result;
                serviceResult.TotalItemCount = result.Count;
            }
            catch (Exception ex)
            {
                serviceResult.HasError = true;
                serviceResult.StatusCode = (int)StatusCodesEnum.SystemException;
                serviceResult.ValidationMessages.Add(ex.Message);
                //LOG
            }
            return serviceResult;
        }
        private async Task<List<GoldExchangeInfoModel>> ScrapGoldExhangeInfos()
        {
            HttpClient hc = new HttpClient();
            HttpResponseMessage result = await hc.GetAsync(_portalWidgetsV3ForeksGoldLink);
            Stream stream = await result.Content.ReadAsStreamAsync();
            HtmlDocument doc = new HtmlDocument();
            doc.Load(stream);
            HtmlNodeCollection trS = doc.DocumentNode.SelectNodes("//tr");

            GoldExchangeTemplateDirector director = new GoldExchangeTemplateDirector();
            var builder = new PortalWidgetsBuilder();
            director.GenerateTemplate(builder);

            var infos = builder.FillRequiredItems();

            foreach (var tr in trS)
            {
                var gold = infos.First();
                var tds = tr.SelectNodes("//td");
                foreach (var td in tds)
                {
                    string value = td.InnerText.Trim();
                    string htmlValue = td.OuterHtml;
                    if (htmlValue.Contains("symbol"))
                    {
                        gold = infos.Where(g => g.GoldName.ToLower() == value.ToLower()).First();
                    }
                    else if (htmlValue.Contains("last"))
                    {
                        if (string.IsNullOrEmpty(gold.GoldBuy))
                        {
                            gold.GoldBuy = value;
                        }
                        else
                        {
                            gold.GoldSell = value;
                        }
                    }
                    else if (htmlValue.Contains("percentage"))
                    {
                        if (string.IsNullOrEmpty(gold.GoldDiff))
                        {
                            gold.GoldDiff = value;
                        }
                        else
                        {
                            gold.GoldDiffPer = value;
                        }
                    }
                    else if (htmlValue.Contains("text-right"))
                    {
                        gold.Hour = value;
                    }
                }
            }
            return infos;
        }
    }
}
