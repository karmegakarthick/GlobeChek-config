using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace globeChekServices
{
    public interface IConnectionServices
    {
        public MySqlCommand getConnection(String SpName);
        public void openConnection();
        public void closeConnection();
    }
}
