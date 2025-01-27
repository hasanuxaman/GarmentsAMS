using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Utilities
{
    public class DBConnection
    {
        public static string _connectionString;
        public static string _connectionStringQMSDatabase;
        public static string _connectionStringWorkerIncentive;

        public static string GetConnectionString()
        {


            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["SQQEYEDatabase"].ConnectionString;
            }

            return _connectionString;
        }
        public static string QMSDatabaseGetConnectionString()
        {


            if (string.IsNullOrEmpty(_connectionStringQMSDatabase))
            {
                _connectionStringQMSDatabase = ConfigurationManager.ConnectionStrings["QMSDatabase"].ConnectionString;
            }

            return _connectionStringQMSDatabase;
        }
        public static string WorkerIncentiveGetConnectionString()
        {


            if (string.IsNullOrEmpty(_connectionStringWorkerIncentive))
            {
                _connectionStringWorkerIncentive = ConfigurationManager.ConnectionStrings["WorkerIncentive"].ConnectionString;
            }

            return _connectionStringWorkerIncentive;
        }
    }
}