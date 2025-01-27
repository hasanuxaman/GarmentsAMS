using DocSoOperation.Models;
using SQIndustryThree.DAL;
using SQIndustryThree.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SQIndustryThree.Controllers
{
    public class ExceptionRequestController : Controller
    {
        ExceptionRequestDAL exceptionDAL = new ExceptionRequestDAL();
        // GET: Exception
        public ActionResult ExceptionRequestHRM()
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
        public ActionResult IndexApproverHRM()
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
        public ActionResult HRMExceptionApproval()
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
            return Json(exceptionDAL.LoadBuyerList(0), JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadReasonCategory()
        {
            int userid = Convert.ToInt32(Session["SQuserId"]);
            return Json(exceptionDAL.LoadExcpCategory(userid), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadLocation()
        {
            int userid = Convert.ToInt32(Session["SQuserId"]);
            return Json(exceptionDAL.GetLocation(userid), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ModalShowBeforeSubmit(ExceptionRequestHRMaster exceptionRequestMaster)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return PartialView("_ReviewExceptionHRModal", exceptionRequestMaster);
        }
        [HttpPost]
        public ActionResult SaveExceptionRequest(ExceptionRequestHRMaster ExceptionMasterInfo)
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
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        CapexFileUploadDetails fileUploadModel = new CapexFileUploadDetails();
                        fileUploadModel.CapexFileName = file.FileName.ToString();
                        fileUploadModel.CapexFilePath = ServerSavePath;
                        fileUploadModel.ServerFileName = FullFileWithext;
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
        public ActionResult GetApproverListMaster(int BusinessUnit)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return Json(exceptionDAL.GetApproverList(BusinessUnit), JsonRequestBehavior.AllowGet);
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
            ExceptionRequestHRMaster exceptionRequestMaster = exceptionDAL.IndividualRequestInfo(MasterID);
            // exceptionRequestMaster.ShowType = UserType;
            exceptionRequestMaster.Status = UserType;
            return PartialView(ViewName, exceptionRequestMaster);
        }
        [HttpPost]
        public ActionResult ExpApproveOrReject(string CommentText, int Progress, int ExpRequestId)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(exceptionDAL.ExpApproveOrReject(Progress, CommentText, userID, ExpRequestId), JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult showExceptionRequestWisePositionCode(int business_unit, string month)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            List<PositionCodeDetails> CourierTypeList = exceptionDAL.GetshowExceptionRequestWisePositionCode(business_unit, month);
            return PartialView("_PositionCodePertialView", CourierTypeList);
        }
        [HttpPost]
        public ActionResult showExceptionRequestWisePositione()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());

            return PartialView("_PositionCodePertialViewd");
        }
        [HttpPost]
        public ActionResult LoadDesignation()
        {
            return Json(exceptionDAL.GetAllDesignation(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadSection()
        {
            return Json(exceptionDAL.LoadSection(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadUnit()
        {
            return Json(exceptionDAL.LoadUnit(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadSubSection()
        {
            return Json(exceptionDAL.LoadSubSection(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadCategory()
        {
            return Json(exceptionDAL.LoadCategory(), JsonRequestBehavior.AllowGet);
        }
    }
}
