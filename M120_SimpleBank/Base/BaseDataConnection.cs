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
        Person GetPersonById(int personID);
        List<Person> GetAllPersons();
        List<AccountType> GetAllAccountTypes();
        void CreatePerson(Person person);
        void CreateAccount(Account account);
    }

    #endregion

    public class BaseDataConnection : IBaseDataConnection
    {
        private const string ConnectionString = @"Data Source=LAPTOP-M57FQKF2\SQLEXPRESS;Initial Catalog=M120_SimpleBankDB;Integrated Security=True"; //Janis
        //private const string ConnectionString = @"Data Source=DESKTOP-FA5OAPQ\SQLEXPRESS;Initial Catalog=M120_SimpleBankDB;Integrated Security=True"; //Sacha

        public Person GetPersonById(int personID)
        {
            string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address],[PostCode],[Place] FROM [dbo].[Persons] WHERE PersonID = @PersonID";
            var parameters = new { PersonID = personID };

            using (var connection = new SqlConnection(ConnectionString))
            {   
                try
                {
                    return connection.QuerySingle<Person>(sql, parameters);
                }
                catch (Exception)
                {
                    return null;
                } 
            }
        }

        public List<Person> GetAllPersons()
        {
            string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address],[PostCode],[Place] FROM [dbo].[Persons]";
            
            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    return connection.Query<Person>(sql).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<AccountType> GetAllAccountTypes() 
        {
            string sql = "SELECT [AccountTypeID],[name],[InterestRate] FROM [M120_SimpleBankDB].[dbo].[AccountTypes]";

            using (var connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    return connection.Query<AccountType>(sql).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
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
                Balance = account.Balance,
                PersonID = account.PersonID,
                AccountTypeID = account.AccountTypeID
            };

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, insertAccountParameters);
            }
        }
    }
}
