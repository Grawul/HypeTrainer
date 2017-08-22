using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCL.WPF;
using HypeTrainer.Objects;
using HypeTrainer.Services;

namespace HypeTrainer.ViewModels
{
    public class HypeTrainerViewModel : ViewModel
    {
        #region Fields

        private BindingList<Game> _games;
        private BindingList<Date> _dates;

        private CalendarViewModel _calendarViewModel;
        private CollectionViewModel _collectionViewModel;
        private SearchViewModel _searchViewModel;
        private SettingsViewModel _settingsViewModel;

        #endregion


        #region Constructors

        public HypeTrainerViewModel()
        {
            Games = new BindingList<Game>();
            Dates = new BindingList<Date>();

            CalendarViewModel = new CalendarViewModel(Games, Dates);
            CollectionViewModel = new CollectionViewModel(Games, Dates);
            SearchViewModel = new SearchViewModel(Games, Dates);
            SettingsViewModel = new SettingsViewModel();
        }

        #endregion


        #region Properties

        public BindingList<Game> Games
        {
            get { return _games; }
            set
            {
                _games = value; 
                PropertyChange("Games");
            }
        }

        public BindingList<Date> Dates
        {
            get { return _dates; }
            set { _dates = value;
                PropertyChange("Dates");
            }
        }


        public CalendarViewModel CalendarViewModel
        {
            get { return _calendarViewModel; }
            set { _calendarViewModel = value;
                PropertyChange("CalendarViewModel");
            }
        }

        public CollectionViewModel CollectionViewModel
        {
            get { return _collectionViewModel; }
            set { _collectionViewModel = value;
                PropertyChange("CollectionViewModel");
            }
        }

        public SearchViewModel SearchViewModel
        {
            get { return _searchViewModel; }
            set { _searchViewModel = value;
                PropertyChange("SearchViewModel");
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get { return _settingsViewModel; }
            set { _settingsViewModel = value;
                PropertyChange("SettingsViewModel");
            }
        }

        #endregion


        #region Functions



        #endregion
    }
}
