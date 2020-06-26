using System.Windows;
using M120_SimpleBank.ViewModel;

namespace M120_SimpleBank.View
{
    /// <summary>
    /// Interaction logic for createAccount.xaml
    /// </summary>
    public partial class CreateAccountView : Window
    {
        public CreateAccountView()
        {
            InitializeComponent();
            var viewModel = new CreateAccountViewModel();
            DataContext = viewModel;
            if (viewModel.CloseEvent == null) {
                viewModel.CloseEvent = this.Close;
            }
        }
    }
}
