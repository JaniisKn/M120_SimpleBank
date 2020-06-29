using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using M120_SimpleBank.View;
using M120_SimpleBank.Base;
using M120_SimpleBank.Model;
using System.Windows.Controls;

namespace M120_SimpleBank.ViewModel
{
    public class FortuneOverviewViewModel : Base.Base
    {
        #region Initialization

        public FortuneOverviewViewModel()
        {
            Kunden = this.BaseDataConnection.GetAllPersons();
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

        public Action CloseEvent { get; set; }

        #endregion

        #region Commands

        #region Open Customer Detail

        public ICommand OpenCustomerDetailCommand => _openCustomerDetailCommand ?? (_openCustomerDetailCommand = new RelayCommand(OnOpenCustomerDetailCommand));
        private ICommand _openCustomerDetailCommand;
        private void OnOpenCustomerDetailCommand(object sender)
        {
            var customerDetailView = new CustomerDetailView();
            customerDetailView.Show();
            CloseEvent.Invoke();
        }

        #endregion

        #region Open create account

        public ICommand OpenCreateAccountCommand => _openCreateAccountCommand ?? (_openCreateAccountCommand = new RelayCommand(OnOpenCreateAccount));
        private ICommand _openCreateAccountCommand;
        private void OnOpenCreateAccount(object sender)
        {
            var createAccountView = new CreateAccountView();
            createAccountView.Show();
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

        #endregion
    }
}
