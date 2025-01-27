using Dapper;
using DocSoOperation.Models;
using Newtonsoft.Json;
using SQIndustryThree.DataManager;
using SQIndustryThree.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SQIndustryThree.DAL
{
    public class ExceptionRequestDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        private string connStr = ConfigurationManager.ConnectionStrings["SQQEYEDatabase"].ConnectionString;
        public List<BuyerListModel> LoadBuyerList(int userId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.DataEntryTracker);
                List<BuyerListModel> buyerListModels = new List<BuyerListModel>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@userId", userId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadBuyer", aList);
                while (dr.Read())
                {
                    BuyerListModel buyerList = new BuyerListModel();
                    buyerList.BuyerId = (int)dr["BuyerId"];
                    buyerList.BuyerName = dr["BuyerName"].ToString();
                    buyerListModels.Add(buyerList);
                }
                return buyerListModels;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<ExceptionRequestMaster> LoadExcpCategory(int userId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ExceptionRequestMaster> expresons = new List<ExceptionRequestMaster>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@userId", userId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadExpHRReasonCatagory", aList);
                while (dr.Read())
                {
                    ExceptionRequestMaster expcategory = new ExceptionRequestMaster();
                    expcategory.ExceptioReasonsId = (int)dr["ExceptioReasonsId"];
                    expcategory.ExceptionReasonName = dr["ExceptionReasonName"].ToString();
                    expresons.Add(expcategory);
                }
                return expresons;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<LocationModel> GetLocation(int userId)
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<LocationModel> location = new List<LocationModel>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@userId", userId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetHRLocation", aList);
                while (dr.Read())
                {
                    LocationModel lc = new LocationModel();
                    lc.LocationId = (int)dr["LocationId"];
                    lc.LocationName = dr["LocationName"].ToString();
                    location.Add(lc);
                }
                return location;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public ResultResponse SaveExceptionRequest(ExceptionRequestHRMaster exceptionMasterInfo, int UserId)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    string str1 = new JavaScriptSerializer().Serialize((object)exceptionMasterInfo.ExceptionDetailsExtendList);
                    string str2 = new JavaScriptSerializer().Serialize((object)exceptionMasterInfo.ExceptionDetailsList);
                    string str3 = new JavaScriptSerializer().Serialize((object)exceptionMasterInfo.ApproverList);
                    exceptionMasterInfo.ExceptionDetailsList = (List<ExceptionRequestHRMaster>)null;
                    exceptionMasterInfo.ExceptionDetailsExtendList = (List<ExceptionRequestHRDetailsExtend>)null;
                    int count = exceptionMasterInfo.ApproverList.Count;
                    exceptionMasterInfo.ApproverList = (List<CourierApproverModel>)null;
                    new JavaScriptSerializer().Serialize((object)exceptionMasterInfo);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@RequestorId", (object)UserId);
                    dynamicParameters.Add("@ExpTypeId", (object)exceptionMasterInfo.ExpTypeId);
                    dynamicParameters.Add("@ExpReasonId", (object)exceptionMasterInfo.ExpReasonId);
                    dynamicParameters.Add("@LocationId", (object)exceptionMasterInfo.LocationId);
                    dynamicParameters.Add("@BusinessUnitId", (object)exceptionMasterInfo.BusinessUnitId);
                    dynamicParameters.Add("@Month", (object)exceptionMasterInfo.Month);
                    dynamicParameters.Add("@Comment", (object)exceptionMasterInfo.Comment);
                    dynamicParameters.Add("@ApproverJson", (object)str3);
                    dynamicParameters.Add("@UserJosn", (object)str2);
                    dynamicParameters.Add("@DetailsJosn", (object)str1);
                    int num = cnn.Execute("SP_ExceptionRequestHRDataInsert", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
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
        //public ResultResponse SaveExceptionRequest(ExceptionRequestHRMaster exceptionMasterInfo,int userId)
        //{
        //    try
        //    {
        //        int masterId = 0;
        //        accessManager.SqlConnectionOpen(DataBase.SQQeye);
        //        List<SqlParameter> aParameters = new List<SqlParameter>(); 
        //        var json = new JavaScriptSerializer().Serialize(exceptionMasterInfo);
        //        var exceptionDetails = new JavaScriptSerializer().Serialize(exceptionMasterInfo.ExceptionDetailsList);
        //        var ExceptionDetailsExtendList = new JavaScriptSerializer().Serialize(exceptionMasterInfo.ExceptionDetailsExtendList);
        //      //  var exceptionFilelist = new JavaScriptSerializer().Serialize(exceptionMasterInfo.ExceptionFilesList);
        //        var approverList = new JavaScriptSerializer().Serialize(exceptionMasterInfo.ApproverList);
        //        exceptionMasterInfo.ExceptionDetailsList = null;
        //        exceptionMasterInfo.ExceptionDetailsExtendList = null;
        //       // exceptionMasterInfo.ExceptionFilesList = null;
        //        int noOfApprover = exceptionMasterInfo.ApproverList.Count();
        //        exceptionMasterInfo.ApproverList= null;
        //       exceptionMasterInfo.Comment = null;
        //        new JavaScriptSerializer().Serialize((object)exceptionMasterInfo);
        //        aParameters.Add(new SqlParameter("@RequestorId", userId));
        //        aParameters.Add(new SqlParameter("@ExpTypeId", exceptionMasterInfo.ExpTypeId));
        //        aParameters.Add(new SqlParameter("@ExpReasonId", exceptionMasterInfo.ExpReasonId));
        //        aParameters.Add(new SqlParameter("@LocationId", exceptionMasterInfo.LocationId));
        //        aParameters.Add(new SqlParameter("@BusinessUnitId", exceptionMasterInfo.BusinessUnitId));
        //        aParameters.Add(new SqlParameter("@Month", exceptionMasterInfo.Month));
        //        aParameters.Add(new SqlParameter("@Comment", (object)exceptionMasterInfo.Comment));
        //        aParameters.Add(new SqlParameter("@ApproverJson", approverList));
        //        aParameters.Add(new SqlParameter("@UserJosn", exceptionDetails));
        //        aParameters.Add(new SqlParameter("@DetailsJosn", ExceptionDetailsExtendList));


        //        masterId = accessManager.SaveDataReturnPrimaryKey("SP_ExceptionRequestHRDataInsert", aParameters);
        //        ResultResponse result = new ResultResponse();
        //        result.pk = masterId;
        //        result.isSuccess = true;
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        accessManager.SqlConnectionClose(true);
        //        throw e;
        //    }
        //    finally
        //    {
        //        accessManager.SqlConnectionClose();
        //    }
        //}
        public List<UserInformation> GetApproverList(int BusinessUnit)
        {
            List<UserInformation> users = new List<UserInformation>();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@UnitId", BusinessUnit));
                //aList.Add(new SqlParameter("@BuyerID", BuyerId));
                //aList.Add(new SqlParameter("@SupplyChain", SupplyChain));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ExpReqHRRoleWiseApproverList", aList);
                while (dr.Read())
                {
                    UserInformation user = new UserInformation();
                    user.UserInformationId = (int)dr["UserId"];
                    user.UserInformationName = dr["UserName"].ToString();
                    user.DesignationName = dr["Designation"].ToString();
                    user.ApproverNo = (int)dr["ApproverSequence"];
                    users.Add(user);
                }
                return users;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<ExceptionRequestHRMaster> GetAllexceptionRequest(int UserId, int Status, int Pgress)
        {
            List<ExceptionRequestHRMaster> users = new List<ExceptionRequestHRMaster>();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@UserId", UserId));
                aList.Add(new SqlParameter("@Status", Status));
                aList.Add(new SqlParameter("@Progress", Pgress));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_HRMasterExceptionRequestList", aList);
                while (dr.Read())
                {
                    ExceptionRequestHRMaster exceptionList = new ExceptionRequestHRMaster();
                    exceptionList.ExpReqMastertId = (int)dr["ExpReqMastertId"];
                    exceptionList.RequestorId = (int)dr["RequestorId"];
                    //exceptionList.UserName = dr["UserName"].ToString();
                    exceptionList.DateOfRequest = dr["DateOfRequest"].ToString();
                    exceptionList.ExpTypeId = (int)dr["ExpTypeId"];
                    exceptionList.ExceptionTypeName = dr["ExceptionTypeName"].ToString();
                    exceptionList.ExpReasonId = (int)dr["ExpReasonId"];
                    exceptionList.ExceptionReasonName = dr["ExceptionReasonName"].ToString();
                    exceptionList.LocationId = (int)dr["LocationId"];
                    exceptionList.LocationName = dr["LocationName"].ToString();
                    exceptionList.BusinessUnitId = (int)dr["BusinessUnitId"];
                    exceptionList.BusinessUnitName = dr["BusinessUnitName"].ToString();
                    exceptionList.Month = dr["Month"].ToString();
                    exceptionList.IsApproved = (int)dr["IsApproved"];
                    exceptionList.RequestBy = dr["UserName"].ToString();
                    exceptionList.CreateDate = dr["CreateDate"].ToString();

                    users.Add(exceptionList);
                }
                return users;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<ExceptionRequestMaster> AllExceprionReportList(int UserId, string formDate, string todate, int Bun, int byr, int extype, int resonTyp)
        {
            List<ExceptionRequestMaster> users = new List<ExceptionRequestMaster>();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@UserId", UserId));
                aList.Add(new SqlParameter("@FromDate", formDate));
                aList.Add(new SqlParameter("@Todate", todate));
                aList.Add(new SqlParameter("@BusinessUnitId", Bun));
                aList.Add(new SqlParameter("@BuyerId", byr));
                aList.Add(new SqlParameter("@ExceptionType", extype));
                aList.Add(new SqlParameter("@ReasonCatagory", resonTyp));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetExceptionReport", aList);
                while (dr.Read())
                {
                    ExceptionRequestMaster exceptionList = new ExceptionRequestMaster();
                    exceptionList.ExceptionMasterId = (int)dr["ExceptionMasterId"];
                    exceptionList.BuyerName = dr["BuyerName"].ToString();
                    exceptionList.BusinessUnitName = dr["BusinessUnitName"].ToString();
                    exceptionList.ExceptionTypeName = dr["ExceptionTypeName"].ToString();
                    exceptionList.IsApproved = (int)dr["IsApproved"];
                    exceptionList.ResponsiblePerson = dr["ResponsiblePerson"].ToString();
                    exceptionList.Reasons = dr["Reasons"].ToString();
                    exceptionList.IsHrInteraction = (int)dr["IsHrInteraction"];
                    exceptionList.ExceptionReasonName = dr["ExceptionReasonName"].ToString();
                    exceptionList.RequestBy = dr["UserName"].ToString();
                    exceptionList.CreateDate = dr["CreateDate"].ToString();

                    users.Add(exceptionList);
                }
                return users;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }

        public ExceptionRequestHRMaster IndividualRequestInfo(int masterId)
        {
            ExceptionRequestHRMaster exceptionRequest = new ExceptionRequestHRMaster();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@ExceptionMasterId", masterId));
                SqlDataReader dr = accessManager.GetSqlDataReader("Sp_HRMIndividualExceptionRequest", aList);
                while (dr.Read())
                {
                    exceptionRequest.ExpReqMastertId = (int)dr["ExpReqMastertId"];
                    exceptionRequest.ExpTypeId = (int)dr["ExpTypeId"];
                    exceptionRequest.ExceptionTypeName = dr["ExceptionTypeName"].ToString();
                    exceptionRequest.LocationId = (int)dr["LocationId"];
                    exceptionRequest.LocationName = dr["LocationName"].ToString();
                    exceptionRequest.BusinessUnitId = (int)dr["BusinessUnitId"];
                    exceptionRequest.BusinessUnitName = dr["BusinessUnitName"].ToString();
                    exceptionRequest.Month = dr["Month"].ToString();
                    exceptionRequest.IsApproved = (int)dr["IsApproved"];
                    exceptionRequest.Comment = dr["Comment"].ToString();
                    exceptionRequest.CreateDate = dr["CreateDate"].ToString();
                    //exceptionRequest.RequestBy = dr["UserName"].ToString();
                    //exceptionRequest.RequestorID =(int) dr["UserId"];
                    //exceptionRequest.IsHrInteraction =(int) dr["IsHrInteraction"];
                    //exceptionRequest.CreateDate = dr["CreateDate"].ToString();
                    //exceptionRequest.HrActionRemarks = dr["HrActionRemarks"].ToString();
                    //exceptionRequest.Odd = dr["Odd"].ToString();
                    //exceptionRequest.Rdd = dr["Rdd"].ToString();
                    //exceptionRequest.RivisionNo = (int)dr["RivisionNo"];
                    exceptionRequest.ExceptionReasonName = dr["ExceptionReasonName"].ToString();
                    // exceptionRequest.ExceptionDetailsList = dr["NecessaryAction"].ToString();
                    exceptionRequest.ExceptionDetailsList = JsonConvert.DeserializeObject<List<ExceptionRequestHRMaster>>(dr["ExceptionDetailsList"].ToString());
                    //exceptionRequest.ExceptionFilesList = JsonConvert.DeserializeObject<List<CapexFileUploadDetails>>(dr["ExceptionFilesList"].ToString());
                    exceptionRequest.ExceptionDetailsExtendList = JsonConvert.DeserializeObject<List<ExceptionRequestHRDetailsExtend>>(dr["ExceptionDetailsExtendList"].ToString());
                    exceptionRequest.ApproverList = JsonConvert.DeserializeObject<List<CourierApproverModel>>(dr["ApproverList"].ToString());
                    exceptionRequest.ExceptionLogSection = JsonConvert.DeserializeObject<List<LogSection>>(dr["ExceptionLogSection"].ToString());
                    exceptionRequest.ExceptionComments = JsonConvert.DeserializeObject<List<CommentsTable>>(dr["ExceptionRequestHRComments"].ToString());
                }
                return exceptionRequest;
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
        public bool ExpApproveOrReject(int Progress, string CommentText, int UserID, int ExpRequestId)
        {
            bool result = false;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@Progress", Progress));
                aParameters.Add(new SqlParameter("@CommentText", CommentText));
                aParameters.Add(new SqlParameter("@UserID", UserID));
                aParameters.Add(new SqlParameter("@ExpRequestId", ExpRequestId));
                result = accessManager.SaveData("sp_ExpHRMApproveOrreject", aParameters);
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
        public bool CommentSent(int MasterID, int ReviewTo, string ReviewMessage, int UserID)
        {
            bool result = false;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@MasterID", MasterID));
                aParameters.Add(new SqlParameter("@ReviewTo", ReviewTo));
                aParameters.Add(new SqlParameter("@ReviewMessage", ReviewMessage));
                aParameters.Add(new SqlParameter("@UserID", UserID));
                result = accessManager.SaveData("sp_SentExceptionComment", aParameters);
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
        public bool ApproveOrReject(int Progress, string CommentText, int UserID, int ExceptionMasterId)
        {
            bool result = false;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@Progress", Progress));
                aParameters.Add(new SqlParameter("@CommentText", CommentText));
                aParameters.Add(new SqlParameter("@UserID", UserID));
                aParameters.Add(new SqlParameter("@ExceptionMasterId", ExceptionMasterId));
                result = accessManager.SaveData("sp_ApproveOrRejectException", aParameters);
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

        public ResultResponse UpdateExceptionRequest(ExceptionRequestMaster exceptionMasterInfo, int userId)
        {
            try
            {
                foreach (ExceptionGenaralInformation exgen in exceptionMasterInfo.ExpgenaralInfoList)
                {
                    bool res = ExceptionGenaralInformation(exgen, exceptionMasterInfo.ExceptionMasterId);
                }
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                var json = new JavaScriptSerializer().Serialize(exceptionMasterInfo);
                var exceptionDetails = new JavaScriptSerializer().Serialize(exceptionMasterInfo.ExceptionDetails);
                var exceptionFilelist = new JavaScriptSerializer().Serialize(exceptionMasterInfo.ExceptionFilesList);
                exceptionMasterInfo.ExceptionDetails = null;
                exceptionMasterInfo.ExceptionFilesList = null;
                aParameters.Add(new SqlParameter("@ExceptionRequestMaster", json));
                aParameters.Add(new SqlParameter("@ExceptionDetails", exceptionDetails));
                aParameters.Add(new SqlParameter("@FileUploadJSon", exceptionFilelist));
                aParameters.Add(new SqlParameter("@UserID", userId));
                ResultResponse result = new ResultResponse();
                result.isSuccess = accessManager.UpdateData("sp_UpdateExceptionRequest", aParameters);
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
        public bool ExceptionGenaralInformation(ExceptionGenaralInformation exceptionGnInfo, int MasterId)
        {
            bool result = false;
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@ExceptionGnId", exceptionGnInfo.ExceptionGenralId));
                aParameters.Add(new SqlParameter("@PONumber", exceptionGnInfo.PO));
                aParameters.Add(new SqlParameter("@Color", exceptionGnInfo.Color));
                aParameters.Add(new SqlParameter("@StyleNumber", exceptionGnInfo.StyleNo));
                aParameters.Add(new SqlParameter("@quantity", exceptionGnInfo.Quantity));
                aParameters.Add(new SqlParameter("@fob", exceptionGnInfo.FOB));
                aParameters.Add(new SqlParameter("@expMasterId", MasterId));
                aParameters.Add(new SqlParameter("@odd", exceptionGnInfo.OriginalDD));
                aParameters.Add(new SqlParameter("@rdd", exceptionGnInfo.RevisedDD));
                aParameters.Add(new SqlParameter("@discount", exceptionGnInfo.Discount));
                aParameters.Add(new SqlParameter("@claim", exceptionGnInfo.Claim));
                aParameters.Add(new SqlParameter("@materialLi", exceptionGnInfo.MaterialLiability));
                aParameters.Add(new SqlParameter("@garmentsLi", exceptionGnInfo.GarmentsLiability));
                result = accessManager.SaveData("sp_ExceptionGenaralUpdate", aParameters);
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
        public List<PositionCodeDetails> GetshowExceptionRequestWisePositionCode(int business_unit, string month)
        {
            List<PositionCodeDetails> courierType = new List<PositionCodeDetails>();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                //aList.Add(new SqlParameter("@userId", UserId));
                aList.Add(new SqlParameter("@BusinessUnitId", business_unit));
                aList.Add(new SqlParameter("@month", month));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetALlPositionCodeWiseManpower", aList);
                while (dr.Read())
                {
                    PositionCodeDetails courierTypeInfromation = new PositionCodeDetails();
                    courierTypeInfromation.PWManpowerId = (int)dr["PWManpowerId"];
                    courierTypeInfromation.BusinessUnitId = (int)dr["BusinessUnitId"];
                    courierTypeInfromation.PositionName = dr["PositionName"].ToString();
                    courierTypeInfromation.DepartmentId = (int)dr["DepartmentId"];
                    courierTypeInfromation.StaffCategoryId = (int)dr["StaffCategoryId"];
                    courierTypeInfromation.DesignationId = (int)dr["DesignationId"];
                    courierTypeInfromation.Month = dr["Month"].ToString();
                    courierTypeInfromation.BudgetedHead = dr["BudgetedHead"].ToString();
                    courierTypeInfromation.StaffCategoryName = dr["StaffCategoryName"].ToString();
                    courierTypeInfromation.DesignationName = dr["DesignationName"].ToString();
                    courierTypeInfromation.DepartmentName = dr["DepartmentName"].ToString();
                    courierType.Add(courierTypeInfromation);
                }
                return courierType;
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
        public List<UserInformation> GetAllDesignation()
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<UserInformation> designation = new List<UserInformation>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetDesignationHR");
                while (dr.Read())
                {
                    UserInformation userDesignation = new UserInformation();
                    userDesignation.DesignationId = (int)dr["DesignationId"];
                    userDesignation.DesignationName = dr["DesignationName"].ToString();
                    designation.Add(userDesignation);
                }
                return designation;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<UserInformation> LoadSection()
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<UserInformation> designation = new List<UserInformation>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAllSectionHR");
                while (dr.Read())
                {
                    UserInformation userDesignation = new UserInformation();
                    userDesignation.SectionId = (int)dr["SectionId"];
                    userDesignation.SectionName = dr["SectionName"].ToString();
                    designation.Add(userDesignation);
                }
                return designation;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<UserInformation> LoadUnit()
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<UserInformation> designation = new List<UserInformation>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAllUnitHRHR");
                while (dr.Read())
                {
                    UserInformation userDesignation = new UserInformation();
                    userDesignation.UnitId = (int)dr["UnitId"];
                    userDesignation.UnitName = dr["UnitName"].ToString();
                    designation.Add(userDesignation);
                }
                return designation;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<UserInformation> LoadSubSection()
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<UserInformation> designation = new List<UserInformation>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAllSubSectionHR");
                while (dr.Read())
                {
                    UserInformation userDesignation = new UserInformation();
                    userDesignation.SubSectionId = (int)dr["SubSectionId"];
                    userDesignation.SubSectionName = dr["SubSectionName"].ToString();
                    designation.Add(userDesignation);
                }
                return designation;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public List<UserInformation> LoadCategory()
        {

            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<UserInformation> designation = new List<UserInformation>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_CategoryHR");
                while (dr.Read())
                {
                    UserInformation userDesignation = new UserInformation();
                    userDesignation.CategoryId = (int)dr["CategoryId"];
                    userDesignation.CategoryName = dr["CategoryName"].ToString();
                    designation.Add(userDesignation);
                }
                return designation;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
    }
}