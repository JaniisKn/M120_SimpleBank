using System.Windows;
using M120_SimpleBank.ViewModel;

namespace M120_SimpleBank.View
{
    /// <summary>
    /// Interaction logic for createCustomer.xaml
    /// </summary>
    public partial class CreateCustomerView : Window
    {
        public CreateCustomerView()
        {
            InitializeComponent();
            var viewModel = new CreateCustomerViewModel();
            DataContext = viewModel;
            if (viewModel.CloseEvent == null) {
                viewModel.CloseEvent = this.Close;
            }
        }
    }
}
