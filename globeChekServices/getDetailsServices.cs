using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using globeChekModels;
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
            Models models = new Models();
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
                var storedProc = new Models
                {
                    clientID = (string)reader.GetValue(0),
                    clientName = (string)reader.GetValue(1),
                    deviceName = (string)reader.GetValue(2),
                    deviceID = (string)reader.GetValue(3),
                    locationID = (string)reader.GetValue(4),
                    locationName = (string)reader.GetValue(5)
                };
                //List<Models> result = new List<Models>();
                //models.clientID = (string)reader.GetValue(0);
                //models.clientName = (string)reader.GetValue(1);
                //models.deviceName = (string)reader.GetValue(2);
                //models.deviceID = (string)reader.GetValue(3);
                //models.locationID = (string)reader.GetValue(4);
                //models.locationName = (string)reader.GetValue(5);
                //result.Add(models.clientID);
                //result.Add(models.clientName);
                //result.Add(models.deviceName);
                //result.Add(models.deviceID);
                //result.Add(models.locationID);
                //result.Add(models.locationName);

                res.Add(storedProc);



            }
            connection.Close();
            return (res);
        }
    }
}
