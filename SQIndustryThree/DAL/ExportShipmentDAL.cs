using Dapper;
using DocSoOperation.Models;
using Newtonsoft.Json;
using SQIndustryThree.DataManager;
using SQIndustryThree.Models;
using SQIndustryThree.Models.ExportShipment;
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
    public class ExportShipmentDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        private string connStr = ConfigurationManager.ConnectionStrings["SQQEYEDatabase"].ConnectionString;

        public ResultResponse CreateNewExportShipment(int _userId, ExportShipmentMaster data)
        {
            ResultResponse result = new ResultResponse();
            int ExportShipmentMasterId = CreateExportShipmentMaster(_userId, data);
            foreach (var item in data.ExportShipmentDetails)
                result = CreateExportShipmentDetails(ExportShipmentMasterId, item);

            return result;
        }

        public int CreateExportShipmentMaster(int userId, ExportShipmentMaster data)
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
                return accessManager.SaveDataReturnPrimaryKey("sp_AddNewExportShipment", aParameters);
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

        public ResultResponse CreateExportShipmentDetails(int ExportShipmentMasterId, ExportShipmentDetails data)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    var ExportShipmentDetailsFileJson = new JavaScriptSerializer().Serialize(data.ExportShipmentFiles);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ExportShipmentMasterId", (object)ExportShipmentMasterId);
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
                    dynamicParameters.Add("@ExportShipmentDetailsFileJson", (object)ExportShipmentDetailsFileJson);

                    int num = cnn.Execute("sp_AddNewExportShipmentDetails", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
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

        public List<ExportShipmentMaster> GetAllExportShipmentList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ExportShipmentMaster> exportShipments = new List<ExportShipmentMaster>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ExportShipmentList", aList);
                while (dr.Read())
                {
                    ExportShipmentMaster exportShipment = new ExportShipmentMaster();
                    exportShipment.ExportShipmentMasterId = (int)dr["ExportShipmentMasterId"];
                    exportShipment.Date = dr["Date"].ToString();
                    exportShipment.BusinessUnitName = dr["BusinessUnitName"].ToString();
                    exportShipment.BuyerName = dr["BuyerName"].ToString();
                    exportShipment.ShipperName = dr["ShipperName"].ToString();
                    exportShipment.IsFinal = (bool)dr["IsFinal"];
                    exportShipments.Add(exportShipment);
                }

                return exportShipments;
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

        public List<ExportShipmentDetails> GetExportShipmentDetailsListForMasterId(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ExportShipmentDetails> exportShipments = new List<ExportShipmentDetails>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ExportShipmentDetailsListForMasterId", aList);
                while (dr.Read())
                {
                    ExportShipmentDetails exportShipment = new ExportShipmentDetails();
                    exportShipment.ExportShipmentDetailsId = (int)dr["ExportShipmentDetailsId"];
                    exportShipment.AccountLeadName = dr["AccountLeadName"].ToString();
                    exportShipment.PortOfLoading = dr["PortOfLoading"].ToString();
                    exportShipment.GoodsDescription = dr["GoodsDescription"].ToString();
                    exportShipment.ModeOfShipment = exportShipment.GetModeOfShipment((int)dr["ModeOfShipmentId"]);
                    exportShipment.ForwarderOrCarrierName = dr["Name"].ToString();
                    exportShipment.ContainerTypeName = dr["ContainerTypeName"].ToString();
                    exportShipment.ContainerSizeName = dr["ContainerSizeName"].ToString();
                    exportShipment.HBLorHAWBNo = dr["HBLorHAWBNo"].ToString();
                    exportShipment.BLorAWABDt = dr["BLorAWABDt"].ToString();
                    exportShipment.LCNo = dr["LCNo"].ToString();
                    exportShipment.InvoiceNo = dr["InvoiceNo"].ToString();
                    exportShipment.ValueInUSD = (decimal)dr["ValueInUSD"];
                    exportShipment.GrWeightInKg = (decimal)dr["GrWeightInKg"];
                    exportShipment.Quantity = (decimal)dr["Quantity"];
                    exportShipment.ICUnitName = dr["ICUnitName"].ToString();
                    exportShipment.ETD = dr["ETD"].ToString();
                    exportShipment.ETA = dr["ETA"].ToString();
                    exportShipment.BerthingDate = dr["BerthingDate"].ToString();
                    exportShipment.CBM = dr["CBM"].ToString();
                    exportShipment.AssesmentStatus = exportShipment.GetAssesmentStatusName((int)dr["AssesmentStatusId"]);
                    exportShipment.OTTDt = dr["OTTDt"].ToString();
                    exportShipment.PCD = dr["PCD"].ToString();
                    exportShipment.TentativeDeliveryDate = dr["TentativeDeliveryDate"].ToString();
                    exportShipment.Balance = (decimal)dr["Balance"];
                    exportShipment.Remarks = dr["Remarks"].ToString();
                    exportShipment.ExportShipmentFiles = GetAttachments((int)dr["ExportShipmentDetailsId"]);
                    exportShipments.Add(exportShipment);
                }
                return exportShipments;
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

        public List<ExportShipmentDetails> GetDetailsListForMod(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ExportShipmentDetails> exportShipments = new List<ExportShipmentDetails>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ExportShipmentDetailsListForMasterIdMOD", aList);
                while (dr.Read())
                {
                    ExportShipmentDetails exportShipment = new ExportShipmentDetails();
                    exportShipment.ExportShipmentDetailsId = (int)dr["ExportShipmentDetailsId"];
                    exportShipment.AccountLeadId = (int)dr["AccountLeadId"];
                    exportShipment.PortOfLoading = dr["PortOfLoading"].ToString();
                    exportShipment.GoodsDescription = dr["GoodsDescription"].ToString();
                    exportShipment.ModeOfShipmentId = (int)dr["ModeOfShipmentId"];
                    exportShipment.ForwarderOrCarrierId = (int)dr["ForwarderOrCarrierId"];
                    exportShipment.ContainerTypeId = (int)dr["ContainerTypeId"];
                    exportShipment.ContainerSizeId = (int)dr["ContainerSizeId"];
                    exportShipment.HBLorHAWBNo = dr["HBLorHAWBNo"].ToString();
                    exportShipment.BLorAWABDt = dr["BLorAWABDt"].ToString();
                    exportShipment.LCNo = dr["LCNo"].ToString();
                    exportShipment.InvoiceNo = dr["InvoiceNo"].ToString();
                    exportShipment.ValueInUSD = (decimal)dr["ValueInUSD"];
                    exportShipment.GrWeightInKg = (decimal)dr["GrWeightInKg"];
                    exportShipment.Quantity = (decimal)dr["Quantity"];
                    exportShipment.UnitId = (int)dr["UnitId"];
                    exportShipment.ETD = dr["ETD"].ToString();
                    exportShipment.ETA = dr["ETA"].ToString();
                    exportShipment.BerthingDate = dr["BerthingDate"].ToString();
                    exportShipment.CBM = dr["CBM"].ToString();
                    exportShipment.AssesmentStatusId = (int)dr["AssesmentStatusId"];
                    exportShipment.OTTDt = dr["OTTDt"].ToString();
                    exportShipment.PCD = dr["PCD"].ToString();
                    exportShipment.TentativeDeliveryDate = dr["TentativeDeliveryDate"].ToString();
                    exportShipment.Balance = (decimal)dr["Balance"];
                    exportShipment.Remarks = dr["Remarks"].ToString();
                    exportShipment.ExportShipmentFiles = GetAttachments((int)dr["ExportShipmentDetailsId"]);
                    exportShipments.Add(exportShipment);
                }
                return exportShipments;
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

        public List<ExportShipmentFile> GetAttachments(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ExportShipmentFile> exportShipmentFiles = new List<ExportShipmentFile>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ExportShipmentFileFromDId", aList);
                while (dr.Read())
                {
                    ExportShipmentFile exportShipmentFile = new ExportShipmentFile();
                    exportShipmentFile.ExportShipmentFileId = (int)dr["ExportShipmentFileId"];
                    exportShipmentFile.FileName = dr["FileName"].ToString();
                    exportShipmentFile.ServerFileName = dr["ServerFileName"].ToString();
                    exportShipmentFile.FilePath = dr["FilePath"].ToString();
                    exportShipmentFile.ShortPath = dr["ShortPath"].ToString();
                    exportShipmentFiles.Add(exportShipmentFile);
                }
                return exportShipmentFiles;
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

        public ExportShipmentMaster GetExportMasterById(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                var exportShipmentMaster = new ExportShipmentMaster();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetExportMasterDataById", aList);
                if (dr.Read())
                {
                    exportShipmentMaster.ExportShipmentMasterId = (int)dr["ExportShipmentMasterId"];
                    exportShipmentMaster.Date = dr["Date"].ToString();
                    exportShipmentMaster.BusinessUnitId = (int)dr["BusinessUnitId"];
                    exportShipmentMaster.BuyerId = (int)dr["BuyerId"];
                    exportShipmentMaster.ShipperId = (int)dr["ShipperId"];
                }
                return exportShipmentMaster;
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

        public ResultResponse DeleteExportShipmentFileDetails(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_DeleteExportShipmentFileDetails", aList);
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

        public ResultResponse SubmitDataForMod(int userId, ExportShipmentMaster data)
        {
            ResultResponse result = new ResultResponse();
            int temp = EditExportMaster(userId, data);
            foreach (var item in data.ExportShipmentDetails)
            {
                if (item.ExportShipmentDetailsId == 0)
                    result = CreateExportShipmentDetails(data.ExportShipmentMasterId, item);
                else
                    result = EditExportDetails(data.ExportShipmentMasterId, item);
            }

            return result;
        }

        public int EditExportMaster(int _userId, ExportShipmentMaster data)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@ExportShipmentMasterId", data.ExportShipmentMasterId));
                aParameters.Add(new SqlParameter("@BusinessUnitId", data.BusinessUnitId));
                aParameters.Add(new SqlParameter("@BuyerId", data.BuyerId));
                aParameters.Add(new SqlParameter("@ShipperId", data.ShipperId));
                aParameters.Add(new SqlParameter("@Date", data.Date));
                aParameters.Add(new SqlParameter("@IsFinal", data.IsFinal));
                aParameters.Add(new SqlParameter("@UserId", _userId));
                return accessManager.SaveDataReturnPrimaryKey("sp_EditExportShipmentMaster", aParameters);
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

        public ResultResponse EditExportDetails(int ExportShipmentMasterId, ExportShipmentDetails data)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    var ExportShipmentDetailsFileJson = new JavaScriptSerializer().Serialize(data.ExportShipmentFiles);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@ExportShipmentMasterId", (object)ExportShipmentMasterId);
                    dynamicParameters.Add("@ExportShipmentDetailsId", (object)data.ExportShipmentDetailsId);
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
                    dynamicParameters.Add("@ExportShipmentDetailsFileJson", (object)ExportShipmentDetailsFileJson);

                    int num = cnn.Execute("sp_EditExportShipmentDetails", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
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
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_DeleteExportDetails", aList);
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

        public dynamic GetExportShipmentDashboardData(string fromDate, string toDate, int businessUnitId, int buyerId, int shipperId)
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
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ExportShipmentDashboardData", aList);

                var dataList = new List<dynamic>();
                var exportShipmentDetails = new ExportShipmentDetails();

                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        TrackingId = (int)dr["ExportShipmentMasterId"],
                        Date = dr["_Date"].ToString(),
                        BusinessUnit = dr["CompanyName"].ToString(),
                        Buyer = dr["BuyerName"].ToString(),
                        Shipper = dr["Name"].ToString(),
                        AccountLeadName = dr["AccountLeadName"].ToString(),
                        PortOfLoading = dr["PortOfLoading"].ToString(),
                        GoodsDescription = dr["GoodsDescription"].ToString(),
                        ModeOfShipment = exportShipmentDetails.GetModeOfShipment((int)dr["ModeOfShipmentId"]),
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
                        AssesmentStatus = exportShipmentDetails.GetAssesmentStatusName((int)dr["AssesmentStatusId"]),
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