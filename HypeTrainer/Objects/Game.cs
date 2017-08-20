using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCL.WPF;

namespace HypeTrainer.Objects
{
    public class Game : ViewModel
    {
        #region Fields

        public string _name;

        #endregion


        #region Constructors



        #endregion


        #region Properties

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value; 
                PropertyChange("Name");
            }
        }

        #endregion


        #region Functions



        #endregion


    }
}
