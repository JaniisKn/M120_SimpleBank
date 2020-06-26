using System.Windows;
using M120_SimpleBank.ViewModel;

namespace M120_SimpleBank.View
{
    /// <summary>
    /// Interaction logic for customerDetailView.xaml
    /// </summary>
    public partial class CustomerDetailView : Window
    {
        public CustomerDetailView()
        {
            InitializeComponent();
            DataContext = new CustomerDetailViewModel();
        }
    }
}
