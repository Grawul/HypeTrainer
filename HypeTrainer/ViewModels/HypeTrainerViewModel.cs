using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCL.WPF;
using HypeTrainer.Services;

namespace HypeTrainer.ViewModels
{
    public class HypeTrainerViewModel : ViewModel
    {
        #region Fields

        private string _gameName;


        #endregion


        #region Constructors

        public HypeTrainerViewModel()
        {
            GameName = HltbApiService.GetGame("test").Name;
        }

        #endregion


        #region Properties

        public string GameName
        {
            get { return _gameName; }
            set
            {
                _gameName = value; 
                PropertyChange("GameName");
            }
        }

        #endregion


        #region Functions



        #endregion
    }
}
