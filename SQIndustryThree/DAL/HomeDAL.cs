using Dapper;
using DocSoOperation.Models;
using SQIndustryThree.DataManager;
using SQIndustryThree.Models;
using SQIndustryThree.Models.Capex;
using SQIndustryThree.Models.Courier;
using SQIndustryThree.Models.Vehicle;
using SQIndustryThree.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Script.Serialization;

namespace SQIndustryThree.DAL
{
    public class HomeDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public bool SAveUsersToDataBase(UserInformation users)
        {
            bool result = true;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userName", users.UserInformationName));
                aParameters.Add(new SqlParameter("@userEmail", users.UserInformationEmail));
                aParameters.Add(new SqlParameter("@userPassword",PasswordManager.Encrypt(users.UserInformationPassword)));
                aParameters.Add(new SqlParameter("@userPhoneNumber",users.UserInformationPhoneNumber));
                aParameters.Add(new SqlParameter("@userType", (int)users.UserTypeId));
                aParameters.Add(new SqlParameter("@createBY", 1));
                aParameters.Add(new SqlParameter("@SqIdNumber", users.UserSQNumber));
                aParameters.Add(new SqlParameter("@DesignationID", (int)users.DesignationId));
                aParameters.Add(new SqlParameter("@BusinessUnitId",(int) users.BusinessUnitId));
                result = accessManager.SaveData("sp_SaveUserInformation", aParameters);
                return result;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public UserInformation CheckUserLogin(string UserEmail, string UserPassword)
        {
            UserInformation user = new UserInformation();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userName", UserEmail));
                aParameters.Add(new SqlParameter("@userPassword", PasswordManager.Encrypt(UserPassword)));
                SqlDataReader dr= accessManager.GetSqlDataReader("sp_CheckUserLogin", aParameters);
                while (dr.Read())
                {
                    user.UserInformationId = (int)dr["UserId"];
                    user.UserInformationName = dr["UserName"].ToString();
                    user.UserInformationEmail = dr["UserEmail"].ToString();
                    //user.UserInformationPassword = dr["UserPassword"].ToString();
                    user.DesignationId = (int)dr["DesignationID"];
                    user.IsSupplier = Convert.ToInt32(dr["IsSupplier"]);
                }


                return user;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }


        public UserInformation GetUserInformation(int userId)
        {
            UserInformation user = new UserInformation();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userId", userId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetUserInformation", aParameters);
                while (dr.Read())
                {
                    user.UserInformationName = dr["UserName"].ToString();
                    user.UserInformationEmail = dr["UserEmail"].ToString();
                    user.UserInformationPhoneNumber = dr["UserPhone"].ToString();
                    user.UserSQNumber = dr["SqIDNumber"].ToString();
                    user.DesignationName = dr["DesignationName"].ToString();
                }

