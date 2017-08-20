using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HypeTrainer.Objects;

namespace HypeTrainer.Services
{
    public static class HltbApiService
    {
        public static Game GetGame(string name)
        {
            Game game = new Game();
            int id = 10270;         //debug

            HtmlDocument gameWebpage = HtmlHltbScrapperService.GetGameWebpage(id);
            if (gameWebpage == null) return null;

            game.Name = HtmlHltbScrapperService.GetGameName(gameWebpage);

            return game;
        }
    }
}
