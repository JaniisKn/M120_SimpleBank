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
        #region Properties

        #region Model

        /// <summary>
        /// Gets the base data connection.
        /// </summary>
        public IBaseDataConnection BaseDataConnection => _baseDataAccess ?? (_baseDataAccess = new BaseDataConnection());
        private IBaseDataConnection _baseDataAccess;

        #endregion

        public Action CloseEvent { get; set; }

        #endregion

        #region Commands

        public ICommand GoBackCommand => goBackCommand ?? (goBackCommand = new RelayCommand(OnGoBack));
        private ICommand goBackCommand;

        private void OnGoBack(object sender)
        {
            FortuneOverviewView fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
            CloseEvent.Invoke();
        }

        public ICommand OpenCreateAccountCommand => openCreateAccountCommand ?? (openCreateAccountCommand = new RelayCommand(OnOpenCreateAccount));
        private ICommand openCreateAccountCommand;


        private void OnOpenCreateAccount(object sender)
        {
            var test = this.BaseDataConnection.CreatePerson("test");

            CreateAccountView createAccountView = new CreateAccountView();
            createAccountView.Show();
            CloseEvent.Invoke();
        }

        #endregion
    }
}
