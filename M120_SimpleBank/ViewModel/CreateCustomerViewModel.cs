using System;
using System.Windows;
using M120_SimpleBank.View;
using System.Windows.Input;
using M120_SimpleBank.Base;
using M120_SimpleBank.Model;

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

        public Person NewPerson
        {
            get => _newPerson ?? (_newPerson = new Person());
            set
            {
                _newPerson = value;
                RaisePropertyChanged();
            }
        }
        private Person _newPerson;
        
        #endregion

        #region Commands

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

        #region Save Person

        public ICommand SavePersonCommand => _savePersonCommand ?? (_savePersonCommand = new RelayCommand(OnSavePerson));
        private ICommand _savePersonCommand;

        private void OnSavePerson(object sender)
        {
            if (string.IsNullOrEmpty(NewPerson.FirstName.Trim()) || string.IsNullOrEmpty(NewPerson.LastName.Trim()) || string.IsNullOrEmpty(NewPerson.EMail.Trim()) || string.IsNullOrEmpty(NewPerson.Address.Trim()) || string.IsNullOrEmpty(NewPerson.Place.Trim()))
            {
                MessageBox.Show("Please check if you filled out all obligatory fields.");
                return;
            }

            this.BaseDataConnection.CreatePerson(NewPerson);

            MessageBox.Show("Successfully created new person.");

            var fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
            CloseEvent.Invoke();
        }

        #endregion

        #endregion
    }
}
