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

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        void CreatePerson(Person person);
    }

    #endregion

    public class BaseDataConnection : IBaseDataConnection
    {
        private const string ConnectionString = @"Data Source=LAPTOP-M57FQKF2\SQLEXPRESS;Initial Catalog=M120_SimpleBankDB;Integrated Security=True";

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

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param person="Includes all Information">The first name.</param>
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
                PostCode = "1234",
                Place = "kein Ort"
            };

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql, insertPersonParameters);
            }
        }
    }
}
