﻿using System;
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
        void CreatePerson(string firstName);
    }

    #endregion

    public class BaseDataConnection : IBaseDataConnection
    {
        private const string ConnectionString = @"Data Source=LAPTOP-M57FQKF2\SQLEXPRESS;Initial Catalog=SimpleBank;Integrated Security=True";

        public void GetPersonById(int personID)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address], pl.Place, pl.PostCode FROM [SimpleBank].[dbo].[Persons] pe" +
                            "Inner Join Places pl on pe.PlaceID = pe.PlaceID WHERE PersonID = @PersonID";
                var parameters = new { PersonID = personID };
                var person = connection.QuerySingle<Person>(sql, parameters);
            }
        }

        public void GetAllPersons()
        {
            string sql = "SELECT [PersonID],[LastName],[FirstName],[EMail],[TelNumber],[Address], pl.Place, pl.PostCode FROM [SimpleBank].[dbo].[Persons] pe" +
                         "Inner Join Places pl on pe.PlaceID = pe.PlaceID";

            using (var connection = new SqlConnection(ConnectionString))
            {

                var person = connection.Query<Person>(sql).ToList();
            }
        }

        /// <summary>
        /// Creates the person.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        public void CreatePerson(string firstName)
        {
            const string sql = "INSERT INTO Person VALUES (@Firstname)";

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute(sql);
            }
        }
    }
}
