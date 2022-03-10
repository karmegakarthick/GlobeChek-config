using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace globeChekServices
{
    public class getDetailsServices : IGetDetails
    {
         public String sqlConnection;
        
        public getDetailsServices()
        {
            sqlConnection = "server=globechek-qa.mysql.database.azure.com;user id=gcadmin@globechek-qa.mysql.database.azure.com;database=gc4_gcqa_new;password=P@ssword12345";
            //sqlConnection = "Data Source=DELL;Initial Catalog=passenger;Integrated Security=True";

        }
        ConnectionServices ConnectionServices = new ConnectionServices();
        //public object getConfigDetails(String clientName)
        //{
        //    List<String> res = new List<String>();
        //    string SpName = "dbo.ConfigCreation";
        //    //SqlCommand cmd = ConnectionServices.getConnection(SpName);
        //    //cmd.Parameters.AddWithValue("@orgName", clientName);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    //ConnectionServices.openConnection();
        //    SqlConnection connection = new SqlConnection(sqlConnection);
        //    SqlCommand cmd = new SqlCommand(SpName, connection);
        //    //return cmd;

        //    connection.Open();
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {

        //        }
        //    }
        //    ConnectionServices.closeConnection();
        //    dr.Close();
        //    return (res);
        //}

        public object getConfigDetailsAsync(String clientName)
        {
            List<object> res = new List<object>();
            var connection = new MySqlConnection(sqlConnection);
            string SpName = "ConfigCreation";
            var command = new MySqlCommand(SpName, connection);
            //var command = ConnectionServices.getConnection(spName);
            command.Parameters.AddWithValue("@orgName", clientName);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                List<object> result = new List<object>();
                var clientID = reader.GetValue(0);
                var clientname = reader.GetValue(1);
                var deviceName = reader.GetValue(2);
                var deviceID = reader.GetValue(3);
                var locationID = reader.GetValue(4);
                var locationName = reader.GetValue(5);
                result.Add(clientID);
                result.Add(clientname);
                result.Add(deviceName);
                result.Add(deviceID);
                result.Add(locationID);
                result.Add(locationName);

                res.Add(result);



            }
            connection.Close();
            return (res);
        }
    }
}
