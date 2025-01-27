using Dapper;
using SQIndustryThree.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SQIndustryThree.DAL
{
    public class AMSDAL
    {
        public DataTable VisitorReportFactory()
        {
            //int acc = 0;
            DataTable dt = new DataTable();

            var connection = new SqlConnection(DBConnection.GetConnectionString());
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {

                using (SqlCommand cmd = new SqlCommand("SP_VisitorReportFactory", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 12000;
                    //cmd.Parameters.AddWithValue("@artcode", SqlDbType.Int).Value = artcode;
                    //cmd.Parameters.AddWithValue("@sp", SqlDbType.Int).Value = sp;

                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable IOUReportInformation()
        {
            //int acc = 0;
            DataTable dt = new DataTable();
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("SP_IOUReportInformation", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 12000;
                    //cmd.Parameters.AddWithValue("@artcode", SqlDbType.Int).Value = artcode;
                    //cmd.Parameters.AddWithValue("@sp", SqlDbType.Int).Value = sp;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable VisitorReportForCentral()
        {
            //int acc = 0;
            DataTable dt = new DataTable();

            var connection = new SqlConnection(DBConnection.GetConnectionString());
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("SP_VisitorReportForCentral", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 12000;
                    //cmd.Parameters.AddWithValue("@artcode", SqlDbType.Int).Value = artcode;
                    //cmd.Parameters.AddWithValue("@sp", SqlDbType.Int).Value = sp;

                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<dynamic>> RetriveDate(string query)
        {
            IEnumerable<dynamic> Datas = new List<dynamic>();
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                                INSERT INTO QCaffeManagement..DeviceInfo(DeviceId)
                                VALUES(@Query)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                Datas = await connection.QueryAsync(Query, new { Query = query });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }


            return Datas;
        }

        public async Task CreateData(string query)
        {
            //var query = "INSERT INTO Companies (Name, Address, Country) VALUES (@Name, @Address, @Country)";
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                using (var transaction = connection.BeginTransaction())
                {
                    await connection.ExecuteAsync(query, transaction: transaction);
                    transaction.Commit();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}