                return user;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<ModuleModel> GetModuleByUser(int userId,int ProjectId)
        {
            List<ModuleModel> moduleList = new List<ModuleModel>();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userId", userId));
                aParameters.Add(new SqlParameter("@prjectId", ProjectId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetModulePermissionUser", aParameters);
                while (dr.Read())
                {
                    ModuleModel moduleModel = new ModuleModel();
                    moduleModel.ModuleKey =(int) dr["Modulekey"];
                    moduleModel.ModuleName =dr["ModuleName"].ToString();
                    moduleModel.ModuleValue =dr["ModuleValue"].ToString();
                    moduleModel.ModuleController =dr["ModuleController"].ToString();
                    moduleList.Add(moduleModel);
                }
                return moduleList;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public List<ModuleModel> GetProjectmenu(int userId)
        {
            List<ModuleModel> moduleList = new List<ModuleModel>();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@UserId", userId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ProjectPermission", aParameters);
                while (dr.Read())
                {
                    ModuleModel moduleModel = new ModuleModel();
                    moduleModel.ModuleKey = (int)dr["ProjectId"];
                    moduleModel.ModuleName = dr["ProjectName"].ToString();
                    moduleList.Add(moduleModel);
                }
                return moduleList;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public bool changePassword(int userId,string newpass)
        {
            bool success = false;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userId", userId));
                aParameters.Add(new SqlParameter("@newPass", PasswordManager.Encrypt(newpass)));
                success = accessManager.UpdateData("sp_changePassword", aParameters);
                return success;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public bool RecoveryPassword(int userId)
        {
            String password = "",name="",email="";
            bool success = false;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userId", userId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_PasswordRecovery", aParameters);
                while (dr.Read())
                {
                    password = dr["UserPassword"].ToString();
                    name = dr["UserName"].ToString();
                    email= dr["UserEmail"].ToString();
                }
                if(name!="" && email != "")
                {
                    try
                    {
                        MailMessage message = new MailMessage();
                        SmtpClient smtp = new SmtpClient();
                        message.From = new MailAddress("noreply@sqgc.com");
                        message.To.Add(new MailAddress(email));
                        message.Subject = "AMS Password Recovery";
                        message.IsBodyHtml = true; //to make message body as html  
                        message.Body = "Dear Mr."+name+ "<br/> You requested for Recover your password <br/> Your Password for the Approval management system is : " + PasswordManager.Decrypt(password)+ " <br/>" +
                            "Thank you For Being with Us <br/>" +
                             "<br/>Thank You<br/> <a href='http://10.12.13.163:8080/'>Approval Management System</a><br/><br/>sqgc.com";
                        smtp.Port = 587;
                        smtp.Host = "smtp.office365.com"; //for gmail host  
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("noreply@sqgc.com", "ysd9kE6&195{rcU");
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Send(message);
                        success = true;

                    }
                    catch (Exception) { }
                }
                return success;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public bool CreateDesignation(string designationName)
        {
            bool success = false;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@desinationName", designationName));
                success = accessManager.SaveData("sp_CreateDesignation", aParameters);
                return success;
            }
            catch (Exception e)
            {
                accessManager.SqlConnectionClose(true);
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public DataTable LoadProductionUnit(int business_unit)
        {
            //int acc = 0;
            DataTable dt = new DataTable();



            var connection = new SqlConnection(DBConnection.QMSDatabaseGetConnectionString());
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {

                using (SqlCommand cmd = new SqlCommand("sp_GetBusinessUnitWiseProductionUnit", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@BusinessUniId", SqlDbType.NVarChar).Value = business_unit;
                    // cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = EndDate;

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
        public DataTable LoadModule()
        {
            //int acc = 0;
            DataTable dt = new DataTable();



            var connection = new SqlConnection(DBConnection.QMSDatabaseGetConnectionString());
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            try
            {

                using (SqlCommand cmd = new SqlCommand("sp_GetFloorModule", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@BusinessUniId", SqlDbType.NVarChar).Value = business_unit;
                    // cmd.Parameters.Add("@EndDate", SqlDbType.NVarChar).Value = EndDate;

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


        public ResultResponse SaveQMSUser(QMSUserCreate allocationDetails)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(DBConnection.QMSDatabaseGetConnectionString()))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();

                    foreach (var item in allocationDetails.QMSUserCreateDetails)
                    {
                        DynamicParameters sqlParams = new DynamicParameters();
                        sqlParams.Add("@BusinessUnitId", allocationDetails.BusinessUnitId);
                        sqlParams.Add("@ProductionUnitId", allocationDetails.ProductionUnitId);
                        sqlParams.Add("@ModuleId", allocationDetails.ModuleId);
                        sqlParams.Add("@LineId", (object)item.LineId);
                        sqlParams.Add("@DisplayName", (object)item.DisplayName);
                        sqlParams.Add("@UserName", (object)item.UserName);
                        sqlParams.Add("@Password", PasswordManager.Encrypt(item.Password));
                        int num = cnn.Execute("SP_QMSUserDataInsert", (object)sqlParams, commandType: new CommandType?(CommandType.StoredProcedure));
                    }

                    return new ResultResponse
                    {
                        isSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<UserInformationModel> GetAllBusinessUnit(
         int Status,
         int Pgress)
        {
            List<UserInformationModel> CourierRequestModelList = new List<UserInformationModel>();
            try
            {
                this.accessManager.SqlConnectionOpen(DataBase.SQQeye);
                SqlDataReader sqlDataReader = this.accessManager.GetSqlDataReader("sp_GetAllBusinessUnitInfo", new List<SqlParameter>()
        {
          new SqlParameter("@Status", (object) Status),
          new SqlParameter("@Progress", (object) Pgress)
        });
                while (sqlDataReader.Read())
                    CourierRequestModelList.Add(new UserInformationModel()
                    {

                        BusinessUnitId = (int)sqlDataReader["BusinessUnitId"],
                        BusinessUnitName = sqlDataReader["BusinessUnitName"].ToString(),


                    });
                return CourierRequestModelList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.accessManager.SqlConnectionClose();
            }
        }

        public List<UserInformationModel> GetAllUsers()
        {
            List<UserInformationModel> UserList = new List<UserInformationModel>();
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            select UserId, UserName + ' (' + DesignationName + ')' UserName from UserInformation ui
                            left join DesignationTable dt on dt.DesignationId = ui.DesignationID
                            order by trim(UserName)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                UserList = connection.Query<UserInformationModel>(Query).ToList();
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

            return UserList;
        }
        
        public List<BusinessUnit> GetUserWiseBusinessUnits(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var businessUnits = new List<BusinessUnit>();

            var Query = @"
                            select cbp.UserBusinessUnit BusinessUnitId, BusinessUnitName from CourierUserWiseBusinessUnitPermission cbp
                            left join CourierBusinessUnit cb on cb.BusinessUnitId = cbp.BusinessUnitId
                            where UserId =  @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                businessUnits = connection.Query<BusinessUnit>(Query, new { UserId = id }).ToList();
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

            return businessUnits;
        }
        
        public List<BusinessUnit> GetCapexUserWiseBusinessUnits(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var businessUnits = new List<BusinessUnit>();

            var Query = @"
                            select uwb.UserBuId BusinessUnitId, BusinessUnitName from UserWiseBuTable uwb
                            left join BusinessUnit bu on bu.BusinessUnitId = uwb.BusinessUnitId
                            where UserId =  @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                businessUnits = connection.Query<BusinessUnit>(Query, new { UserId = id }).ToList();
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

            return businessUnits;
        }
        
        public List<LocationModel> GetCapexUserWiseLocation(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var locations = new List<LocationModel>();

            var Query = @"
                            select UserWiseLocationId LocationId, LocationName from UserWiseLocation uwl
                            left join LocationTable lt on lt.LocationId = uwl.LocationId
                            where UserId = @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                locations = connection.Query<LocationModel>(Query, new { UserId = id }).ToList();
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

            return locations;
        }
        
        public List<CapexCatagory> GetCapexUserWiseCategory(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var categories = new List<CapexCatagory>();

            var Query = @"
                            select UserCatId CapexCatagoryID, CapexCatagoryName from UserWiseCatagory uwc
                            left join CapexCatagory cc on cc.CapexCatagoryID = uwc.CatagoryId
                            where UserId = @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                categories = connection.Query<CapexCatagory>(Query, new { UserId = id }).ToList();
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

            return categories;
        }
        
        public List<AssetCategory> GetCategoryWiseAsset(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var assets = new List<AssetCategory>();

            var Query = @"
                            select CataWiseAssetId AssetCatagoryId, AssetCatagoryName from CatagoryWiseAsset cwa
                            left join AssetCatagoryName acn on acn.AssetCatagoryId = cwa.AssetCatagoryId
                            where CatagoryId = @CategoryId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                assets = connection.Query<AssetCategory>(Query, new { CategoryId = id }).ToList();
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

            return assets;
        }
        
        public List<ApproverTableList> GetCapexBusinessUnitCategoryWiseApprovers(int buId, int catId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var approvers = new List<ApproverTableList>();

            var Query = @"
                            select atl.ApprovalID, UserName, DesignationName, ApproverNo from ApproverTableList atl
                            left join UserInformation ui on ui.UserId = atl.UserId
                            left join DesignationTable dt on dt.DesignationId = ui.DesignationID
                            where CatagoryId = @CatId and atl.BusinessUnitID = @BuId
                            order by ApproverNo
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                approvers = connection.Query<ApproverTableList>(Query, new { BuId = buId, CatId = catId }).ToList();
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

            return approvers;
        }
        
        public List<BusinessUnit> GetCourierBusinessUnits()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var businessUnits = new List<BusinessUnit>();

            var Query = @"
                            select * from CourierBusinessUnit
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                businessUnits = connection.Query<BusinessUnit>(Query).ToList();
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

            return businessUnits;
        }

        public List<BusinessUnit> GetBusinessUnitsDD()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var businessUnits = new List<BusinessUnit>();

            var Query = @"
                            select * from BusinessUnit
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                businessUnits = connection.Query<BusinessUnit>(Query).ToList();
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

            return businessUnits;
        }
        
        public List<LocationModel> GetLocationsDD()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var locations = new List<LocationModel>();

            var Query = @"
                            select * from LocationTable
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                locations = connection.Query<LocationModel>(Query).ToList();
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

            return locations;
        }
        
        public List<CapexCatagory> GetCategoriesDD()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var catagories = new List<CapexCatagory>();

            var Query = @"
                            select * from CapexCatagory
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                catagories = connection.Query<CapexCatagory>(Query).ToList();
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

            return catagories;
        }
        
        public List<AssetCategory> GetAssetsDD()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var assets = new List<AssetCategory>();

            var Query = @"
                            select * from AssetCatagoryName
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                assets = connection.Query<AssetCategory>(Query).ToList();
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

            return assets;
        }

        public dynamic DeleteUserWiseBusienssUnit(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from CourierUserWiseBusinessUnitPermission
                            where UserBusinessUnit = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic DeleteCapexUserWiseBusienssUnit(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from UserWiseBuTable
                            where UserBuId = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic DeleteCapexUserWiseLocation(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from UserWiseLocation
                            where UserWiseLocationId = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic DeleteCapexUserWiseCategory(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from UserWiseCatagory
                            where UserCatId = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic DeleteCategoryWiseAsset(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from CatagoryWiseAsset
                            where CataWiseAssetId = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic DeleteCapexBusinessUnitCategoryWiseApprover(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from ApproverTableList
                            where ApprovalID = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddUserWiseBusienssUnit(int userId, int businessUnitId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into CourierUserWiseBusinessUnitPermission(UserId, BusinessUnitId, Active)
                            values(@UserId, @BusinessUnitId, 1)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId, BusinessUnitId = businessUnitId }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddCapexUserWiseBusienssUnit(int userId, int businessUnitId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into UserWiseBuTable(UserId, BusinessUnitId)
                            values(@UserId, @BusinessUnitId)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId, BusinessUnitId = businessUnitId }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddCapexUserWiseLocation(int userId, int locationId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into UserWiseLocation(UserId, LocationId, IsActive)
                            values(@UserId, @LocationId, 1)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId, LocationId = locationId }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddCapexUserWiseCategory(int userId, int categoryId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into UserWiseCatagory(UserId, CatagoryId, IsActive)
                            values(@UserId, @CatagoryId, 1)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId, CatagoryId = categoryId }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddCategoryWiseAsset(int catId, int assId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into CatagoryWiseAsset(CatagoryId, AssetCatagoryId)
                            values(@CatagoryId, @AssetCatagoryId)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { CatagoryId = catId, AssetCatagoryId = assId }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddCapexBusinessUnitCategoryWiseApprover(int buId, int catId, int userId, int appNo)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into ApproverTableList(UserId, CatagoryId, DesignationId, ApproverNo, IsActive, BusinessUnitID)
                            select UserId, @CatId, DesignationID, @AppNo, 1, @BuId from UserInformation
                            where UserId = @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { CatId = catId, AppNo = appNo, BuId = buId, UserId = userId }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public List<UserWiseApproverViewModel> GetUserWiseApprovers(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var approvers = new List<UserWiseApproverViewModel>();

            var Query = @"
                            select RequesterApproverId RequestorApproverId, UserName, Designation, ApproverSequence from RequesterApproverPermission rap
                            left join CourierRoleWiseApprover cra on cra.UserId = rap.UserId
                            where RequesterId = @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                approvers = connection.Query<UserWiseApproverViewModel>(Query, new { UserId = id }).ToList();
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

            return approvers;
        }
        
        public List<CourierApproverModel> GetCourierApproverList()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var approvers = new List<CourierApproverModel>();

            var Query = @"
                            select UserId UserID,
                            UserName + ' ' +
                            case
                            when ApproverSequence = 1 then '(1st Approver)'
                            when ApproverSequence = 2 then '(2nd Approver)'
                            end UserName
                            from CourierRoleWiseApprover
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                approvers = connection.Query<CourierApproverModel>(Query).ToList();
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

            return approvers;
        }
        
        public dynamic DeleteUserWiseApprover(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from RequesterApproverPermission
                            where RequesterApproverId = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddUserWiseApprover(int requestorId, int userId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into RequesterApproverPermission(RequesterId, UserId, Active)
                            values(@RequestorId, @UserId, 1)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { RequestorId = requestorId, UserId = userId }).ToList();
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

            return new {
                IsSuccess = true
            };
        }
        
        public List<BuyerListModel> GetUserWiseBuyers(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var buyers = new List<BuyerListModel>();

            var Query = @"
                            select UserCustomerId BuyerId, cc.BuyerName from CourierUserWiseCustomerPermission cuc
                            left join CourierCustomerTable cc on cc.BuyerId = cuc.BuyerId
                            where UserId = @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                buyers = connection.Query<BuyerListModel>(Query, new { UserId = id }).ToList();
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

            return buyers;
        }
        
        public List<BuyerListModel> GetCourierBuyerList()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var buyers = new List<BuyerListModel>();

            var Query = @"
                            select * from CourierCustomerTable
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                buyers = connection.Query<BuyerListModel>(Query).ToList();
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

            return buyers;
        }
        
        public dynamic DeleteUserWiseBuyer(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from CourierUserWiseCustomerPermission
                            where UserCustomerId = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id });
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddUserWiseBuyer(int userId, int buyerId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into CourierUserWiseCustomerPermission(UserId, BuyerId, Active)
                            values(@UserId, @BuyerId, 1)
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId, BuyerId = buyerId });
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddUserWiseAllBuyer(int userId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            insert into CourierUserWiseCustomerPermission(UserId, BuyerId, Active)
                            select @UserId UserId, min(BuyerId), 1 Active from CourierCustomerTable
                            group by BuyerName
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId });
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic RemoveUserWiseAllBuyer(int userId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from CourierUserWiseCustomerPermission
                            where UserId = @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId });
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

            return new {
                IsSuccess = true
            };
        }
        
        public dynamic AddCourierRateChart(List<CourierTypeVM> courierRates, string userId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"IF (ISJSON(@courierTypeJson) > 0)
	                        BEGIN
	                        insert into CourierType(WeightRange, Country, ServiceProvider, Currency, Rate, LeadTimeFrom, LeadTimeTo, [Type], CreateDate, CreateBy)
	                        SELECT WeightRange,Country, ServiceProvider, Currency, Rate, LeadTimeFrom, LeadTimeTo, [Type], GETDATE(), @CreateBy
	                         FROM OPENJSON(@courierTypeJson)
	                         WITH(
	                          WeightRange decimal(18,2) '$.WeightRange',
	                          Country nvarchar(MAX) '$.Country',
	                          ServiceProvider nvarchar(MAX) '$.ServiceProvider',
	                          Currency nvarchar(MAX) '$.Currency',
	                          Rate decimal(18,2) '$.Rate',
	                          LeadTimeFrom int '$.LeadTimeFrom',
	                          LeadTimeTo int '$.LeadTimeTo',
	                          [Type] nvarchar(MAX) '$.Type',
	                          CreateBy nvarchar(MAX) '$.CreateBy');
	                        END";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { courierTypeJson = new JavaScriptSerializer().Serialize(courierRates), CreateBy = userId });
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

            return new {
                IsSuccess = true
            };
        }
        
        public bool isVehicleRateExist(RateMatrix data)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            bool isExist = false;
            var Query = @"
                           select * from RateMatrix
                           where VendorId = @VendorId and VehicleTypeId = @VehicleTypeId and RouteId = @RouteId and TripTypeId = @TripTypeId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if(connection.QueryFirstOrDefault<RateMatrix>(Query, data) != null)
                {
                    isExist = true;
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

            return isExist;
        }
        
        public dynamic addVehicleVendor(string name)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            int status = 0;
            var Query = @"
                           DECLARE @stat int = 0;
                            IF EXISTS (SELECT * FROM VendorMaster WHERE VendorName = @Name)
                            BEGIN
                            SET @stat = 0
                            END
                            ELSE
                            BEGIN
                            INSERT INTO VendorMaster(VendorName)
                            VALUES(@Name)
                            SET @stat = 1
                            END
                            SELECT @stat
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                status = connection.QueryFirstOrDefault<int>(Query, new { Name = name });
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

            return new{
                status = status
            };
        }
        
        public dynamic addVehicleType(string name, int noOfSeats)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            int status = 0;
            var Query = @"
                            DECLARE @stat int = 0;
                            IF EXISTS (SELECT * FROM Vehicle WHERE VehicleName = @Name)
                            BEGIN
                            SET @stat = 0
                            END
                            ELSE
                            BEGIN
                            INSERT INTO Vehicle(VehicleName, NoOfSeats, CreateDate)
                            VALUES(@Name, @NoOfSeats, GETDATE())
                            SET @stat = 1
                            END
                            SELECT @stat
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                status = connection.QueryFirstOrDefault<int>(Query, new { Name = name, NoOfSeats = noOfSeats });
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

            return new{
                status = status
            };
        }
        
        public dynamic addVehicleRoute(string name)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            int status = 0;
            var Query = @"
                            DECLARE @stat int = 0;
                            IF EXISTS (SELECT * FROM RouteMaster WHERE RouteName = @Name)
                            BEGIN
                            SET @stat = 0
                            END
                            ELSE
                            BEGIN
                            INSERT INTO RouteMaster(RouteName)
                            VALUES(@Name)
                            SET @stat = 1
                            END
                            SELECT @stat
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                status = connection.QueryFirstOrDefault<int>(Query, new { Name = name });
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

            return new{
                status = status
            };
        }
        
        public dynamic getBusinessUnits()
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var businessUnits = new List<BusinessUnit>();
            var Query = @"
                            select * from BusinessUnit
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                businessUnits = connection.Query<BusinessUnit>(Query).ToList();
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

            return businessUnits;
        }
        
        public dynamic getBusiessUnitWiseApprover(int businessUnitId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var approvers = new List<VehicleApproverVM>();
            var Query = @"
                            select * from VehicleRoleWiseApprover
                            where UnitId = @UnitId
                            order by ApproverSequence
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                approvers = connection.Query<VehicleApproverVM>(Query, new { UnitId = businessUnitId }).ToList();
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

            return approvers;
        }

        public dynamic DeleteBusinessUnitWiseApprover(int id)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            var Query = @"
                            delete from VehicleRoleWiseApprover
                            where VehicleApproverid = @Id
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { Id = id });
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

            return new
            {
                IsSuccess = true
            };
        }

        public dynamic addVehicleApprover(int userId, string designation, string role, int approverNo, int businessUnitId)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());
            var Query = @"
                            insert into VehicleRoleWiseApprover(UserId, UserName, UserEmail, Designation, [Role], UnitId, ApproverSequence)
                            select top 1 UserId, UserName, UserEmail, @Designation, @Role, @UnitId, @ApproverNo from UserInformation
                            where UserId = @UserId
                        ";

            try
            {
                // var connection = new SqlConnection(DBConnection.GetConnectionString());
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                connection.Query(Query, new { UserId = userId, Designation = designation, Role = role, UnitId = businessUnitId, ApproverNo = approverNo });
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

            return new
            {
                isSuccess = true
            };
        }
    }
}