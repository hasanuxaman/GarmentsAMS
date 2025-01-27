using DocSoOperation.Models;
using SQIndustryThree.DAL;
using SQIndustryThree.Models;
using SQIndustryThree.Models.ExportShipment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SQIndustryThree.Controllers
{
    public class ExportController : Controller
    {
        ExportShipmentDAL exportDAL = new ExportShipmentDAL();
        public ActionResult AddNewExportShipment(int? id)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            ViewBag.ExportShipmentMasterId = id == null ? 0 : id;

            return View();
        }
        
        public ActionResult ExportShipmentList()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }
        
        public ActionResult ExportShipmentDashboard()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }

        public ActionResult ExportFileUpload()
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
                        var ServerSavePath = Path.Combine(Server.MapPath("~/ExportFileUpload/") + FullFileWithext);
                        var FilePath = @"\ExportFileUpload\" + FullFileWithext;
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
                System.IO.File.Delete(Server.MapPath("~/ExportFileUpload/") + FilePath);
                result = true;
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateExportShipment(ExportShipmentMaster data)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(exportDAL.CreateNewExportShipment(userID, data), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadShippers()
        {
            return Json(exportDAL.GetAllShippers(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadComapanies()
        {
            return Json(exportDAL.GetAllCompanies(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadContainerSize()
        {
            return Json(exportDAL.GetAllContainerSize(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadContainerType()
        {
            return Json(exportDAL.GetAllContainerType(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadUnits()
        {
            return Json(exportDAL.GetAllUnits(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadAccountLead()
        {
            return Json(exportDAL.GetAllAccountLead(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllExportShipmentList()
        {
            return Json(exportDAL.GetAllExportShipmentList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ExportShipmentDetailsListForMasterId(int id)
        {
            return Json(exportDAL.GetExportShipmentDetailsListForMasterId(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadICTMasterDataForModification(int id)
        {
            var exportConsignmentMaster = exportDAL.GetExportMasterById(id);
            exportConsignmentMaster.ExportShipmentDetails = exportDAL.GetDetailsListForMod(id);
            return Json(exportConsignmentMaster, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteExportShipmentFileDetails(int id)
        {
            return Json(exportDAL.DeleteExportShipmentFileDetails(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ExportInfoSaveForMod(ExportShipmentMaster data)
        {
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(exportDAL.SubmitDataForMod(userID, data), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteICD(int id)
        {
            return Json(exportDAL.DeleteICTDetails(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadExportShipmentDashboardData(string _fromDate, string _toDate, int _businessUnitId, int _buyerId, int _shipperId)
        {
            return Json(exportDAL.GetExportShipmentDashboardData(_fromDate, _toDate, _businessUnitId, _buyerId, _shipperId), JsonRequestBehavior.AllowGet);
        }
    }
}
