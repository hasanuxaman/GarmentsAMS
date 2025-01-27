using DocSoOperation.Models;
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
    public class EventController : Controller
    {

        EventDAL eventDAL = new EventDAL();

        // GET: Event
        public ActionResult EventView()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        public ActionResult GetEventPartial(string viewName)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.GeneratedID = eventDAL.GenerateID();
            return PartialView(viewName);
        }

        public ActionResult LoadEvents()
        {
            return Json(eventDAL.GetAllEvents(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadLocations()
        {
            return Json(eventDAL.GetAllLocation(), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult EventSubmit(int eventId, int location, string name, string employeeId, string designation, string department, int sbu)
        //{

        //    if (Session["SQuserId"] == null)
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }

        //    string msg = string.Empty;
        //    string registerId = string.Empty;

        //    int userid = Convert.ToInt32(Session["SQuserId"]);

        //    if (!string.IsNullOrEmpty(eventId.ToString()) && !string.IsNullOrEmpty(location.ToString()) 
        //        && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(employeeId) && !string.IsNullOrEmpty(designation) 
        //        && !string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(sbu.ToString()))
        //    {
        //        var dt = eventDAL.EventCreate(eventId, location, name, employeeId, designation, department, sbu, userid);
        //        if (dt.Rows.Count > 0)
        //        {
        //            DataRow row = dt.Rows[0];

        //            msg = row["message"].ToString();
        //            registerId = row["registerId"].ToString();
        //        }
        //    }

        //    return Json(new { msg = msg, registerId = registerId });
        //}
        [HttpPost]
        public ActionResult EventSubmit(EventRegisterModel eventModel)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ResultResponse result = new ResultResponse();
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            result = eventDAL.EventCreate(eventModel, userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetAllEventRequest(string ViewName)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());

            return PartialView(ViewName, eventDAL.GetAllEventsRequest(userID));
        }

        public ActionResult EventHRView()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult GetAllRequest(string ViewName)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }

            return PartialView(ViewName, eventDAL.GetAllRequest());
        }
    }
}