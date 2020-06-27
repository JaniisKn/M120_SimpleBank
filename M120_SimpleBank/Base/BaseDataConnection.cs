using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using M120_SimpleBank.Model;
using Dapper;

namespace M120_SimpleBank.Base
{
    #region IBaseDataConnection

    public interface IBaseDataConnection
    {
        void GetPersonById(int personID);
        void GetAllPersons();
        AccountType GetAccountTypes();

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        void CreatePerson(Person person);
        void CreateAccount(Account account);
    }

    #endregion

    public class BaseDataConnection : IBaseDataConnection
    {
        private const string ConnectionString = @"Data Source=LAPTOP-M57FQKF2\SQLEXPRESS;Initial Catalog=M120_SimpleBankDB;Integrated Security=True"; //Janis
        //private const string ConnectionString = @"Data Source=DESKTOP-FA5OAPQ\SQLEXPRESS;Initial Catalog=M120_SimpleBankDB;Integrated Security=True"; //Sacha

        public void GetPersonById(int personID)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address],[PostCode],[Place] FROM [dbo].[Persons] WHERE PersonID = @PersonID";
                var parameters = new { PersonID = personID };
                var person = connection.QuerySingle<Person>(sql, parameters);
            }
        }

        public void GetAllPersons()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address],[PostCode],[Place] FROM [dbo].[Persons]";
                var person = connection.Query<Person>(sql).ToList();
            }
        }

        public AccountType GetAccountTypes() {
            return null;
        }


        public void CreatePerson(Person person)
        {
            const string sql = "INSERT INTO [dbo].[Persons] ([LastName],[FirstName],[Birthday],[EMail],[TelNumber],[Address],[PostCode],[Place])" +
                                "VALUES(@Lastname, @FirstName, @Birthday, @Email, @TelNumber, @Address, @PostCode, @Place);";
            var insertPersonParameters = new
            {
                Lastname = person.LastName,
                Firstname = person.FirstName,
                Birthday = person.Birthday,
                Email = person.EMail,
                TelNumber = person.TelNumber,
                Address = person.Address,
                PostCode = person.PostCode,
                Place = person.Place
            };

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, insertPersonParameters);
            }
        }
        public void CreateAccount(Account account)
        {
            const string sql = "INSERT INTO [dbo].[Accounts]([Balance],[PersonID],[AccountTypeID])" +
                                "VALUES(@Balance, @PersonID, @AccountTypeID);";
            var insertAccountParameters = new
            {
                Balance = 1000.5,//account.Balance,
                PersonID = 1,//account.PersonID,
                AccountTypeID = 3//account.AccountTypeID
            };

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, insertAccountParameters);
            }
        }
    }
}
