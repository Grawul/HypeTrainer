using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using BCL.WPF;
using HtmlAgilityPack;
using HypeTrainer.Objects;
using HypeTrainer.Services;

namespace HypeTrainer.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        #region Fields

        private readonly BindingList<Game> _games;
        private readonly BindingList<Date> _dates;

        private string _input;
        private BindingList<GameStub> _foundGames;

        private CancellationTokenSource _cts;

        #endregion


        #region Constructors

        public SearchViewModel(BindingList<Game> games, BindingList<Date> dates)
        {
            _games = games;
            _dates = dates;
        }

        #endregion


        #region Properties

        public string Input
        {
            get { return _input; }
            set
            {
                _input = value; 
                PropertyChange("Input");
                InputChange();
            }
        }

        public BindingList<GameStub> FoundGames
        {
            get { return _foundGames; }
            set { _foundGames = value;
                PropertyChange("FoundGames");
            }
        }

        #endregion


        #region Functions

        private async void InputChange()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts = null;
            }

            _cts = new CancellationTokenSource();

            try
            {
                Task<HtmlDocument> gamePageAsync = HltbApiService.InputChangeSendAsync(Input, _cts.Token);
                HtmlDocument gamePage = await gamePageAsync;
                FoundGames = HltbApiService.InputChangeGet(gamePage);
            }
            catch (OperationCanceledException)
            {
            }
        }

        #endregion


    }
}
