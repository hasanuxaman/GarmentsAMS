using DocSoOperation.Models;
using SQIndustryThree.DAL;
using SQIndustryThree.Models;
using SQIndustryThree.Models.AirFreightTracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SQIndustryThree.Controllers
{
    public class ExceptionController : Controller
    {
        ExceptionDAL exceptionDAL = new ExceptionDAL();
        AirFreightDAL airFreightDAL = new AirFreightDAL();
        // GET: Exception
        public ActionResult ExceptionRequest()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }
        public ActionResult ExceptionHRView()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }
        public ActionResult ExceptionReportView()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }
        public ActionResult ExceptionApproval()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        public ActionResult GetWidgetPartial(string viewName)
        {
            return PartialView(viewName);
        }

        public ActionResult LoadBuyer()
        {
            int userid = Convert.ToInt32(Session["SQuserId"]);
            return Json(exceptionDAL.LoadBuyerList(userid), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllBuyerList()
        {
            int userid = Convert.ToInt32(Session["SQuserId"]);
            return Json(airFreightDAL.LoadBuyerList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadReasonCategory()
        {
            int userid = Convert.ToInt32(Session["SQuserId"]);
            return Json(exceptionDAL.LoadExcpCategory(userid), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ModalShowBeforeSubmit(ExceptionRequestMaster exceptionRequestMaster)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return PartialView("_ReviewExceptionModal", exceptionRequestMaster);
        }
        [HttpPost]
        public ActionResult SaveExceptionRequest(ExceptionRequestMaster ExceptionMasterInfo)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ResultResponse result = new ResultResponse();
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            result = exceptionDAL.SaveExceptionRequest(ExceptionMasterInfo, userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveExceptionRequestDraft(ExceptionRequestMaster ExceptionMasterInfo)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ResultResponse result = new ResultResponse();
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            result = exceptionDAL.SaveExceptionRequestDraft(ExceptionMasterInfo, userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ExceptionFileUpload()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            List<CapexFileUploadDetails> fileuploadList = new List<CapexFileUploadDetails>();
            if (Request.Files.Count > 0)
            {
                var files = Request.Files;
                foreach (string str in files)
                {
                    HttpPostedFileBase file = Request.Files[str] as HttpPostedFileBase;
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var currentmilse = DateTime.Now.Ticks;
                        var InputFileName = Path.GetFileNameWithoutExtension(file.FileName);
                        var InputFileExtention = Path.GetExtension(file.FileName);
                        var FullFileWithext = InputFileName + currentmilse + InputFileExtention;
                        var ServerSavePath = Path.Combine(Server.MapPath("~/ExceptionFileUpload/") + FullFileWithext);
                        var FilePath = @"\ExceptionFileUpload\" + FullFileWithext;
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        CapexFileUploadDetails fileUploadModel = new CapexFileUploadDetails();
                        fileUploadModel.CapexFileName = file.FileName.ToString();
                        fileUploadModel.CapexFilePath = ServerSavePath;
                        fileUploadModel.ServerFileName = FullFileWithext;
                        fileUploadModel.ShortPath = FilePath;
                        fileuploadList.Add(fileUploadModel);
                    }
                }
            }
            return Json(fileuploadList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteFiles(string FilePath)
        {
            bool result = false;
            try
            {
                System.IO.File.Delete(Server.MapPath("~/ExceptionFileUpload/") + FilePath);
                result = true;
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetApproverListMaster(int BusinessUnit, int BuyerID, int SupplyChain)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return Json(exceptionDAL.GetApproverList(BusinessUnit, BuyerID, SupplyChain), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAllExceptionRequest(int Status, string ViewName, int Progrss)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return PartialView(ViewName, exceptionDAL.GetAllexceptionRequest(userID, Status, Progrss));
        }
        [HttpPost]
        public ActionResult GetExceptionReportList(string FromDate, string ToDate, int BusinessUnit, int BuyerName, int ExceptionType, int ReasonCatagory)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return PartialView("_excpReportAllList", exceptionDAL.AllExceprionReportList(userID, FromDate, ToDate, BusinessUnit, BuyerName, ExceptionType, ReasonCatagory));
        }
        [HttpPost]
        public ActionResult IndividualExceptionRequest(int MasterID, string ViewName, int UserType)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            ExceptionRequestMaster exceptionRequestMaster = exceptionDAL.IndividualRequestInfo(MasterID);
            exceptionRequestMaster.ShowType = UserType;
            return PartialView(ViewName, exceptionRequestMaster);
        }
        [HttpPost]
        public ActionResult SendComments(int MasterID, int ReviewTo, string ReviewMessage)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(exceptionDAL.CommentSent(MasterID, ReviewTo, ReviewMessage, userID), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ApproveOrReject(string CommentText, int Progress, int ExceptionMasterId)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(exceptionDAL.ApproveOrReject(Progress, CommentText, userID, ExceptionMasterId), JsonRequestBehavior.AllowGet);

        }
        public ActionResult UpdateExceptionRequest(ExceptionRequestMaster ExceptionMasterInfo)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ResultResponse result = new ResultResponse();
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            result = exceptionDAL.UpdateExceptionRequest(ExceptionMasterInfo, userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateExceptionRequestDraft(ExceptionRequestMaster ExceptionMasterInfo)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ResultResponse result = new ResultResponse();
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            result = exceptionDAL.UpdateExceptionRequestDraft(ExceptionMasterInfo, userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //////// Second phase of development ////////

        public ActionResult AirFreightDetailsPage(int? id)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            ViewBag.AirFreightMasterId = id == null ? 0 : id;
            //if (id != null)
            //{
            //    //ViewBag.date
            //    var airFreightMaster = airFreightDAL.GetAirFreightMasterById(id.Value);
            //    airFreightMaster.AirFreightDetails = airFreightDAL.GetPoListForAirFreightMaster(id.Value);
            //}

            return View();
        }

        public ActionResult AirFreightDashboard()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }

        public ActionResult AirFreightList()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        public ActionResult loadERData()
        {
            return Json(airFreightDAL.LoadERList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadForwarders()
        {
            return Json(airFreightDAL.LoadForwardersList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadDataAgainstERId(int id)
        {
            var ERData = airFreightDAL.LoadDataAgainstERId(id);
            ERData.ExpgenaralInfoList = airFreightDAL.LoadPOAgainstERId(id);
            return Json(ERData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AirFreightInfoSaveForSQ(AirFreightMaster data)
        {
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(airFreightDAL.SubmitDataForSQ(userID, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AirFreightInfoSaveForMod(AirFreightMaster data)
        {
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(airFreightDAL.SubmitDataForMod(userID, data), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllAirFreightList()
        {
            return Json(airFreightDAL.GetAllAirFreightList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult PoListForAirFreightMaster(int id)
        {
            return Json(airFreightDAL.GetPoListForAirFreightMaster(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadMasterDataForModification(int id)
        {
            var airFreightMaster = airFreightDAL.GetAirFreightMasterById(id);
            airFreightMaster.AirFreightDetails = airFreightDAL.GetPoListForAirFreightMaster(id);
            return Json(airFreightMaster, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadAirFreightDashboardData(string _createDate, int _businessUnit, int _buyerId, int _forwarder, int _fciaf, int _modeOfShipment)
        {
            return Json(airFreightDAL.GetAirFreightDashboardData(_createDate, _businessUnit, _buyerId, _forwarder, _fciaf, _modeOfShipment), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllCountryListDD()
        {
            return Json(airFreightDAL.GetAllCountries(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AirFreightTracker()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        public ActionResult DeleteAFD(int id)
        {
            return Json(airFreightDAL.DeleteAirFreightDetails(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteAirFreightFileDetails(int id)
        {
            return Json(airFreightDAL.DeleteAirFreightFileDetails(id), JsonRequestBehavior.AllowGet);
        }
    }
}
