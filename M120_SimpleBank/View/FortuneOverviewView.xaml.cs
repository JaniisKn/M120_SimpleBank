using System.Windows;
using M120_SimpleBank.ViewModel;

namespace M120_SimpleBank.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FortuneOverviewView : Window
    {
        public FortuneOverviewView()
        {
            InitializeComponent();
            var viewModel = new FortuneOverviewViewModel();
            DataContext = viewModel;
            if (viewModel.CloseEvent == null) {
                viewModel.CloseEvent = this.Close;
            }
        }
    }
}
