using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace globeChekServices
{
    public class ConnectionServices
    {
        public String sqlConnection;
        public ConnectionServices()
        {
            sqlConnection = "server=globechek-qa.mysql.database.azure.com;user id=gcadmin@globechek-qa.mysql.database.azure.com;database=gc4_gcdev;password=P@ssword12345";
            //sqlConnection = "Data Source=DELL;Initial Catalog=passenger;Integrated Security=True";

        }
        public MySqlCommand getConnection(String SpName)
        {
            var connection = new MySqlConnection(sqlConnection);
            
            var command = new MySqlCommand(SpName, connection);
            return command;
        }

        public void openConnection()
        {
            SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Open();
        }

        public void closeConnection()
        {
            SqlConnection connection = new SqlConnection(sqlConnection);
            connection.Close();
        }

    }
}
