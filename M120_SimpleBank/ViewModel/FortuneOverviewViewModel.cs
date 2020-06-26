using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleBank.View;
using SimpleBank.Base;
using System.ComponentModel;

namespace SimpleBank.ViewModel
{
    public class FortuneOverviewViewModel : Base.Base
    {
        public Action CloseEvent { get; set; }
        public ICommand OpenCreateAccountCommand => openCreateAccountCommand ?? (openCreateAccountCommand = new RelayCommand(OnOpenCreateAccount));
        private ICommand openCreateAccountCommand;
        public ICommand OpenCreateCustomerCommand => openCreateCustomerCommand ?? (openCreateCustomerCommand = new RelayCommand(OnOpenCreateCustomer));
        private ICommand openCreateCustomerCommand;

        private void OnOpenCreateAccount(object sender)
        {
            CreateAccountView createAccountView = new CreateAccountView();
            createAccountView.Show();
            CloseEvent.Invoke();
        }

        private void OnOpenCreateCustomer(object sender) 
        {
            CreateCustomerView createCustomerView = new CreateCustomerView();
            createCustomerView.Show();
            CloseEvent.Invoke();
        }
    }
}
