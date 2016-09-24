using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Settings
{
    public static class Configure
    {
        private static string _connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString();

        public static string ConnectionString
        {
            get { return _connectionString; }
            private set { _connectionString = value; }
        }

        private static SqlConnection _SqlConnection = new SqlConnection(ConnectionString);
        public static SqlConnection SQLConnection
        {
            get { return _SqlConnection; }
            private set { _SqlConnection = value; }
        }
    }
}