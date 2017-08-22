using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HypeTrainer.Import;
using HypeTrainer.Objects;
using ScrapySharp.Extensions;

namespace HypeTrainer.Services
{
    public static class HltbApiService
    {
        public static HtmlDocument GetGameWebpage(int id)
        {
            string url = string.Format("https://howlongtobeat.com/game.php?id={0}", id);
            HtmlWeb webGet = new HtmlWeb();
            HtmlDocument gameWebpage = webGet.Load(url);

            return gameWebpage;
        }


        #region GameInformation

        public static string GetGameName(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_header").ToList();
            string elementText = nodes[0].InnerText;
            return Regex.Replace(elementText.Trim(), "\t|\n|\r", "");
        }

        public static Bitmap GetGameImage(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".game_image img").ToList();
            string imageUrl = nodes[0].GetAttributeValue("src");
            imageUrl = string.Format("https://howlongtobeat.com/{0}", imageUrl);

            WebRequest request = WebRequest.Create(imageUrl);
            WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();

            if (responseStream == null) return null;
            return new Bitmap(responseStream);
        }



        public static GameTime GetTimeMainStory(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".game_main_table tbody").ToList();
            string elementText = nodes[0].ChildNodes[1].ChildNodes[5].InnerText;
            
            return new GameTime(elementText);
        }

        public static GameTime GetTimeMainExtra(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".game_main_table tbody").ToList();
            string elementText = nodes[1].ChildNodes[1].ChildNodes[5].InnerText;

            return new GameTime(elementText);
        }

        public static GameTime GetTimeCompletionist(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".game_main_table tbody").ToList();
            string elementText = nodes[2].ChildNodes[1].ChildNodes[5].InnerText;

            return new GameTime(elementText);
        }

        public static GameTime GetTimeAverage(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".game_main_table tbody").ToList();
            string elementText = nodes[3].ChildNodes[1].ChildNodes[5].InnerText;

            return new GameTime(elementText);
        }


        public static string GetDeveloper(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_info").ToList();
            string elementText = nodes[0].InnerText;
            return Regex.Replace(elementText, "\t|\n|\r|\"|Developer:", "").Trim(); ;
        }

        public static string GetPublisher(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_info").ToList();
            string elementText = nodes[1].InnerText;
            return Regex.Replace(elementText, "\t|\n|\r|\"|Publishers:", "").Trim(); ;
        }

        public static string GetPlattforms(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_info").ToList();
            string elementText = nodes[2].InnerText;
            return Regex.Replace(elementText, "\t|\n|\r|\"|Playable On:", "").Trim();
        }

        public static string GetGenres(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_info").ToList();
            string elementText = nodes[3].InnerText;
            return Regex.Replace(elementText, "\t|\n|\r|\"|Genres:", "").Trim();
        }

        public static DateTime GetReleaseDateNa(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_info").ToList();
            string elementText = nodes[4].InnerText;
            string date = Regex.Replace(elementText, "\t|\n|\r|\"|NA:", "").Trim();
            return DateTime.Parse(date);
        }

        public static DateTime GetReleaseDateEu(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_info").ToList();
            string elementText = nodes[5].InnerText;
            string date = Regex.Replace(elementText, "\t|\n|\r|\"|EU:", "").Trim();
            return DateTime.Parse(date);
        }

        public static DateTime GetReleaseDateJp(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".profile_info").ToList();
            string elementText = nodes[6].InnerText;
            string date = Regex.Replace(elementText, "\t|\n|\r|\"|JP:", "").Trim();
            return DateTime.Parse(date);
        }

        #endregion


        #region Search

        public static async Task<HtmlDocument> InputChangeSendAsync(string input, CancellationToken ct)
        {
            string url = "https://howlongtobeat.com/search_main.php";

            NameValueCollection postData = new NameValueCollection(1);
            postData.Add("page", "1");
            postData.Add("queryString", input);

            HtmlWebImport webGet = new HtmlWebImport();
            HtmlDocument docAsync = await Task.Run(() => webGet.SubmitFormValues(postData, url));

            ct.ThrowIfCancellationRequested();

            return docAsync;
        }


        public static BindingList<GameStub> InputChangeGet(HtmlDocument gameWebpage)
        {
            List<HtmlNode> nodes = gameWebpage.DocumentNode.CssSelect(".search_list").ToList();
            //string elementText = nodes[0].InnerText;

            return null;
        }

        #endregion
    }
}
