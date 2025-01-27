using SQInventory.Models.FGWH;
using SQInventory.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//using SQInventory.Models.FGWH;
using DocSoOperation.Models;
using SQIndustryThree.DAL;
using SQIndustryThree.EntityManager.FGWHDB;
using SQIndustryThree.EntityManager.SQQEYEDatabase;
//using SQInventory.Models;

namespace SQInventory.Controllers
{
    public class CartonEntryController : Controller
    {
        CartonEntryDAl CartonDal = new CartonEntryDAl();
        AdminDAL adminDAL = new AdminDAL();
        HomeDAL homeDAL = new HomeDAL();

        SQQEYEDbContext _db =new SQQEYEDbContext();
        FGWHDbContext _dbContext = new FGWHDbContext();
        // GET: CartonEntry
        public ActionResult CartonEntry(string UserEmail, string UserPasswor)
        {
            List<ModelCartonCreate> model ;
            try
            {
                
                if (Session["SQuserId"]==null)
                {
                    return RedirectToAction("Index", "Account");
                }
                //model = _dbContext.CartonCreates.ToList();
                 model = GetAll();
                 ViewBag.Buyer = _db.Buyers.ToList();
               
                ViewBag.BusinessUnit = _db.BusinessUnits.ToList();

            }
            catch
            {
                throw;
            }
            return View(model);
        }
        //[HttpPost]
        //public ActionResult SaveChange(tbl_CartonCreate _Carton)
        //{
        //    _Carton.CreateBy = Session["SQuserId"].ToString();
        //    _Carton.CreateDater = DateTime.Now;
        //    _Carton.UpdateBy= Session["SQuserId"].ToString();
        //    _Carton.UpdateDate = DateTime.Now;
        //    _dbfgwh.tbl_CartonCreate.Add(_Carton);
        //    _dbfgwh.SaveChanges();
        //    return RedirectToAction("CartonEntry");
        //}

        [HttpPost]
        public ActionResult SaveCarton(ModelCartonCreate _carton)
        {
            //_carton.cartonDetails;
            ResultResponse result = new ResultResponse();
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            _carton.CreateDate = DateTime.Now;
            _carton.CreateBy = userID.ToString();
            _carton.UpdateDate = DateTime.Now;
            _carton.UpdateBy = userID.ToString();
            result.isSuccess = true;   
             CartonDal.SaveCarton(_carton, userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCartonDetailsAll(int CartonID)
        {
            List<CartonDetails> ItemDetails = CartonDal.GetCartonDetailsById(CartonID);
            return Json(ItemDetails);
        }

        public List<ModelCartonCreate> GetAll()
        {
            List<ModelCartonCreate> ItemDetails = CartonDal.GetCartonMaster();
            return (ItemDetails);
           
        }
       
    }
}