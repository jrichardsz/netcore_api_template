using System;
using MySql.Data.MySqlClient;

namespace Src.Database
{
    public class Datasource : IDisposable
    {
        public MySqlConnection Connection;

        public Datasource(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            this.Connection.Close();
        }
    }
}


