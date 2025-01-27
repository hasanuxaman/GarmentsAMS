using DocSoOperation.Models;
using SQIndustryThree.BillFileUpload;
using SQIndustryThree.DAL;
using SQIndustryThree.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQIndustryThree.Controllers
{
    public class HomeController : Controller
    {
        BasicUtilities _BasicUtilities = new BasicUtilities();
        HomeDAL homedal = new HomeDAL();
        public ActionResult Index()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        
        [HttpPost]
        public ActionResult GetUserInformation()
        {

            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            UserInformation users = homedal.GetUserInformation(userID);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RecoveryPassword()
        {

            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            bool result= homedal.RecoveryPassword(userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ChangePassword(string email,string oldpass, string newpass)
        {
            bool result = false;
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            UserInformation users = homedal.CheckUserLogin(email, oldpass);
            if (users.Empty)
            {
                result = false;
            }
            else
            {
                result = homedal.changePassword(userID, newpass);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadProductionUnit(int business_unit)
        {
            try
            {
                string _Msg;
                DataTable dt_business_unit = homedal.LoadProductionUnit(business_unit);

                if (dt_business_unit.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _business_unitList = _BasicUtilities.GetTableRows(dt_business_unit);
                    return Json(_business_unitList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        public JsonResult LoadModule()
        {
            try
            {
                string _Msg;
                DataTable dt_business_unit = homedal.LoadModule();

                if (dt_business_unit.Rows.Count > 0)
                {
                    _Msg = "DONE";
                    List<Dictionary<string, object>> _business_unitList = _BasicUtilities.GetTableRows(dt_business_unit);
                    return Json(_business_unitList);
                }
                else
                {
                    _Msg = "ERROR";
                    return Json(_Msg);
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);

            }
        }
        [HttpPost]
        public ActionResult SaveQMSUser(QMSUserCreate qMSUserCreate)
        {
            ResultResponse result = new ResultResponse();
            // int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            result = homedal.SaveQMSUser(qMSUserCreate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}