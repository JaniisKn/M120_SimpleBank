using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M120_SimpleBank.View;
using System.ComponentModel;
using System.Windows.Input;
using M120_SimpleBank.Base;

namespace M120_SimpleBank.ViewModel
{
    public class CreateCustomerViewModel : Base.Base
    {
        public Action CloseEvent { get; set; }
        public ICommand GoBackCommand => goBackCommand ?? (goBackCommand = new RelayCommand(OnGoBack));
        private ICommand goBackCommand;
        public ICommand OpenCreateAccountCommand => openCreateAccountCommand ?? (openCreateAccountCommand = new RelayCommand(OnOpenCreateAccount));
        private ICommand openCreateAccountCommand;

        private void OnGoBack(object sender)
        {
            FortuneOverviewView fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
            CloseEvent.Invoke();
        }

        private void OnOpenCreateAccount(object sender)
        {
            CreateAccountView createAccountView = new CreateAccountView();
            createAccountView.Show();
            CloseEvent.Invoke();
        }
    }
}
