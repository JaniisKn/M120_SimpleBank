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
    class BaseDataConnection
    {
        public string connectionString = @"Data Source=LAPTOP-M57FQKF2\SQLEXPRESS;Initial Catalog=SimpleBank;Integrated Security=True";

        private void GetPersonByID(int personID)
        {
            using (var connection = new SqlConnection(connectionString)) {
                string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address], pl.Place, pl.PostCode FROM [SimpleBank].[dbo].[Persons] pe" +
                            "Inner Join Places pl on pe.PlaceID = pe.PlaceID WHERE PersonID = @PersonID";
                var parameters = new { PersonID = personID };
                var person = connection.QuerySingle<Person>(sql,parameters);
            }
        }
        private void GetAllPersons()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address], pl.Place, pl.PostCode FROM [SimpleBank].[dbo].[Persons] pe" +
                            "Inner Join Places pl on pe.PlaceID = pe.PlaceID";
                var person = connection.Query<Person>(sql).ToList();
            }
        }
        private void CreatePerson(string firstName) { 
            
        }
    }
}
