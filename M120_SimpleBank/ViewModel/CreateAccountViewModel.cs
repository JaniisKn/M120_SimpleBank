using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleBank.View;
using SimpleBank.Base;

namespace SimpleBank.ViewModel
{
    public class CreateAccountViewModel : Base.Base
    {
        public Action CloseEvent { get; set; }
        public ICommand GoBackCommand => goBackCommand ?? (goBackCommand = new RelayCommand(OnGoBack));
        private ICommand goBackCommand;
        public ICommand OpenCreateCustomerCommand => openCreateCustomerCommand ?? (openCreateCustomerCommand = new RelayCommand(OnOpenCreateCustomer));
        private ICommand openCreateCustomerCommand;

        private void OnGoBack(object sender)
        {
            FortuneOverviewView fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
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
