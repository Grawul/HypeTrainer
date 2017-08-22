using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCL.WPF;
using HypeTrainer.Objects;

namespace HypeTrainer.ViewModels
{
    public class CalendarViewModel : ViewModel
    {
        #region Fields

        private readonly BindingList<Game> _games;
        private readonly BindingList<Date> _dates;



        #endregion


        #region Constructors

        public CalendarViewModel(BindingList<Game> games, BindingList<Date> dates)
        {
            _games = games;
            _dates = dates;
        }

        #endregion


        #region Properties



        #endregion


        #region Functions



        #endregion
    }
}
