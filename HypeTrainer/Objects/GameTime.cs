using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTrainer.Objects
{
    [Serializable]
    public class GameTime
    {
        #region Fields

        private int _hours;
        private int _minutes;

        #endregion


        #region Constructors

        public GameTime(string hltbFormat)
        {
            Hours = 0;
            Minutes = 0;

            if (hltbFormat.Contains("m"))
            {
                Minutes = Convert.ToInt32(hltbFormat.Split('h')[1].Replace("m", ""));
            }

            Hours = Convert.ToInt32(hltbFormat.Split('h')[0]);
        }

        #endregion


        #region Properties

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public int Minutes
        {
            get { return _minutes; }
            set { _minutes = value; }
        }

        #endregion


        #region Functions

        public override string ToString()
        {
            return string.Format("{0,3}h {1:00}m", Hours, Minutes);
        }

        #endregion


    }
}
