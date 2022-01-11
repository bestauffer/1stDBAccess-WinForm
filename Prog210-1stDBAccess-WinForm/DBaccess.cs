using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Prog210_1stDBAccess_WinForm
{
    public class Customer
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
    }
    public static class DBaccess
    {
        private const string connectString = @"Server=localhost; Database=northwind; Integrated Security=True";
        public static List<Customer> GetData(string country)
        {
            if (country.Length < 3)
            {
                country = "USA";
            }

            //sets what tables we are going to look for in the database
            SqlCommand selectCommand = new SqlCommand
            {
                Connection = new SqlConnection(connectString),
                CommandText = "Select CompanyName, ContactName, Country, City from Customers WHERE Country =@Country"
            };
            //limits thge search to those from the country specified
            selectCommand.Parameters.Add("@Country", SqlDbType.VarChar, 50);
            selectCommand.Parameters["@Country"].Value = country;
            //opens the connection
            selectCommand.Connection.Open();

            SqlDataReader sqlReader = selectCommand.ExecuteReader();
            List<Customer> myList = new List<Customer>();
            while (sqlReader.Read()) // or can use the column names directly
            {
                Customer anotherOne = new Customer
                {
                    CompanyName = sqlReader["CompanyName"].ToString(),
                    ContactName = sqlReader["ContactName"].ToString(),
                    City = sqlReader["City"].ToString()
                };
                myList.Add(anotherOne);
            }

            sqlReader.Close();
            selectCommand.Connection.Close();
            return myList;
        }
    }
}
