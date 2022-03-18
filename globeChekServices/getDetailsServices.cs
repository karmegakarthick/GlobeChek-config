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
        public IConnectionServices _IConnectionServices;
        public getDetailsServices(IConnectionServices connectionServices )
        {
            _IConnectionServices = connectionServices;
            sqlConnection = "server=globechek-qa.mysql.database.azure.com;user id=gcadmin@globechek-qa.mysql.database.azure.com;database=gc4_gcqa_new;password=P@ssword12345";
        }
        ConnectionServices ConnectionServices = new ConnectionServices();

        public object getConfigDetailsAsync(string ClientName)
        {
            Models models = new Models();
            List<object> res = new List<object>();
            var connection = new MySqlConnection(sqlConnection);
            string SpName = "ConfigCreation";
            var command = new MySqlCommand(SpName, connection);
            command.Parameters.AddWithValue("@ClientName", ClientName);
            command.CommandType = CommandType.StoredProcedure;
            //MySqlCommand command = _IConnectionServices.getConnection(SpName);
            //_IConnectionServices.openConnection();
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var storedProc = new Models
                {
                    clientName = (string)reader.GetValue(0),
                    clientID = (string)reader.GetValue(1),
                    deviceName = (string)reader.GetValue(2),
                    deviceID = (string)reader.GetValue(3),
                    locationID = (string)reader.GetValue(4),
                    locationName = (string)reader.GetValue(5)
                };
                res.Add(storedProc);
            }
            connection.Close();
            if (res.Count != 0)
            {
                return (res);
            }
            return ("invalid client name");

        }


    }
}