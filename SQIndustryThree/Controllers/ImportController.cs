using DocSoOperation.Models;
using SQIndustryThree.DAL;
using SQIndustryThree.Models;
using SQIndustryThree.Models.ImportConsignment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SQIndustryThree.Controllers
{
    public class ImportController : Controller
    {
        ImportConsignmentDAL importDAL = new ImportConsignmentDAL();
        public ActionResult AddNewImportConsignment(int? id)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            ViewBag.ImportConsignmentMasterId = id == null ? 0 : id;

            return View();
        }
        
        public ActionResult ImportConsignmentList()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }
        
        public ActionResult ImportConsignmentDashboard()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return View();
        }

        public ActionResult ImportFileUpload()
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
                        var ServerSavePath = Path.Combine(Server.MapPath("~/ImportFileUpload/") + FullFileWithext);
                        var FilePath = @"\ImportFileUpload\" + FullFileWithext;
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
                System.IO.File.Delete(Server.MapPath("~/ImportFileUpload/") + FilePath);
                result = true;
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateImportConsignment(ImportConsignmentMaster data)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(importDAL.CreateNewImportConsignment(userID, data), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadShippers()
        {
            return Json(importDAL.GetAllShippers(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadComapanies()
        {
            return Json(importDAL.GetAllCompanies(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadContainerSize()
        {
            return Json(importDAL.GetAllContainerSize(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadContainerType()
        {
            return Json(importDAL.GetAllContainerType(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadUnits()
        {
            return Json(importDAL.GetAllUnits(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LoadAccountLead()
        {
            return Json(importDAL.GetAllAccountLead(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllImportConsignmentList()
        {
            return Json(importDAL.GetAllImportConsignmentList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ImportConsignmentDetailsListForMasterId(int id)
        {
            return Json(importDAL.GetImportConsignmentDetailsListForMasterId(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult loadICTMasterDataForModification(int id)
        {
            var importConsignmentMaster = importDAL.GetImportMasterById(id);
            importConsignmentMaster.ImportConsignmentDetails = importDAL.GetDetailsListForMod(id);
            return Json(importConsignmentMaster, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteImportConsignmentFileDetails(int id)
        {
            return Json(importDAL.DeleteImportConsignmentFileDetails(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ImportInfoSaveForMod(ImportConsignmentMaster data)
        {
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            return Json(importDAL.SubmitDataForMod(userID, data), JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteICD(int id)
        {
            return Json(importDAL.DeleteICTDetails(id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult LoadImportConsignmentDashboardData(string _fromDate, string _toDate, int _businessUnitId, int _buyerId, int _shipperId)
        {
            return Json(importDAL.GetImportConsignmentDashboardData(_fromDate, _toDate, _businessUnitId, _buyerId, _shipperId), JsonRequestBehavior.AllowGet);
        }
    }
}
