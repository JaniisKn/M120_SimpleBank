using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using M120_SimpleBank.View;
using M120_SimpleBank.Base;
using M120_SimpleBank.Model;

namespace M120_SimpleBank.ViewModel
{
    public class CreateAccountViewModel : Base.Base
    {
        #region Initialize

        public CreateAccountViewModel()
        {
            Kunden = this.BaseDataConnection.GetAllPersons();
            KontoTypes = this.BaseDataConnection.GetAllAccountTypes();
        }

        #endregion

        #region Properties

        #region Model

        /// <summary>
        /// Gets the base data connection.
        /// </summary>
        public IBaseDataConnection BaseDataConnection => _baseDataAccess ?? (_baseDataAccess = new BaseDataConnection());
        private IBaseDataConnection _baseDataAccess;

        #endregion

        public IList<Person> Kunden
        {
            get => _kunden ?? (_kunden = new ObservableCollection<Person>());
            set
            {
                _kunden = value;
                RaisePropertyChanged();
            }
        }
        private IList<Person> _kunden;

        public IList<AccountType> KontoTypes
        {
            get => _kontoTypes ?? (_kontoTypes = new ObservableCollection<AccountType>());
            set
            {
                _kontoTypes = value;
                RaisePropertyChanged();
            }
        }
        private IList<AccountType> _kontoTypes;

        public Account NewAccount
        {
            get => _newAccount ?? (_newAccount = new Account());
            set
            {
                _newAccount = value;
                RaisePropertyChanged();
            }
        }
        private Account _newAccount;


        public Action CloseEvent { get; set; }

        #endregion

        #region Comands

        #region Back

        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack));
        private ICommand _goBackCommand;

        private void OnGoBack(object sender)
        {
            var fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
            CloseEvent.Invoke();
        }

        #endregion

        #region Open create customer

        public ICommand OpenCreateCustomerCommand => _openCreateCustomerCommand ?? (_openCreateCustomerCommand = new RelayCommand(OnOpenCreateCustomer));
        private ICommand _openCreateCustomerCommand;

        private void OnOpenCreateCustomer(object sender) 
        {
            var createCustomerView = new CreateCustomerView();
            createCustomerView.Show();
            CloseEvent.Invoke();
        }

        #endregion

        #region Save account

        public ICommand SaveAccountCommand => _saveAccountCommand ?? (_saveAccountCommand = new RelayCommand(OnSaveAccount));
        private ICommand _saveAccountCommand;

        private void OnSaveAccount(object sender) 
        {
            if (NewAccount.Balance <= 0)
            {
                MessageBox.Show("Das Startkapital muss grösser als 0CHF sein.");
                return;
            }

            if (NewAccount.PersonID <= 0 || NewAccount.AccountTypeID <= 0)
            {
                MessageBox.Show("Bitte eine Person und eine Kontoart auswählen.");
                return;
            }

            this.BaseDataConnection.CreateAccount(NewAccount);

            MessageBox.Show("Neuers Konto wurde erfolgreich erstellt.");

            var fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
            CloseEvent.Invoke();
        }

        #endregion
        
        #endregion
    }
}
