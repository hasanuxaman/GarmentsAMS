using Dapper;
using DocSoOperation.Models;
using Newtonsoft.Json;
using SQIndustryThree.DataManager;
using SQIndustryThree.Models;
using SQIndustryThree.Models.ImportConsignment;
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
    public class ImportConsignmentDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        private string connStr = ConfigurationManager.ConnectionStrings["SQQEYEDatabase"].ConnectionString;

        public ResultResponse CreateNewImportConsignment(int _userId, ImportConsignmentMaster data)
        {
            ResultResponse result = new ResultResponse();
            int ImportConsingmentMasterId = CreateImportConsignmentMaster(_userId, data);
            foreach (var item in data.ImportConsignmentDetails)
                result = CreateImportConsignmentDetails(ImportConsingmentMasterId, item);

            return result;
        }

        public int CreateImportConsignmentMaster(int userId, ImportConsignmentMaster data)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@BusinessUnitId", data.BusinessUnitId));
                aParameters.Add(new SqlParameter("@BuyerId", data.BuyerId));
                aParameters.Add(new SqlParameter("@ShipperId", data.ShipperId));
                aParameters.Add(new SqlParameter("@Date", data.Date));
                aParameters.Add(new SqlParameter("@IsFinal", data.IsFinal));
                aParameters.Add(new SqlParameter("@UserId", userId));
                return accessManager.SaveDataReturnPrimaryKey("sp_AddNewImportConsignment", aParameters);
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

        public ResultResponse CreateImportConsignmentDetails(int ImportConsignmentMasterId, ImportConsignmentDetails data)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    var ImportConsignmentDetailsFileJson = new JavaScriptSerializer().Serialize(data.ImportConsignmentFiles);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ImportConsignmentMasterId", (object)ImportConsignmentMasterId);
                    dynamicParameters.Add("@AccountLeadId", (object)data.AccountLeadId);
                    dynamicParameters.Add("@PortOfLoading", (object)data.PortOfLoading);
                    dynamicParameters.Add("@GoodsDescription", (object)data.GoodsDescription);
                    dynamicParameters.Add("@ModeOfShipmentId", (object)data.ModeOfShipmentId);
                    dynamicParameters.Add("@ForwarderOrCarrierId", (object)data.ForwarderOrCarrierId);
                    dynamicParameters.Add("@HBLorHAWBNo", (object)data.HBLorHAWBNo);
                    dynamicParameters.Add("@BLorAWABDt", (object)data.BLorAWABDt);
                    dynamicParameters.Add("@LCNo", (object)data.LCNo);
                    dynamicParameters.Add("@InvoiceNo", (object)data.InvoiceNo);
                    dynamicParameters.Add("@ValueInUSD", (object)data.ValueInUSD);
                    dynamicParameters.Add("@GrWeightInKg", (object)data.GrWeightInKg);
                    dynamicParameters.Add("@Quantity", (object)data.Quantity);
                    dynamicParameters.Add("@UnitId", (object)data.UnitId);
                    dynamicParameters.Add("@ETD", (object)data.ETD);
                    dynamicParameters.Add("@ETA", (object)data.ETA);
                    dynamicParameters.Add("@BerthingDate", (object)data.BerthingDate);
                    dynamicParameters.Add("@CBM", (object)data.CBM);
                    dynamicParameters.Add("@AssesmentStatusId", (object)data.AssesmentStatusId);
                    dynamicParameters.Add("@OTTDt", (object)data.OTTDt);
                    dynamicParameters.Add("@PCD", (object)data.PCD);
                    dynamicParameters.Add("@TentativeDeliveryDate", (object)data.TentativeDeliveryDate);
                    dynamicParameters.Add("@Balance", (object)data.Balance);
                    dynamicParameters.Add("@Remarks", (object)data.Remarks);
                    dynamicParameters.Add("@ContainerTypeId", (object)data.ContainerTypeId);
                    dynamicParameters.Add("@ContainerSizeId", (object)data.ContainerSizeId);
                    dynamicParameters.Add("@ImportConsignmentDetailsFileJson", (object)ImportConsignmentDetailsFileJson);

                    int num = cnn.Execute("sp_AddNewImportConsignmentDetails", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
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

        public dynamic GetAllShippers()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadShippers", aList);
                var dataList = new List<dynamic>();
                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        Value = (int)dr["Value"],
                        Text = dr["Text"].ToString()
                    });
                }
                return dataList;
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
        
        public dynamic GetAllCompanies()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadCompanies", aList);
                var dataList = new List<dynamic>();
                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        Value = (int)dr["Value"],
                        Text = dr["Text"].ToString()
                    });
                }
                return dataList;
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
        
        public dynamic GetAllContainerSize()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadContainerSize", aList);
                var dataList = new List<dynamic>();
                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        Value = (int)dr["Value"],
                        Text = dr["Text"].ToString()
                    });
                }
                return dataList;
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
        
        public dynamic GetAllContainerType()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadContainerType", aList);
                var dataList = new List<dynamic>();
                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        Value = (int)dr["Value"],
                        Text = dr["Text"].ToString()
                    });
                }
                return dataList;
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
        
        public dynamic GetAllUnits()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadICUnits", aList);
                var dataList = new List<dynamic>();
                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        Value = (int)dr["Value"],
                        Text = dr["Text"].ToString()
                    });
                }
                return dataList;
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
        
        public dynamic GetAllAccountLead()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadAccountLeads", aList);
                var dataList = new List<dynamic>();
                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        Value = (int)dr["Value"],
                        Text = dr["Text"].ToString()
                    });
                }
                return dataList;
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

        public List<ImportConsignmentMaster> GetAllImportConsignmentList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ImportConsignmentMaster> importConsignments = new List<ImportConsignmentMaster>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ImportConsignmentList", aList);
                while (dr.Read())
                {
                    ImportConsignmentMaster importConsignment = new ImportConsignmentMaster();
                    importConsignment.ImportConsignmentMasterId = (int)dr["ImportConsignmentMasterId"];
                    importConsignment.Date = dr["Date"].ToString();
                    importConsignment.BusinessUnitName = dr["BusinessUnitName"].ToString();
                    importConsignment.BuyerName = dr["BuyerName"].ToString();
                    importConsignment.ShipperName = dr["ShipperName"].ToString();
                    importConsignment.IsFinal = (bool)dr["IsFinal"];
                    importConsignments.Add(importConsignment);
                }

                return importConsignments;
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

        public List<ImportConsignmentDetails> GetImportConsignmentDetailsListForMasterId(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ImportConsignmentDetails> importConsignments = new List<ImportConsignmentDetails>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ImportConsignmentDetailsListForMasterId", aList);
                while (dr.Read())
                {
                    ImportConsignmentDetails importConsignment = new ImportConsignmentDetails();
                    importConsignment.ImportConsignmentDetailsId = (int)dr["ImportConsignmentDetailsId"];
                    importConsignment.AccountLeadName = dr["AccountLeadName"].ToString();
                    importConsignment.PortOfLoading = dr["PortOfLoading"].ToString();
                    importConsignment.GoodsDescription = dr["GoodsDescription"].ToString();
                    importConsignment.ModeOfShipment = importConsignment.GetModeOfShipment((int)dr["ModeOfShipmentId"]);
                    importConsignment.ForwarderOrCarrierName = dr["Name"].ToString();
                    importConsignment.ContainerTypeName = dr["ContainerTypeName"].ToString();
                    importConsignment.ContainerSizeName = dr["ContainerSizeName"].ToString();
                    importConsignment.HBLorHAWBNo = dr["HBLorHAWBNo"].ToString();
                    importConsignment.BLorAWABDt = dr["BLorAWABDt"].ToString();
                    importConsignment.LCNo = dr["LCNo"].ToString();
                    importConsignment.InvoiceNo = dr["InvoiceNo"].ToString();
                    importConsignment.ValueInUSD = (decimal)dr["ValueInUSD"];
                    importConsignment.GrWeightInKg = (decimal)dr["GrWeightInKg"];
                    importConsignment.Quantity = (decimal)dr["Quantity"];
                    importConsignment.ICUnitName = dr["ICUnitName"].ToString();
                    importConsignment.ETD = dr["ETD"].ToString();
                    importConsignment.ETA = dr["ETA"].ToString();
                    importConsignment.BerthingDate = dr["BerthingDate"].ToString();
                    importConsignment.CBM = dr["CBM"].ToString();
                    importConsignment.AssesmentStatus = importConsignment.GetAssesmentStatusName((int)dr["AssesmentStatusId"]);
                    importConsignment.OTTDt = dr["OTTDt"].ToString();
                    importConsignment.PCD = dr["PCD"].ToString();
                    importConsignment.TentativeDeliveryDate = dr["TentativeDeliveryDate"].ToString();
                    importConsignment.Balance = (decimal)dr["Balance"];
                    importConsignment.Remarks = dr["Remarks"].ToString();
                    importConsignment.ImportConsignmentFiles = GetAttachments((int)dr["ImportConsignmentDetailsId"]);
                    importConsignments.Add(importConsignment);
                }
                return importConsignments;
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

        public List<ImportConsignmentDetails> GetDetailsListForMod(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ImportConsignmentDetails> importConsignments = new List<ImportConsignmentDetails>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ImportConsignmentDetailsListForMasterIdMOD", aList);
                while (dr.Read())
                {
                    ImportConsignmentDetails importConsignment = new ImportConsignmentDetails();
                    importConsignment.ImportConsignmentDetailsId = (int)dr["ImportConsignmentDetailsId"];
                    importConsignment.AccountLeadId = (int)dr["AccountLeadId"];
                    importConsignment.PortOfLoading = dr["PortOfLoading"].ToString();
                    importConsignment.GoodsDescription = dr["GoodsDescription"].ToString();
                    importConsignment.ModeOfShipmentId = (int)dr["ModeOfShipmentId"];
                    importConsignment.ForwarderOrCarrierId = (int)dr["ForwarderOrCarrierId"];
                    importConsignment.ContainerTypeId = (int)dr["ContainerTypeId"];
                    importConsignment.ContainerSizeId = (int)dr["ContainerSizeId"];
                    importConsignment.HBLorHAWBNo = dr["HBLorHAWBNo"].ToString();
                    importConsignment.BLorAWABDt = dr["BLorAWABDt"].ToString();
                    importConsignment.LCNo = dr["LCNo"].ToString();
                    importConsignment.InvoiceNo = dr["InvoiceNo"].ToString();
                    importConsignment.ValueInUSD = (decimal)dr["ValueInUSD"];
                    importConsignment.GrWeightInKg = (decimal)dr["GrWeightInKg"];
                    importConsignment.Quantity = (decimal)dr["Quantity"];
                    importConsignment.UnitId = (int)dr["UnitId"];
                    importConsignment.ETD = dr["ETD"].ToString();
                    importConsignment.ETA = dr["ETA"].ToString();
                    importConsignment.BerthingDate = dr["BerthingDate"].ToString();
                    importConsignment.CBM = dr["CBM"].ToString();
                    importConsignment.AssesmentStatusId = (int)dr["AssesmentStatusId"];
                    importConsignment.OTTDt = dr["OTTDt"].ToString();
                    importConsignment.PCD = dr["PCD"].ToString();
                    importConsignment.TentativeDeliveryDate = dr["TentativeDeliveryDate"].ToString();
                    importConsignment.Balance = (decimal)dr["Balance"];
                    importConsignment.Remarks = dr["Remarks"].ToString();
                    importConsignment.ImportConsignmentFiles = GetAttachments((int)dr["ImportConsignmentDetailsId"]);
                    importConsignments.Add(importConsignment);
                }
                return importConsignments;
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

        public List<ImportConsignmentFile> GetAttachments(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ImportConsignmentFile> importConsignmentFiles = new List<ImportConsignmentFile>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ImportConsignmentFileFromDId", aList);
                while (dr.Read())
                {
                    ImportConsignmentFile importConsignmentFile = new ImportConsignmentFile();
                    importConsignmentFile.ImportConsignmentFileId = (int)dr["ImportConsignmentFileId"];
                    importConsignmentFile.FileName = dr["FileName"].ToString();
                    importConsignmentFile.ServerFileName = dr["ServerFileName"].ToString();
                    importConsignmentFile.FilePath = dr["FilePath"].ToString();
                    importConsignmentFile.ShortPath = dr["ShortPath"].ToString();
                    importConsignmentFiles.Add(importConsignmentFile);
                }
                return importConsignmentFiles;
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

        public ImportConsignmentMaster GetImportMasterById(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                var importConsignmentMaster = new ImportConsignmentMaster();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetImportMasterDataById", aList);
                if (dr.Read())
                {
                    importConsignmentMaster.ImportConsignmentMasterId = (int)dr["ImportConsignmentMasterId"];
                    importConsignmentMaster.Date = dr["Date"].ToString();
                    importConsignmentMaster.BusinessUnitId = (int)dr["BusinessUnitId"];
                    importConsignmentMaster.BuyerId = (int)dr["BuyerId"];
                    importConsignmentMaster.ShipperId = (int)dr["ShipperId"];
                }
                return importConsignmentMaster;
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

        public ResultResponse DeleteImportConsignmentFileDetails(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_DeleteImportConsignmentFileDetails", aList);
                var result = new ResultResponse();
                if (dr.Read())
                {
                    result.isSuccess = true;
                }

                return result;
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

        public ResultResponse SubmitDataForMod(int userId, ImportConsignmentMaster data)
        {
            ResultResponse result = new ResultResponse();
            int temp = EditImportMaster(userId, data);
            foreach (var item in data.ImportConsignmentDetails)
            {
                if (item.ImportConsignmentDetailsId == 0)
                    result = CreateImportConsignmentDetails(data.ImportConsignmentMasterId, item);
                else
                    result = EditImportDetails(data.ImportConsignmentMasterId, item);
            }

            return result;
        }

        public int EditImportMaster(int _userId, ImportConsignmentMaster data)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@ImportConsignmentMasterId", data.ImportConsignmentMasterId));
                aParameters.Add(new SqlParameter("@BusinessUnitId", data.BusinessUnitId));
                aParameters.Add(new SqlParameter("@BuyerId", data.BuyerId));
                aParameters.Add(new SqlParameter("@ShipperId", data.ShipperId));
                aParameters.Add(new SqlParameter("@Date", data.Date));
                aParameters.Add(new SqlParameter("@IsFinal", data.IsFinal));
                aParameters.Add(new SqlParameter("@UserId", _userId));
                return accessManager.SaveDataReturnPrimaryKey("sp_EditImportConsignmentMaster", aParameters);
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

        public ResultResponse EditImportDetails(int ImportConsignmentMasterId, ImportConsignmentDetails data)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    var ImportConsignmentDetailsFileJson = new JavaScriptSerializer().Serialize(data.ImportConsignmentFiles);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ImportConsignmentMasterId", (object)ImportConsignmentMasterId);
                    dynamicParameters.Add("@ImportConsignmentDetailsId", (object)data.ImportConsignmentDetailsId);
                    dynamicParameters.Add("@AccountLeadId", (object)data.AccountLeadId);
                    dynamicParameters.Add("@PortOfLoading", (object)data.PortOfLoading);
                    dynamicParameters.Add("@GoodsDescription", (object)data.GoodsDescription);
                    dynamicParameters.Add("@ModeOfShipmentId", (object)data.ModeOfShipmentId);
                    dynamicParameters.Add("@ForwarderOrCarrierId", (object)data.ForwarderOrCarrierId);
                    dynamicParameters.Add("@HBLorHAWBNo", (object)data.HBLorHAWBNo);
                    dynamicParameters.Add("@BLorAWABDt", (object)data.BLorAWABDt);
                    dynamicParameters.Add("@LCNo", (object)data.LCNo);
                    dynamicParameters.Add("@InvoiceNo", (object)data.InvoiceNo);
                    dynamicParameters.Add("@ValueInUSD", (object)data.ValueInUSD);
                    dynamicParameters.Add("@GrWeightInKg", (object)data.GrWeightInKg);
                    dynamicParameters.Add("@Quantity", (object)data.Quantity);
                    dynamicParameters.Add("@UnitId", (object)data.UnitId);
                    dynamicParameters.Add("@ETD", (object)data.ETD);
                    dynamicParameters.Add("@ETA", (object)data.ETA);
                    dynamicParameters.Add("@BerthingDate", (object)data.BerthingDate);
                    dynamicParameters.Add("@CBM", (object)data.CBM);
                    dynamicParameters.Add("@AssesmentStatusId", (object)data.AssesmentStatusId);
                    dynamicParameters.Add("@OTTDt", (object)data.OTTDt);
                    dynamicParameters.Add("@PCD", (object)data.PCD);
                    dynamicParameters.Add("@TentativeDeliveryDate", (object)data.TentativeDeliveryDate);
                    dynamicParameters.Add("@Balance", (object)data.Balance);
                    dynamicParameters.Add("@Remarks", (object)data.Remarks);
                    dynamicParameters.Add("@ContainerTypeId", (object)data.ContainerTypeId);
                    dynamicParameters.Add("@ContainerSizeId", (object)data.ContainerSizeId);
                    dynamicParameters.Add("@ImportConsignmentDetailsFileJson", (object)ImportConsignmentDetailsFileJson);

                    int num = cnn.Execute("sp_EditImportConsignmentDetails", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
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

        public ResultResponse DeleteICTDetails(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_DeleteImportDetails", aList);
                var result = new ResultResponse();
                if (dr.Read())
                {
                    result.isSuccess = true;
                }

                return result;
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

        public dynamic GetImportConsignmentDashboardData(string fromDate, string toDate, int businessUnitId, int buyerId, int shipperId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@fromDate", fromDate));
                aList.Add(new SqlParameter("@toDate", toDate));
                aList.Add(new SqlParameter("@businessUnitId", businessUnitId));
                aList.Add(new SqlParameter("@buyerId", buyerId));
                aList.Add(new SqlParameter("@shipperId", shipperId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ImportConsignmentDashboardData", aList);

                var dataList = new List<dynamic>();
                var importConsignmentDetails = new ImportConsignmentDetails();

                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        TrackingId = (int)dr["ImportConsignmentMasterId"],
                        Date = dr["_Date"].ToString(),
                        BusinessUnit = dr["CompanyName"].ToString(),
                        Buyer = dr["BuyerName"].ToString(),
                        Shipper = dr["Name"].ToString(),
                        AccountLeadName = dr["AccountLeadName"].ToString(),
                        PortOfLoading = dr["PortOfLoading"].ToString(),
                        GoodsDescription = dr["GoodsDescription"].ToString(),
                        ModeOfShipment = importConsignmentDetails.GetModeOfShipment((int)dr["ModeOfShipmentId"]),
                        ForwarderOrCarrierName = dr["Name"].ToString(),
                        ContainerTypeName = dr["ContainerTypeName"].ToString(),
                        ContainerSizeName = dr["ContainerSizeName"].ToString(),
                        HBLorHAWBNo = dr["HBLorHAWBNo"].ToString(),
                        BLorAWABDt = dr["_BLorAWABDt"].ToString(),
                        LCNo = dr["LCNo"].ToString(),
                        InvoiceNo = dr["InvoiceNo"].ToString(),
                        ValueInUSD = (decimal)dr["ValueInUSD"],
                        GrWeightInKg = (decimal)dr["GrWeightInKg"],
                        Quantity = (decimal)dr["Quantity"],
                        ICUnitName = dr["ICUnitName"].ToString(),
                        ETD = dr["_ETD"].ToString(),
                        ETA = dr["_ETA"].ToString(),
                        BerthingDate = dr["_BerthingDate"].ToString(),
                        CBM = dr["_CBM"].ToString(),
                        AssesmentStatus = importConsignmentDetails.GetAssesmentStatusName((int)dr["AssesmentStatusId"]),
                        OTTDt = dr["_OTTDt"].ToString(),
                        PCD = dr["_PCD"].ToString(),
                        TentativeDeliveryDate = dr["_TentativeDeliveryDate"].ToString(),
                        Balance = (decimal)dr["Balance"],
                        Remarks = dr["Remarks"].ToString(),
                    });
                }

                return dataList;
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