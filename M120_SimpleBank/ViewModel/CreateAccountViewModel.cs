using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using M120_SimpleBank.View;
using M120_SimpleBank.Base;
using M120_SimpleBank.Model;

namespace M120_SimpleBank.ViewModel
{
    public class CreateAccountViewModel : Base.Base
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
        
        public Account NewAccount
        {
            get => newAccount ?? (newAccount = new Account());
            set
            {
                newAccount = value;
                PersonID = value;
                AccountTypeID = value;
                Balance = value;

                RaisePropertyChanged();
            }
        }

        #endregion

        public ICommand GoBackCommand => goBackCommand ?? (goBackCommand = new RelayCommand(OnGoBack));
        private ICommand goBackCommand;

        private void OnGoBack(object sender)
        {
            FortuneOverviewView fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
            CloseEvent.Invoke();
        }
        
        public ICommand OpenCreateCustomerCommand => openCreateCustomerCommand ?? (openCreateCustomerCommand = new RelayCommand(OnOpenCreateCustomer));
        private ICommand openCreateCustomerCommand;

        private void OnOpenCreateCustomer(object sender) 
        {
            CreateCustomerView createCustomerView = new CreateCustomerView();
            createCustomerView.Show();
            CloseEvent.Invoke();
        }

        public ICommand SaveAccountCommand => saveAccountCommand ?? (saveAccountCommand = new RelayCommand(OnSaveAccount));
        private ICommand saveAccountCommand;
        private Account newAccount;
        private Account PersonID;
        private Account AccountTypeID;
        private Account Balance;

        private void OnSaveAccount(object sender) 
        {
            this.BaseDataConnection.CreateAccount(NewAccount);

            CreateCustomerView createCustomerView = new CreateCustomerView();
            createCustomerView.Show();
            CloseEvent.Invoke();
        }
    }
}
