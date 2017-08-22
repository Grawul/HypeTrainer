using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using BCL.WPF;
using HtmlAgilityPack;
using HypeTrainer.Services;

namespace HypeTrainer.Objects
{
    public class Game : ViewModel
    {
        #region Fields

        private readonly int _id;


        // Information from HLTB
        private string _name;
        private Bitmap _bitmapGameImage;
        private BitmapImage _gameImage;

        private GameTime _timeMainStory;
        private GameTime _timeMainExtra;
        private GameTime _timeCompletionist;
        private GameTime _timeAverage;

        private string _developer;
        private string _publisher;
        private string _plattforms;
        private string _genres;
        private DateTime _releaseDateNa;
        private DateTime _releaseDateEu;
        private DateTime _releaseDateJp;

        #endregion


        #region Constructors

        public Game(int id)
        {
            _id = id;

            Refresh();
        }

        #endregion


        #region Properties

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; 
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
            set { _timeMainStory = value;
                PropertyChange("TimeMainStory");
            }
        }

        public GameTime TimeMainExtra
        {
            get { return _timeMainExtra; }
            set { _timeMainExtra = value;
                PropertyChange("TimeMainExtra");
            }
        }

        public GameTime TimeCompletionist
        {
            get { return _timeCompletionist; }
            set { _timeCompletionist = value;
                PropertyChange("TimeCompletionist");
            }
        }

        public GameTime TimeAverage
        {
            get { return _timeAverage; }
            set { _timeAverage = value;
                PropertyChange("TimeAverage");
            }
        }

        public string Developer
        {
            get { return _developer; }
            set { _developer = value;
                PropertyChange("Developer");
            }
        }

        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value;
                PropertyChange("Publisher");
            }
        }

        public string Plattforms
        {
            get { return _plattforms; }
            set { _plattforms = value;
                PropertyChange("Plattforms");
            }
        }

        public string Genres
        {
            get { return _genres; }
            set { _genres = value;
                PropertyChange("Genres");
            }
        }

        public DateTime ReleaseDateNa
        {
            get { return _releaseDateNa; }
            set { _releaseDateNa = value;
                PropertyChange("ReleaseDateNa");
            }
        }

        public DateTime ReleaseDateEu
        {
            get { return _releaseDateEu; }
            set { _releaseDateEu = value;
                PropertyChange("ReleaseDateEu");
            }
        }

        public DateTime ReleaseDateJp
        {
            get { return _releaseDateJp; }
            set { _releaseDateJp = value;
                PropertyChange("ReleaseDateJp");
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

        public void Refresh()
        {
            HtmlDocument gameWebpage = HltbApiService.GetGameWebpage(Id);
            if (gameWebpage == null) return;

            Name = HltbApiService.GetGameName(gameWebpage);
            BitmapGameImage = HltbApiService.GetGameImage(gameWebpage);

            TimeMainStory = HltbApiService.GetTimeMainStory(gameWebpage);
            TimeMainExtra = HltbApiService.GetTimeMainExtra(gameWebpage);
            TimeCompletionist = HltbApiService.GetTimeCompletionist(gameWebpage);
            TimeAverage = HltbApiService.GetTimeAverage(gameWebpage);

            Developer = HltbApiService.GetDeveloper(gameWebpage);
            Publisher = HltbApiService.GetPublisher(gameWebpage);
            Plattforms = HltbApiService.GetPlattforms(gameWebpage);
            Genres = HltbApiService.GetGenres(gameWebpage);
            ReleaseDateNa = HltbApiService.GetReleaseDateNa(gameWebpage);
            ReleaseDateEu = HltbApiService.GetReleaseDateEu(gameWebpage);
            ReleaseDateJp = HltbApiService.GetReleaseDateJp(gameWebpage);
        }

        #endregion


    }
}
