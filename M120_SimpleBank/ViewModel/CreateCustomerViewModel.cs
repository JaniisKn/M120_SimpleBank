using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M120_SimpleBank.View;
using System.ComponentModel;
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
            get => newPerson ?? (newPerson = new Person());
            set
            {
                newPerson = value;
                RaisePropertyChanged();
            }
        }
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
            CreateAccountView createAccountView = new CreateAccountView();
            createAccountView.Show();
            CloseEvent.Invoke();
        }
        
        public ICommand SavePersonCommand => savePersonCommand ?? (savePersonCommand = new RelayCommand(OnSavePerson));
        private ICommand savePersonCommand;
        private Person newPerson;

        private void OnSavePerson(object sender)
        {
            this.BaseDataConnection.CreatePerson(newPerson);


            FortuneOverviewView fortuneOverviewView = new FortuneOverviewView();
            fortuneOverviewView.Show();
            CloseEvent.Invoke();
        }

        #endregion
    }
}
