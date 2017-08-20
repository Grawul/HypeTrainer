using System.Windows;
using HypeTrainer.ViewModels;

namespace HypeTrainer.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _htvm = new HypeTrainerViewModel();
            DataContext = _htvm;
        }

        public HypeTrainerViewModel _htvm;
    }
}
