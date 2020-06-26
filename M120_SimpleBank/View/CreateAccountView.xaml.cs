using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SimpleBank.ViewModel;

namespace SimpleBank.View
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
