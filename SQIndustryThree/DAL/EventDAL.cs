using Dapper;
using DocSoOperation.Models;
using SQIndustryThree.DataManager;
using SQIndustryThree.Models;
using SQIndustryThree.Models.Event;
using SQIndustryThree.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using EventModel = SQIndustryThree.Models.Event.EventModel;

namespace SQIndustryThree.DAL
{
    public class EventDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        private string connStr = ConfigurationManager.ConnectionStrings["SQQEYEDatabase"].ConnectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rdr = null;

        public string GenerateID()
        {

            con = new SqlConnection(DBConnection.GetConnectionString());
            string value = "0000";
            int num = 0;
            try
            {
                // Fetch the latest ID from the database
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand("SELECT coalesce(MAX(GeneratedID),0) GeneratedID FROM [Event_Register]", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    rdr.Read();
                    num = Convert.ToInt32(rdr["GeneratedID"]);
                }
                rdr.Close();
                // Increase the ID by 1
               // num += 1;
                // Because incrementing a string with an integer removes 0's
                // we need to replace them. If necessary.
                //Value is between 0 and 10
                if (num <= 9)
                {
                    value = String.Concat("000", num);
                    //Value is between 9 and 100

                }
                else if (num <= 99)
                {
                    value = String.Concat("00", num);
                    //Value is between 999 and 1000
                }
                else if (num <= 999)
                {
                    value = String.Concat("0", num); ;
                }
            }
            catch (Exception ex)
            {
                // If an error occurs, check the connection state and close it if necessary.
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                value = "0000";
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return value;
        }

        public List<EventModel> GetAllEvents()
        {
            List<EventModel> eventModels = new List<EventModel>();
            con = new SqlConnection(DBConnection.GetConnectionString());

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand("sp_GetAllEvents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        EventModel eventModel = new EventModel();
                        eventModel.EventID = (int)rdr["EventID"];
                        eventModel.EventName = rdr["EventName"].ToString();
                        eventModel.Rules = rdr["Rules"].ToString();
                        eventModels.Add(eventModel);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return eventModels;
        }

        public List<LocationModel> GetAllLocation()
        {
            con = new SqlConnection(DBConnection.GetConnectionString());
            List<LocationModel> location = new List<LocationModel>();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd = new SqlCommand("sp_GetAllLocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        LocationModel lc = new LocationModel();
                        lc.LocationId = (int)rdr["LocationId"];
                        lc.LocationName = rdr["LocationName"].ToString();
                        location.Add(lc);
                    }
                }                
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return location;
        }

        //public DataTable EventCreate(int eventId, int location, string name, string employeeId, string designation, string department, int sbu, int userId)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        con = new SqlConnection(DBConnection.GetConnectionString());

        //        if (con.State == ConnectionState.Closed)
        //            con.Open();

        //        string query = @"
        //                declare @GeneratedID nvarchar(max) = (SELECT coalesce(MAX(cast(GeneratedID as int)),0)+1 FROM [Event_Register])
        //                  declare @message nvarchar(max)
        //                  declare @registerID nvarchar(max)
        //                  declare @PrimaryKey nvarchar(max)

        //                  IF NOT EXISTS(SELECT EmployeeID FROM [Event_Register] where EmployeeID = @EmployeeID)
        //                  begin
	       //                 Insert Into Event_Register(GeneratedID,EventID,LocationID,Name,EmployeeID,Designation,Department,BusinessUnitID,CreatedDate,UserID) 
        //                    Values(@GeneratedID, @EventID, @LocationID, @Name, @EmployeeID, @Designation, @Department, @BusinessUnitID, Getdate(), @UserID)
	       //                 set @message = 'Data Inserted Successfully'
        //                    SET @PrimaryKey=SCOPE_IDENTITY();
        //                    set @registerID = @GeneratedID
	       //                 print @message
        //                  end
        //                  ELSE
        //                  begin
	       //                 set @message = 'Registration already exists for the employee code:'+ @EmployeeID
        //                    set @registerID = '';
	       //                 print @message
        //                  end
                            
        //                    select @message message, @registerID registerId

        //                    EXEC [sp_EventSentMailFromDatabase] @PrimaryKey, @UserID, 'ashiqur.rahman@sqgc.com'
        //                  ";

        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.CommandType = CommandType.Text;
        //        //cmd.Parameters.Add("@GeneratedID", SqlDbType.Int).Value = supplierID;
        //        cmd.Parameters.Add("@EventID", SqlDbType.Int).Value = eventId;
        //        cmd.Parameters.Add("@LocationID", SqlDbType.Int).Value = location;
        //        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = name;
        //        cmd.Parameters.Add("@EmployeeID", SqlDbType.NVarChar).Value = employeeId;
        //        cmd.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = designation;
        //        cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = department;
        //        cmd.Parameters.Add("@BusinessUnitID", SqlDbType.Int).Value = sbu;
        //        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
        //        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        //        adpt.Fill(dt);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //            con.Close();
        //    }
        //}
        public ResultResponse EventCreate(EventRegisterModel visitor, int UserId)
        {
            try
            {

                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    string str1 = new JavaScriptSerializer().Serialize((object)visitor.MemberDetailsList);
                    string str2 = new JavaScriptSerializer().Serialize((object)visitor.ItemDetailsList);
                    visitor.MemberDetailsList = (List<EventRegisterModel>)null;
                    visitor.ItemDetailsList = (List<EventRegisterModel>)null;
                    new JavaScriptSerializer().Serialize((object)visitor);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@EventID", (object)visitor.EventID);
                    dynamicParameters.Add("@LocationID", (object)visitor.LocationID);
                    dynamicParameters.Add("@Name", (object)visitor.Name);
                    dynamicParameters.Add("@EmployeeID", (object)visitor.EmployeeID);
                    dynamicParameters.Add("@Email", (object)visitor.Email);
                    dynamicParameters.Add("@Designation", (object)visitor.Designation);
                    dynamicParameters.Add("@Department", (object)visitor.Department);
                    dynamicParameters.Add("@BusinessUnitID", (object)visitor.BusinessUnitID);
                    dynamicParameters.Add("@UserID", (object)UserId);
                    dynamicParameters.Add("@ItemJson", (object)str2);
                    dynamicParameters.Add("@MemberJosn", (object)str1);
                    int num = cnn.Execute("SP_EventDataInsert", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
                    return new ResultResponse()
                    {
                        pk = num,
                        isSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AllEventModel> GetAllEventsRequest(int UserId)
        {
            con = new SqlConnection(DBConnection.GetConnectionString());
            List<AllEventModel> allEvents = new List<AllEventModel>();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = @"select r.RegisterID, r.GeneratedID, e.EventName, l.LocationName, r.Name, r.UserID, 
  'SQ'+(r.EmployeeID) as EmployeeID, r.Designation, r.Department, CASE 
				WHEN r.BusinessUnitId = 0 THEN 'Central'
				ELSE b.BusinessUnitName
				END AS BusinessUnitName from Event_Register r
  left join
  EventTable e on r.EventID = e.EventID
  left join
  LocationTable l on r.LocationID = l.LocationId
  left join
	BusinessUnit b ON r.BusinessUnitId = --ISNULL(b.BusinessUnitId, 0)
	CASE WHEN b.BusinessUnitId IS NULL THEN 0
	WHEN b.BusinessUnitId = b.BusinessUnitId THEN b.BusinessUnitId
	END
  where r.UserID = 	@UserId";

                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        AllEventModel all = new AllEventModel();
                        all.RegisterID = (int)rdr["RegisterID"];
                        all.GeneratedID = rdr["GeneratedID"].ToString();
                        all.EventName = rdr["EventName"].ToString();
                        all.LocationName = rdr["LocationName"].ToString();
                        all.Name = rdr["Name"].ToString();
                        all.EmployeeID = rdr["EmployeeID"].ToString();
                        all.Designation = rdr["Designation"].ToString();
                        all.Department = rdr["Department"].ToString();
                        all.BusinessUnitName = rdr["BusinessUnitName"].ToString();
                        allEvents.Add(all);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return allEvents;
        }

        public List<AllEventModel> GetAllRequest()
        {
            con = new SqlConnection(DBConnection.GetConnectionString());
            List<AllEventModel> allEvents = new List<AllEventModel>();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string query = @"select r.RegisterID, r.GeneratedID, e.EventName, l.LocationName, r.Name, r.UserID, 
                                   'SQ'+(r.EmployeeID) as EmployeeID, r.Designation, r.Department, CASE 
				                                WHEN r.BusinessUnitId = 0 THEN 'Central'
				                                ELSE b.BusinessUnitName
				                                END AS BusinessUnitName from Event_Register r
                                  left join
                                  EventTable e on r.EventID = e.EventID
                                  left join
                                  LocationTable l on r.LocationID = l.LocationId
                                  left join
	                                BusinessUnit b ON r.BusinessUnitId = --ISNULL(b.BusinessUnitId, 0)
	                                CASE WHEN b.BusinessUnitId IS NULL THEN 0
	                                WHEN b.BusinessUnitId = b.BusinessUnitId THEN b.BusinessUnitId
	                                END";
                //where r.UserID = 	@UserId

                cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        AllEventModel all = new AllEventModel();
                        all.RegisterID = (int)rdr["RegisterID"];
                        all.GeneratedID = rdr["GeneratedID"].ToString();
                        all.EventName = rdr["EventName"].ToString();
                        all.LocationName = rdr["LocationName"].ToString();
                        all.Name = rdr["Name"].ToString();
                        all.EmployeeID = rdr["EmployeeID"].ToString();
                        all.Designation = rdr["Designation"].ToString();
                        all.Department = rdr["Department"].ToString();
                        all.BusinessUnitName = rdr["BusinessUnitName"].ToString();
                        allEvents.Add(all);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return allEvents;
        }

    }
}