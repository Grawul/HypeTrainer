using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ScrapySharp.Extensions;

namespace HypeTrainer.Services
{
    public static class HtmlHltbScrapperService
    {
        public static HtmlDocument GetGameWebpage(int id)
        {
            string url = string.Format("https://howlongtobeat.com/game.php?id={0}", id);
            HtmlWeb webGet = new HtmlWeb();
            HtmlDocument gameWebpage = webGet.Load(url);

            return gameWebpage;
        }



        public static string GetGameName(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_header").ToList();
            string elementText = nodes[0].InnerText;
            return Regex.Replace(elementText, "\t|\n|\r", "");
        }
    }
}
