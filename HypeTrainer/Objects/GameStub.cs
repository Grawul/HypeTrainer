using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BCL.WPF;

namespace HypeTrainer.Objects
{
    public class GameStub : ViewModel
    {
        #region Fields

        private int _id;
        
        private string _name;
        private Bitmap _bitmapGameImage;
        private BitmapImage _gameImage;

        private GameTime _timeMainStory;
        private GameTime _timeMainExtra;
        private GameTime _timeCompletionist;
        private GameTime _timeAverage;

        #endregion


        #region Constructors



        #endregion


        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChange("Name");
            }
        }

        public Bitmap BitmapGameImage
        {
            get { return _bitmapGameImage; }
            set
            {
                _bitmapGameImage = value;
                _gameImage = ConvertBitmap(value);
                PropertyChange("GameImage");
            }
        }

        public BitmapImage GameImage
        {
            get { return _gameImage; }
        }



        public GameTime TimeMainStory
        {
            get { return _timeMainStory; }
            set
            {
                _timeMainStory = value;
                PropertyChange("TimeMainStory");
            }
        }

        public GameTime TimeMainExtra
        {
            get { return _timeMainExtra; }
            set
            {
                _timeMainExtra = value;
                PropertyChange("TimeMainExtra");
            }
        }

        public GameTime TimeCompletionist
        {
            get { return _timeCompletionist; }
            set
            {
                _timeCompletionist = value;
                PropertyChange("TimeCompletionist");
            }
        }

        public GameTime TimeAverage
        {
            get { return _timeAverage; }
            set
            {
                _timeAverage = value;
                PropertyChange("TimeAverage");
            }
        }

        #endregion


        #region Functions

        private BitmapImage ConvertBitmap(Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();

            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }

        #endregion


    }
}
