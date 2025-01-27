using Dapper;
using DocSoOperation.Models;
using Newtonsoft.Json;
using SQIndustryThree.DataManager;
using SQIndustryThree.Models;
using SQIndustryThree.Models.AirFreightTracker;
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
    public class AirFreightDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        private string connStr = ConfigurationManager.ConnectionStrings["SQQEYEDatabase"].ConnectionString;

        public List<BuyerListModel> LoadBuyerList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<BuyerListModel> buyerListModels = new List<BuyerListModel>();
                List<SqlParameter> aaList = new List<SqlParameter>();
                //aList.Add(new SqlParameter("@userId", userId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_getAllBuyerList", aaList);
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

        public List<ExceptionRequestMaster> LoadERList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ExceptionRequestMaster> ERmasters = new List<ExceptionRequestMaster>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadERList", aList);
                while (dr.Read())
                {
                    ExceptionRequestMaster erMaster = new ExceptionRequestMaster();
                    erMaster.ExceptionMasterId = (int)dr["ExceptionMasterId"];
                    ERmasters.Add(erMaster);
                }
                return ERmasters;
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

        public List<Forwarder> LoadForwardersList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<Forwarder> forwarders = new List<Forwarder>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_ForwarderList", aList);
                while (dr.Read())
                {
                    Forwarder forwarder = new Forwarder();
                    forwarder.ForwarderId = (int)dr["ForwarderId"];
                    forwarder.Name = dr["Name"].ToString();
                    forwarders.Add(forwarder);
                }
                return forwarders;
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

        public ExceptionRequestMaster LoadDataAgainstERId(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                ExceptionRequestMaster ERData = new ExceptionRequestMaster();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadDataForER", aList);
                if (dr.Read())
                {
                    ERData.ExceptionMasterId = (int)dr["ExceptionMasterId"];
                    ERData.UpdateDate = dr["UpdateDate"].ToString();
                    ERData.BuyerId = (int)dr["BuyerId"];
                    ERData.BusinessUnitId = (int)dr["BusinessUnitId"];
                }
                return ERData;
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

        public List<ExceptionGenaralInformation> LoadPOAgainstERId(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<ExceptionGenaralInformation> POList = new List<ExceptionGenaralInformation>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_LoadPOForERId", aList);
                while (dr.Read())
                {
                    POList.Add(new ExceptionGenaralInformation
                    {
                        ExceptionGenralId = (int)dr["ExceptionGenralId"],
                        PO = dr["PO"].ToString(),
                        //Quantity = (int)dr["Quantity"]
                    });
                }
                return POList;
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

        public ResultResponse SubmitDataForSQ(int _userId, AirFreightMaster data)
        {
            ResultResponse result = new ResultResponse();
            int AirFreightMasterId = CreateAirFreightMaster(_userId, data);
            foreach (var item in data.AirFreightDetails)
                result = CreateAirFreightDetails(AirFreightMasterId, item);

            return result;
        }

        public ResultResponse SubmitDataForMod(int userId, AirFreightMaster data)
        {
            ResultResponse result = new ResultResponse();
            int temp = EditAirFreightMaster(userId, data);
            foreach (var item in data.AirFreightDetails)
            {
                if (item.AirFreightDetailsId == 0)
                    result = CreateAirFreightDetails(data.AirFreightMasterId, item);
                else
                    result = EditAirFreightDetails(data.AirFreightMasterId, item);
            }

            return result;
        }

        public int CreateAirFreightMaster(int userId, AirFreightMaster data)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                var aiFreightDetailsJson = new JavaScriptSerializer().Serialize(data.AirFreightDetails);
                aParameters.Add(new SqlParameter("@ExceptionMasterId", data.ExceptionMasterId));
                aParameters.Add(new SqlParameter("@BusinessUnitId", data.BusinessUnitId));
                aParameters.Add(new SqlParameter("@BuyersNameId", data.BuyersNameId));
                aParameters.Add(new SqlParameter("@ForwarderId", data.ForwarderId));
                aParameters.Add(new SqlParameter("@FrieghtCostOnACOf", data.FrieghtCostOnACOf));
                aParameters.Add(new SqlParameter("@IsFinal", data.IsFinal));
                aParameters.Add(new SqlParameter("@USDToBDTRate", data.USDToBDTRate));
                aParameters.Add(new SqlParameter("@UserId", userId));
                return accessManager.SaveDataReturnPrimaryKey("sp_AddNewAirFreightMaster", aParameters);
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

        public int EditAirFreightMaster(int _userId, AirFreightMaster data)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@AirFreightMasterId", data.AirFreightMasterId));
                aParameters.Add(new SqlParameter("@ExceptionMasterId", data.ExceptionMasterId));
                aParameters.Add(new SqlParameter("@BusinessUnitId", data.BusinessUnitId));
                aParameters.Add(new SqlParameter("@BuyersNameId", data.BuyersNameId));
                aParameters.Add(new SqlParameter("@ForwarderId", data.ForwarderId));
                aParameters.Add(new SqlParameter("@FrieghtCostOnACOf", data.FrieghtCostOnACOf));
                aParameters.Add(new SqlParameter("@IsFinal", data.IsFinal));
                aParameters.Add(new SqlParameter("@USDToBDTRate", data.USDToBDTRate));
                aParameters.Add(new SqlParameter("@UserId", _userId));
                return accessManager.SaveDataReturnPrimaryKey("sp_EditAirFreightMaster", aParameters);
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

        public ResultResponse CreateAirFreightDetails(int AirFreightMasterId, AirFreightDetails data)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    var aiFreightDetailsFileJson = new JavaScriptSerializer().Serialize(data.AirFreightFiles);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@AirFreightMasterId", (object)AirFreightMasterId);
                    dynamicParameters.Add("@ExceptionGenralId", (object)data.ExceptionGenralId);
                    dynamicParameters.Add("@PO", (object)data.PO);
                    dynamicParameters.Add("@ParentPO", (object)data.ParentPO);
                    dynamicParameters.Add("@ModeOfShipmentId", (object)data.ModeOfShipmentId);
                    dynamicParameters.Add("@PortOfDestination", (object)data.PortOfDestination);
                    dynamicParameters.Add("@CountryOfDestinationId", (object)data.CountryOfDestinationId);
                    dynamicParameters.Add("@IncotermId", (object)data.IncotermId);
                    dynamicParameters.Add("@InvoiceNo", (object)data.InvoiceNo);
                    dynamicParameters.Add("@InvoiceValueInUSD", (object)data.InvoiceValueInUSD);
                    dynamicParameters.Add("@QTYInPack", (object)data.QTYInPack);
                    dynamicParameters.Add("@QTYInPcERApproved", (object)data.QTYInPcERApproved);
                    dynamicParameters.Add("@QtyInPc", (object)data.QtyInPc);
                    dynamicParameters.Add("@QtyInCtn", (object)data.QtyInCtn);
                    dynamicParameters.Add("@GrossWeightInKg", (object)data.GrossWeightInKg);
                    dynamicParameters.Add("@HAWBLNo", (object)data.HAWBLNo);
                    dynamicParameters.Add("@HAWBLDate", (object)data.HAWBLDate);
                    dynamicParameters.Add("@ChargeableWeightInKgERApproved", (object)data.ChargeableWeightInKgERApproved);
                    dynamicParameters.Add("@FreightAmountInUSDErApproved", (object)data.FreightAmountInUSDErApproved);
                    dynamicParameters.Add("@ChargeableWeightInKg", (object)data.ChargeableWeightInKg);
                    dynamicParameters.Add("@FreightAmountInUSD", (object)data.FreightAmountInUSD);
                    dynamicParameters.Add("@FrieghtRatePerKgERApproved", (object)data.FrieghtRatePerKgERApproved);
                    dynamicParameters.Add("@FreightRatePerKg", (object)data.FreightRatePerKg);
                    dynamicParameters.Add("@FreightAmountInBDT", (object)data.FreightAmountInBDT);
                    dynamicParameters.Add("@FreightInvoiceNo", (object)data.FreightInvoiceNo);
                    dynamicParameters.Add("@FreightInvoiceReceivedDate", (object)data.FreightInvoiceReceivedDate);
                    dynamicParameters.Add("@ExFactoryDate", (object)data.ExFactoryDate);
                    dynamicParameters.Add("@BillSubDateForPayment", (object)data.BillSubDateForPayment);
                    dynamicParameters.Add("@PaymentDate", (object)data.PaymentDate);
                    dynamicParameters.Add("@CHQPOSubmitDateToForwarder", (object)data.CHQPOSubmitDateToForwarder);
                    dynamicParameters.Add("@AWABReleaseDate", (object)data.AWABReleaseDate);
                    dynamicParameters.Add("@Remarks", (object)data.Remarks);
                    dynamicParameters.Add("@AiFreightDetailsFileJson", (object)aiFreightDetailsFileJson);

                    int num = cnn.Execute("sp_AddNewAirFreightDetails", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
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

        public ResultResponse EditAirFreightDetails(int AirFreightMasterId, AirFreightDetails data)
        {
            try
            {
                using (IDbConnection cnn = (IDbConnection)new SqlConnection(this.connStr))
                {
                    if (cnn.State == ConnectionState.Closed)
                        cnn.Open();
                    var aiFreightDetailsFileJson = new JavaScriptSerializer().Serialize(data.AirFreightFiles);
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@AirFreightMasterId", (object)AirFreightMasterId);
                    dynamicParameters.Add("@AirFreightDetailsId", (object)data.AirFreightDetailsId);
                    dynamicParameters.Add("@ExceptionGenralId", (object)data.ExceptionGenralId);
                    dynamicParameters.Add("@PO", (object)data.PO);
                    dynamicParameters.Add("@ParentPO", (object)data.ParentPO);
                    dynamicParameters.Add("@ModeOfShipmentId", (object)data.ModeOfShipmentId);
                    dynamicParameters.Add("@PortOfDestination", (object)data.PortOfDestination);
                    dynamicParameters.Add("@CountryOfDestinationId", (object)data.CountryOfDestinationId);
                    dynamicParameters.Add("@IncotermId", (object)data.IncotermId);
                    dynamicParameters.Add("@InvoiceNo", (object)data.InvoiceNo);
                    dynamicParameters.Add("@InvoiceValueInUSD", (object)data.InvoiceValueInUSD);
                    dynamicParameters.Add("@QTYInPack", (object)data.QTYInPack);
                    dynamicParameters.Add("@QTYInPcERApproved", (object)data.QTYInPcERApproved);
                    dynamicParameters.Add("@QtyInPc", (object)data.QtyInPc);
                    dynamicParameters.Add("@QtyInCtn", (object)data.QtyInCtn);
                    dynamicParameters.Add("@GrossWeightInKg", (object)data.GrossWeightInKg);
                    dynamicParameters.Add("@HAWBLNo", (object)data.HAWBLNo);
                    dynamicParameters.Add("@HAWBLDate", (object)data.HAWBLDate);
                    dynamicParameters.Add("@ChargeableWeightInKgERApproved", (object)data.ChargeableWeightInKgERApproved);
                    dynamicParameters.Add("@FreightAmountInUSDErApproved", (object)data.FreightAmountInUSDErApproved);
                    dynamicParameters.Add("@ChargeableWeightInKg", (object)data.ChargeableWeightInKg);
                    dynamicParameters.Add("@FreightAmountInUSD", (object)data.FreightAmountInUSD);
                    dynamicParameters.Add("@FrieghtRatePerKgERApproved", (object)data.FrieghtRatePerKgERApproved);
                    dynamicParameters.Add("@FreightRatePerKg", (object)data.FreightRatePerKg);
                    dynamicParameters.Add("@FreightAmountInBDT", (object)data.FreightAmountInBDT);
                    dynamicParameters.Add("@FreightInvoiceNo", (object)data.FreightInvoiceNo);
                    dynamicParameters.Add("@ExFactoryDate", (object)data.ExFactoryDate);
                    dynamicParameters.Add("@FreightInvoiceReceivedDate", (object)data.FreightInvoiceReceivedDate);
                    dynamicParameters.Add("@BillSubDateForPayment", (object)data.BillSubDateForPayment);
                    dynamicParameters.Add("@PaymentDate", (object)data.PaymentDate);
                    dynamicParameters.Add("@CHQPOSubmitDateToForwarder", (object)data.CHQPOSubmitDateToForwarder);
                    dynamicParameters.Add("@AWABReleaseDate", (object)data.AWABReleaseDate);
                    dynamicParameters.Add("@Remarks", (object)data.Remarks);
                    dynamicParameters.Add("@AiFreightDetailsFileJson", (object)aiFreightDetailsFileJson);

                    int num = cnn.Execute("sp_EditAirFreightDetails", (object)dynamicParameters, commandType: new CommandType?(CommandType.StoredProcedure));
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

        public List<AirFreightMaster> GetAllAirFreightList()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<AirFreightMaster> airFreights = new List<AirFreightMaster>();
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_AirFreightList", aList);
                while (dr.Read())
                {
                    AirFreightMaster airFreight = new AirFreightMaster();
                    airFreight.AirFreightMasterId = (int)dr["AirFreightMasterId"];
                    airFreight.ExceptionMasterId = (int)dr["ExceptionMasterId"];
                    airFreight.ERDate = airFreight.ExceptionMasterId == 0 ? "---" : LoadDataAgainstERId((int)dr["ExceptionMasterId"]).UpdateDate;
                    airFreight.BusinessUnit = dr["BusinessUnitName"].ToString();
                    airFreight.BuyersName = dr["BuyerName"].ToString();
                    airFreight.Forwarder = dr["Name"].ToString();
                    airFreight.FrieghtCostOnACOf = (int)dr["FrieghtCostOnACOf"];
                    airFreight.IsFinal = (bool)dr["IsFinal"];
                    airFreights.Add(airFreight);
                }

                return airFreights;
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

        public List<AirFreightDetails> GetPoListForAirFreightMaster(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<AirFreightDetails> airFreights = new List<AirFreightDetails>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_AirFreightPOListForMaster", aList);
                while (dr.Read())
                {
                    AirFreightDetails airFreight = new AirFreightDetails();
                    airFreight.AirFreightDetailsId = (int)dr["AirFreightDetailsId"];
                    airFreight.PO = dr["PO"].ToString();
                    airFreight.ParentPO = dr["ParentPO"].ToString();
                    airFreight.ModeOfShipment = (int)dr["ModeOfShipmentId"] == 0 ? "---" : (int)dr["ModeOfShipmentId"] == 1 ? "Air" : "Sea & Air";
                    airFreight.ModeOfShipmentId = (int)dr["ModeOfShipmentId"];
                    airFreight.PortOfDestination = dr["PortOfDestination"].ToString();
                    airFreight.CountryOfDestinationId = (int)dr["CountryOfDestinationId"];
                    airFreight.CountryOfDestination = dr["CountryName"].ToString();
                    airFreight.Incoterm = GetIncoterm(dr["IncotermId"].ToString() == "" ? 0 : ((int)dr["IncotermId"]));
                    airFreight.IncotermId = dr["IncotermId"].ToString() == "" ? 0 : (int)dr["IncotermId"];
                    airFreight.InvoiceNo = dr["InvoiceNo"].ToString();
                    airFreight.InvoiceValueInUSD = (decimal)dr["InvoiceValueInUSD"];
                    airFreight.QTYInPack = (int)dr["QTYInPack"];
                    airFreight.QTYInPcERApproved = (int)dr["QTYInPcERApproved"];
                    airFreight.QtyInPc = (int)dr["QtyInPc"];
                    airFreight.QtyInCtn = (int)dr["QtyInCtn"];
                    airFreight.GrossWeightInKg = (decimal)dr["GrossWeightInKg"];
                    airFreight.HAWBLNo = dr["HAWBLNo"].ToString();
                    airFreight.HAWBLDate = dr["HAWBLDate"].ToString();
                    //airFreight.HAWBLDate = dr["HAWBLDate"].ToString() != null? (DateTime)dr["HAWBLDate"] : null;
                    airFreight.ChargeableWeightInKgERApproved = (decimal)dr["ChargeableWeightInKgERApproved"];
                    airFreight.FreightAmountInUSDErApproved = (decimal)dr["FreightAmountInUSDErApproved"];
                    airFreight.ChargeableWeightInKg = (decimal)dr["ChargeableWeightInKg"];
                    airFreight.FreightAmountInUSD = (decimal)dr["FreightAmountInUSD"];
                    airFreight.FrieghtRatePerKgERApproved = (decimal)dr["FrieghtRatePerKgERApproved"];
                    airFreight.FreightRatePerKg = (decimal)dr["FreightRatePerKg"];
                    airFreight.FreightAmountInBDT = (decimal)dr["FreightAmountInBDT"];
                    airFreight.FreightInvoiceNo = dr["FreightInvoiceNo"].ToString();
                    airFreight.ExFactoryDate = dr["ExFactoryDate"].ToString();
                    airFreight.FreightInvoiceReceivedDate = dr["FreightInvoiceReceivedDate"].ToString();
                    airFreight.BillSubDateForPayment = dr["BillSubDateForPayment"].ToString();
                    airFreight.PaymentDate = dr["PaymentDate"].ToString();
                    airFreight.CHQPOSubmitDateToForwarder = dr["CHQPOSubmitDateToForwarder"].ToString();
                    airFreight.AWABReleaseDate = dr["AWABReleaseDate"].ToString();
                    airFreight.Remarks = dr["Remarks"].ToString();
                    airFreight.AirFreightFiles = GetAttachments(((int)dr["AirFreightDetailsId"]));
                    airFreights.Add(airFreight);
                }
                return airFreights;
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

        public string GetIncoterm(int id)
        {
            string temp = "---";
            switch (id)
            {
                case 1:
                    temp = "EXW";
                    break;
                case 2:
                    temp = "FCA";
                    break;
                case 3:
                    temp = "CPT";
                    break;
                case 4:
                    temp = "CIP";
                    break;
                case 5:
                    temp = "DAT";
                    break;
                case 6:
                    temp = "DAP";
                    break;
                case 7:
                    temp = "DDP";
                    break;
                case 8:
                    temp = "FAS";
                    break;
                case 9:
                    temp = "FOB";
                    break;
                case 10:
                    temp = "CFT";
                    break;
                case 11:
                    temp = "CIF";
                    break;
                default:
                    temp = "---";
                    break;
            }

            return temp;
        }

        public List<AirFreightFile> GetAttachments(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<AirFreightFile> airFreights = new List<AirFreightFile>();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_AirFreightFileFromDId", aList);
                while (dr.Read())
                {
                    AirFreightFile airFreightFile = new AirFreightFile();
                    airFreightFile.AirFreightFileId = (int)dr["AirFreightFileId"];
                    airFreightFile.FileName = dr["FileName"].ToString();
                    airFreightFile.ServerFileName = dr["ServerFileName"].ToString();
                    airFreightFile.FilePath = dr["FilePath"].ToString();
                    airFreightFile.ShortPath = dr["ShortPath"].ToString();
                    airFreights.Add(airFreightFile);
                }
                return airFreights;
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

        public AirFreightMaster GetAirFreightMasterById(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                var airFreightMaster = new AirFreightMaster();
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAirFreightMasterDataById", aList);
                if (dr.Read())
                {
                    airFreightMaster.ExceptionMasterId = (int)dr["ExceptionMasterId"];
                    airFreightMaster.BusinessUnitId = (int)dr["BusinessUnitId"];
                    airFreightMaster.BuyersNameId = (int)dr["BuyersNameId"];
                    airFreightMaster.ForwarderId = (int)dr["ForwarderId"];
                    airFreightMaster.FrieghtCostOnACOf = dr["FrieghtCostOnACOf"].ToString() == "" ? 0 : (int)dr["FrieghtCostOnACOf"];
                    airFreightMaster.USDToBDTRate = (decimal)dr["USDToBDTRate"];
                    airFreightMaster.ERDate = dr["EUpdateDate"].ToString();
                }
                return airFreightMaster;
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

        public dynamic GetAirFreightDashboardData(string createDate, int businessUnit, int buyerId, int forwarder, int fciaf, int modeOfShipment)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@CreateDate", createDate));
                aList.Add(new SqlParameter("@BusinessUnit", businessUnit));
                aList.Add(new SqlParameter("@BuyerId", buyerId));
                aList.Add(new SqlParameter("@Forwarder", forwarder));
                aList.Add(new SqlParameter("@Fciaf", fciaf));
                aList.Add(new SqlParameter("@ModeOfShipment", modeOfShipment));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_AirFreightDashboardData", aList);

                var dataList = new List<dynamic>();

                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        AirFreightMasterId = (int)dr["AirFreightMasterId"],
                        ExceptionMasterId = (int)dr["ExceptionMasterId"],
                        UpdateDate = dr["EUpdateDate"].ToString(),
                        BusinessUnit = dr["BusinessUnitName"].ToString(),
                        BuyersName = dr["BuyerName"].ToString(),
                        Forwarder = dr["Name"].ToString(),
                        FrieghtCostOnACOf = dr["FrieghtCostOnACOf"].ToString() == "" ? "---" : dr["FrieghtCostOnACOf"].ToString() == "1" ? "Buyer" : "SQ",
                        AirFreightDetailsId = dr["AirFreightDetailsId"].ToString(),
                        PO = dr["PO"].ToString(),
                        ParentPO = dr["ParentPO"].ToString(),
                        ModeOfShipment = (int)dr["ModeOfShipmentId"] == 0 ? "---" : (int)dr["ModeOfShipmentId"] == 1 ? "Air" : "Sea & Air",
                        PortOfDestination = dr["PortOfDestination"].ToString(),
                        CountryOfDestination = dr["CountryName"].ToString(),
                        Incoterm = GetIncoterm(dr["IncotermId"].ToString() == "" ? 0 : (int)dr["IncotermId"]),
                        InvoiceNo = dr["InvoiceNo"].ToString(),
                        InvoiceValueInUSD = (decimal)dr["InvoiceValueInUSD"],
                        QTYInPack = (int)dr["QTYInPack"],
                        QTYInPcERApproved = (int)dr["QTYInPcERApproved"],
                        QtyInPc = (int)dr["QtyInPc"],
                        QtyInCtn = (int)dr["QtyInCtn"],
                        GrossWeightInKg = (decimal)dr["GrossWeightInKg"],
                        HAWBLNo = dr["HAWBLNo"].ToString(),
                        HAWBLDate = dr["_HAWBLDate"].ToString(),
                        ChargeableWeightInKgERApproved = (decimal)dr["ChargeableWeightInKgERApproved"],
                        FreightAmountInUSDErApproved = (decimal)dr["FreightAmountInUSDErApproved"],
                        ChargeableWeightInKg = (decimal)dr["ChargeableWeightInKg"],
                        FreightAmountInUSD = (decimal)dr["FreightAmountInUSD"],
                        FrieghtRatePerKgERApproved = (decimal)dr["FrieghtRatePerKgERApproved"],
                        FreightRatePerKg = (decimal)dr["FreightRatePerKg"],
                        FreightAmountInBDT = (decimal)dr["FreightAmountInBDT"],
                        FreightInvoiceNo = dr["FreightInvoiceNo"].ToString(),
                        FreightInvoiceReceivedDate = dr["_FreightInvoiceReceivedDate"].ToString(),
                        BillSubDateForPayment = dr["_BillSubDateForPayment"].ToString(),
                        PaymentDate = dr["_PaymentDate"].ToString(),
                        CHQPOSubmitDateToForwarder = dr["_CHQPOSubmitDateToForwarder"].ToString(),
                        AWABReleaseDate = dr["_AWABReleaseDate"].ToString(),
                        Remarks = dr["Remarks"].ToString(),
                        ExFactoryDate = dr["_ExFactoryDate"].ToString()
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

        public dynamic GetAllCountries()
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAllCountries", aList);

                var dataList = new List<dynamic>();

                while (dr.Read())
                {
                    dataList.Add(new
                    {
                        value = (int)dr["CountryId"],
                        text = dr["CountryName"].ToString()
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

        public ResultResponse DeleteAirFreightDetails(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_DeleteAirFreightDetails", aList);
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

        public ResultResponse DeleteAirFreightFileDetails(int id)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.SQQeye);
                List<SqlParameter> aList = new List<SqlParameter>();
                aList.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_DeleteAirFreightFileDetails", aList);
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
    }
}