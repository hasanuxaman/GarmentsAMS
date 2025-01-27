using DocSoOperation.Models;
using SQIndustryThree.DAL;
using SQIndustryThree.Models;
using SQIndustryThree.Models.BillApproval;
using SQIndustryThree.Models.Courier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SQIndustryThree.Controllers
{
    public class AdminController : Controller
    {
        AdminDAL adminDAL = new AdminDAL();
        CapexApprovalDAL capexApprovalDAL = new CapexApprovalDAL();
        HomeDAL homeDAL = new HomeDAL();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminPanel()
        {
            if (Session["SQAdminID"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult ApprovalManagementSystem()
        {
            if (Session["SQAdminID"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
       
        [HttpPost]
        public ActionResult AllApprovedCapex(int BusinessUnitID,int CatagoryID,string SelectDate,string EndDate)
        {
            if (Session["SQAdminID"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            int userID = Convert.ToInt32(Session["SQAdminID"].ToString());
            List<CapexInformationMaster> capexInformationList = adminDAL.GetALLCapexInfo(BusinessUnitID, CatagoryID, SelectDate, EndDate);
            return PartialView("_pertialCapexForAdmin", capexInformationList);
        }

        [HttpPost]
        public ActionResult IndividualCapexShow(int primarykey)
        {
            if (Session["SQAdminID"] == null)
            {
                return RedirectToAction("Index", "Admin");
            }
            int userID = 0;
            return PartialView("_capexIdShowAdmin", capexApprovalDAL.GetSavedCapex(userID, primarykey));
        }


        [HttpPost]
        public ActionResult CheckAdminLogin(string UserEmail,string UserPassword)
        {
            ResultResponse result = new ResultResponse();
            UserInformation users = adminDAL.AdminUserLogin(UserEmail, UserPassword);
            if (users.Empty)
            {
                result.isSuccess = true;
                result.msg = "Wrong Username Or Password";
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result.isSuccess = false;
                result.msg = Url.Action("DashboardAdmin", "Admin");
                Session["SQAdminID"] = users.UserInformationId;
                Session["SQAdminName"] = users.UserInformationName;
                Session["SQAdminEmail"] = users.UserInformationEmail;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        public ActionResult DashboardAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoadBusinessUnit()
        {
            return Json(adminDAL.GetBusinessUnits(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadCatagory()
        {
            return Json(capexApprovalDAL.GetCapexCatagory(0), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadDesignation()
        {
            return Json(adminDAL.GetAllDesignation(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult LoadUsers()
        {
            return Json(adminDAL.GetAllUsers(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RegisterUser(UserInformation users)
        {
            bool result = homeDAL.SAveUsersToDataBase(users);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateDesignation(string DesignationName)
        {
            bool result = homeDAL.CreateDesignation(DesignationName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveApproverList(ApproverModelClass approverModelClass)
        {
            bool result = adminDAL.SaveApproverList(approverModelClass);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult showApproverList(int BusinessUnitId,int CatagoryId)
        {
            List<UserInformation> userlist  = adminDAL.ShowApproverListByBU(BusinessUnitId,CatagoryId);
            return Json(userlist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LoadBillSupplier()
        {
            return Json(adminDAL.GetAllBillSuppliers(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LoadBillCurrency()
        {
            return Json(adminDAL.GetAllBillCurrency(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LoadBillUnit()
        {
            return Json(adminDAL.GetAllBillUnits(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChangeDivView(int status)
        {
            string viewName = "";
            switch(status){
                case 0:
                    viewName = "_createUsers";
                    break;
                case 1:
                    viewName = "_createDesignation";
                    break;
                case 2:
                    viewName = "_createBusinessUnit";
                    break;
                case 6:
                    viewName = "_setApproverList";
                    break;
                case 8:
                    viewName = "_PartialViewExceptionApprover";
                    break;
                case 7:
                    viewName = "_iouSetapproverList";
                    break;
                case 9:
                    viewName = "_billSupplierList";
                    break;
                case 10:
                    viewName = "_billCurrencyList";
                    break;
                case 11:
                    viewName = "_billUnitList"; //_billUnitList
                    break;
                case 12:
                    viewName = "_createQMSUsers";
                    break;
            }
            return PartialView(viewName);
          
        }


        public ActionResult GetAllBillSuppliers()
        {
            JsonResult result = new JsonResult();
            try
            {
                string search = Request.Form.GetValues("search[value]")[0];
                string draw = Request.Form.GetValues("draw")[0];
                string order = Request.Form.GetValues("order[0][column]")[0];
                string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);

                //Loading
                List<BillSupplier> data = adminDAL.GetAllBillSuppliers();

                //Total record count
                int totalRecords = data.Count;

                //Verification
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    //Apply Search
                    data = data.Where(a =>
                    a.SupplierID.ToString().ToLower().Contains(search.ToLower()) ||
                    a.Supplier.ToLower().Contains(search.ToLower())).ToList();
                }

                //Sorting
                data = adminDAL.SupplierSorting(order, orderDir, data);

                // Filter record count.
                int recFilter = data.Count;

                // Apply pagination.
                data = data.Skip(startRec).Take(pageSize).ToList();

                // Loading drop down lists.
                result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            return result;
        }

        public ActionResult GetAllBillCurrency()
        {
            JsonResult result = new JsonResult();
            try
            {
                string search = Request.Form.GetValues("search[value]")[0];
                string draw = Request.Form.GetValues("draw")[0];
                string order = Request.Form.GetValues("order[0][column]")[0];
                string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);

                //Loading
                List<BillCurrency> data = adminDAL.GetAllBillCurrency();

                //Total record count
                int totalRecords = data.Count;

                //Verification
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    //Apply Search
                    data = data.Where(a =>
                    a.CurrencyID.ToString().ToLower().Contains(search.ToLower()) ||
                    a.CurrencyCode.ToLower().Contains(search.ToLower()) ||
                    a.Currency.ToLower().Contains(search.ToLower())).ToList();
                }

                //Sorting
                data = adminDAL.CurrencySorting(order, orderDir, data);

                // Filter record count.
                int recFilter = data.Count;

                // Apply pagination.
                data = data.Skip(startRec).Take(pageSize).ToList();

                // Loading drop down lists.
                result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            return result;
        }

        public ActionResult GetAllBillUnits()
        {
            JsonResult result = new JsonResult();
            try
            {
                string search = Request.Form.GetValues("search[value]")[0];
                string draw = Request.Form.GetValues("draw")[0];
                string order = Request.Form.GetValues("order[0][column]")[0];
                string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);

                //Loading
                List<BillUnit> data = adminDAL.GetAllBillUnits();

                //Total record count
                int totalRecords = data.Count;

                //Verification
                if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                {
                    //Apply Search
                    data = data.Where(a =>
                    a.UnitID.ToString().ToLower().Contains(search.ToLower()) ||
                    a.UnitName.ToLower().Contains(search.ToLower())).ToList();
                }

                //Sorting
                data = adminDAL.UnitSorting(order, orderDir, data);

                // Filter record count.
                int recFilter = data.Count;

                // Apply pagination.
                data = data.Skip(startRec).Take(pageSize).ToList();

                // Loading drop down lists.
                result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            return result;
        }
        public ActionResult UserIndex()
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("UserIndex", "Admin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult GetAllUserInfo(int Status, string ViewName, int Progrss)
        {
            try
            {
                if (base.Session["SQuserId"] == null)
                {
                    return base.RedirectToAction("Index", "Account");
                }
                int userID = Convert.ToInt32(base.Session["SQuserId"].ToString());
                return this.PartialView(ViewName, adminDAL.GetAllUserInfo(userID, Status, Progrss));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ActionResult EditUserInfo(int edituserId)
        {
            Session["UserMenuView"] = edituserId;
            try
            {
                if (Session["SQuserId"] == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                int userID = Convert.ToInt32(Session["SQuserId"].ToString());
                UserInformationModel userInformationModel = this.adminDAL.GetUserInformation(userID, edituserId);
                ////courierRequestModel.Status = Status;
                return this.PartialView("_updateUserInformation", userInformationModel);
                //  return PartialView("_updateCourierTypepertialView", courierDAL.GetcourierType(userID, courierTypeid));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ActionResult GetUserInfo()
        {
            var edituserId = Convert.ToInt32(Session["UserMenuView"]);
            try
            {
                if (Session["SQuserId"] == null)
                {
                    return RedirectToAction("Index", "Account");
                }
                int userID = Convert.ToInt32(Session["SQuserId"].ToString());
                UserInformationModel userInformationModel = this.adminDAL.GetUserInformation(userID, edituserId);
                ////courierRequestModel.Status = Status;
                return this.PartialView("_updateUserInformation", userInformationModel);
                //  return PartialView("_updateCourierTypepertialView", courierDAL.GetcourierType(userID, courierTypeid));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [HttpPost]
        public JsonResult GetUserMenu()
        {

            //List<ModuleModel> moduleList = new List<ModuleModel>();
            //moduleList = adminDAL.GetProjectmenu();
            //return Json(moduleList, JsonRequestBehavior.AllowGet);
            var roleId = Convert.ToInt32(Session["UserMenuView"]);
            int _ParentCount, _childCount, _child_childCount;
            // StringBuilder _subMenu = new StringBuilder();
            string _result = " <ul class='checktree'>";
            DataTable _MenueTable = adminDAL.UserMenuRoleDetails(roleId);
            DataTable _MenueTableHeader = adminDAL.GetProjectmenu(roleId);
            DataRow[] foundRows, foundRows2, foundRows3;
            int parentId = 0;
            if (_MenueTableHeader.Rows.Count > 0)
            {

                string strExpr = "PARENT_ID =" + parentId;

                //_childCount = dbContext.t_Menu.Count(m => m.MENU_PARENT_ID == obj.MENU_ID);
                foundRows = _MenueTable.Select(strExpr, "");
                // _MenueTable.RowFilter = "ProductID = 35";
                _ParentCount = foundRows.Count();


                if (foundRows.Length > 0)
                {
                    for (int i = 0; i < foundRows.Length; i++)
                    {
                        int ME_ID = Convert.ToInt32(foundRows[i]["ME_ID"].ToString());
                        string ME_Name = foundRows[i]["MENAME"].ToString();
                        string strExpr2 = "PARENT_ID =" + ME_ID;
                        foundRows2 = _MenueTable.Select(strExpr2, "");
                        _childCount = foundRows2.Count();
                        bool flag = Convert.ToBoolean(foundRows[i]["R_STATUS"]);



                        if (_childCount > 0)
                        {
                            //for=" + foundRows[i]["ME_ID"].ToString() + "
                            _result += "<li><label class='container'> ";
                            if (flag)
                            {
                                ME_Name = foundRows[i]["MENAME"].ToString();
                                _result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");' name='menu' class='checkbox parent " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + "  checked>" + foundRows[i]["MENAME"].ToString();

                            }
                            else
                            {
                                ME_Name = foundRows[i]["MENAME"].ToString();
                                _result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");'  name='menu' class='checkbox parent " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + ">" + foundRows[i]["MENAME"].ToString();
                            }
                            _result += " <span class='checkmark'></span></label>";
                            _result += "<ul>";

                            //foreach (DataRow row in foundRows2)
                            //{
                            //    bool flag2 = Convert.ToBoolean(row["R_STATUS"]);
                            //    string strExpr3 = "PARENT_ID =" + row["ME_ID"];

                            //    foundRows3 = _MenueTable.Select(strExpr3, "");
                            //    _child_childCount = foundRows3.Count();
                            //    //for=" + foundRows[i]["ME_ID"].ToString() + "
                            //    _result += "<li><label class='container'>";


                            //    if (flag2)
                            //    {
                            //        ME_Name = row["MENAME"].ToString();
                            //        _result += "<input id='" + row["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + row["ME_ID"].ToString() + " checked>" + row["MENAME"].ToString();
                            //        _result += "<span class='checkmark'></span>";



                            //        if (_child_childCount > 0)
                            //        {

                            //            _result += "<ul>";
                            //            foreach (DataRow rowss in foundRows3)
                            //            {
                            //                bool flag3 = Convert.ToBoolean(rowss["R_STATUS"]);

                            //                if (flag3)
                            //                {
                            //                    ME_Name = rowss["MENAME"].ToString();
                            //                    _result += "<li><label class='container'>";
                            //                    _result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + rowss["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + " checked>" + rowss["MENAME"].ToString();
                            //                    _result += "<span class='checkmark'></span>";
                            //                }
                            //                else
                            //                {
                            //                    ME_Name = rowss["MENAME"].ToString();
                            //                    _result += "<li><label class='container'>";
                            //                    _result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + rowss["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + ">" + rowss["MENAME"].ToString();
                            //                    _result += "<span class='checkmark'></span>";

                            //                }


                            //            }
                            //            _result += " </ul></li></label>";

                            //        }




                            //    }
                            //    else
                            //    {
                            //        ME_Name = row["MENAME"].ToString();
                            //        _result += "<input  id='" + row["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + row["ME_ID"].ToString() + ">" + row["MENAME"].ToString();
                            //        _result += "<span class='checkmark'></span>";


                            //        if (_child_childCount > 0)
                            //        {

                            //            _result += "<ul>";
                            //            foreach (DataRow rowss in foundRows3)
                            //            {
                            //                bool flag3 = Convert.ToBoolean(rowss["R_STATUS"]);

                            //                if (flag3)
                            //                {
                            //                    ME_Name = rowss["MENAME"].ToString();
                            //                    _result += "<li><label class='container'>";
                            //                    _result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + " checked>" + rowss["MENAME"].ToString();
                            //                    _result += "<span class='checkmark'></span>";
                            //                }
                            //                else
                            //                {
                            //                    ME_Name = rowss["MENAME"].ToString();
                            //                    _result += "<li><label class='container'>";
                            //                    _result += "<input id='" + rowss["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + rowss["ME_ID"].ToString() + ">" + rowss["MENAME"].ToString();
                            //                    _result += "<span class='checkmark'></span>";

                            //                }


                            //            }
                            //            _result += "</li></label>";

                            //        }






                            //        //_result += "<input  id='" + row["ME_ID"].ToString() + "' type='checkbox' onclick='GetChildID(" + row["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + row["ME_ID"].ToString() + ">" + row["MENAME"].ToString();
                            //        //_result += "<span class='checkmark'></span>";
                            //    }
                            //    _result += "</li></label>";
                            //}
                            _result += "</ul>";

                        }
                        else
                        {

                            _result += "<li><label class='container' >";
                            if (flag)
                            {
                                _result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + " checked>" + foundRows[i]["MENAME"].ToString();

                            }
                            else
                            {
                                _result += "<input id='" + foundRows[i]["ME_ID"].ToString() + "' type='checkbox' onclick='GetParentID(" + foundRows[i]["ME_ID"].ToString() + ");' name='menu' class='checkbox " + foundRows[i]["ME_ID"].ToString() + "' data-parent=" + foundRows[i]["ME_ID"].ToString() + " data-id=" + foundRows[i]["ME_ID"].ToString() + ">" + foundRows[i]["MENAME"].ToString();
                            }
                            _result += " <span class='checkmark'></span> </label>";
                        }

                    }

                }
                _result += "</ul>";
            }



            // return this.PartialView("_updateUserInformation", userInformationModel);

            return Json(_result);
        }
        public ActionResult UserMenu()
        {
            var edituserId = Convert.ToInt32(Session["UserMenuView"]);
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            //List<UserInformationModel> dataGet = new List<UserInformationModel>();
            UserInformationModel data = new UserInformationModel();
            var dataGet = adminDAL.GetUserInformation(userID, edituserId);
            Session["UserId"] = (int)dataGet.UserId;
            Session["UserName"] = (string)dataGet.UserName;

            if (Session["SQuserId"] == null)
            {
                UserInformationModel userInformationModel = adminDAL.GetUserInformation(userID, edituserId);
                Session["UserName"] = (string)userInformationModel.UserName;
                // return this.PartialView("_updateUserInformation", userInformationModel);
                if (userInformationModel != null)
                {
                    // userInformationModel = dataGet.FirstOrDefault();
                    ViewBag.UserId = (Int32)userInformationModel.UserId;
                    Session["UserName"] = (string)userInformationModel.UserName;
                }
                return RedirectToAction("UserMenu", "Admin");
            }
            else
            {
                return View();
            }
            //if (Session["SQuserId"] == null)
            //{
            //    return RedirectToAction("UserMenu", "Admin");
            //}
            //return View();
        }
        [HttpPost]
        public JsonResult SetMenuPermission(string menuID)
        {
            var edituserId = Convert.ToInt32(Session["UserMenuView"]);
            string _result = "";
            // string[] ps = menuID.Split(',');
            // StringBuilder _subMenu = new StringBuilder();
            var updatemenu = adminDAL.UpdateMenupermission(edituserId, menuID);


            if (updatemenu)
            {
                _result += "Update Menu Successfully";
            }
            else
            {
                _result += "Menu not updated";
            }

            return Json(_result);
        }
        [HttpPost]
        public ActionResult UpdateUserInfo(UserInformationModel userInformationModel)
        {
            if (Session["SQuserId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            ResultResponse result = new ResultResponse();
            int userID = Convert.ToInt32(Session["SQuserId"].ToString());
            result = adminDAL.UpdateUserInfo(userInformationModel, userID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBusinessUnitPartial(string viewName)
        {

            if (base.Session["SQuserId"] == null)
            {
                return base.PartialView(viewName);
            }
            return base.RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public ActionResult GetAllBusinessUnit(int Status, string ViewName, int Progrss)
        {
            try
            {
                //if (base.Session["SQuserId"] == null)
                //{
                //    return base.RedirectToAction("Index", "Account");
                //}
                //  int userID = Convert.ToInt32(base.Session["SQuserId"].ToString());
                return this.PartialView(ViewName, homeDAL.GetAllBusinessUnit(Status, Progrss));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //////////////////////////////////   Courier Admin Panel   //////////////////////////////
        
        public ActionResult CourierAdminPanel()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            return Json(homeDAL.GetAllUsers(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult UserWiseBusinessUnits(int id)
        {
            return Json(homeDAL.GetUserWiseBusinessUnits(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult CourierBusinessUnits()
        {
            return Json(homeDAL.GetCourierBusinessUnits(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult DeleteUserWiseBusienssUnit(int id)
        {
            return Json(homeDAL.DeleteUserWiseBusienssUnit(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult AddUserWiseBusienssUnit(int UserId, int BusinessUnitId)
        {
            return Json(homeDAL.AddUserWiseBusienssUnit(UserId, BusinessUnitId), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult UserWiseApprovers(int id)
        {
            return Json(homeDAL.GetUserWiseApprovers(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult CourierApprovers()
        {
            return Json(homeDAL.GetCourierApproverList(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult DeleteUserWiseApprover(int id)
        {
            return Json(homeDAL.DeleteUserWiseApprover(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult AddUserWiseApprover(int RequestorId, int UserId)
        {
            return Json(homeDAL.AddUserWiseApprover(RequestorId, UserId), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult UserWiseBuyers(int id)
        {
            return Json(homeDAL.GetUserWiseBuyers(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult CourierBuyers()
        {
            return Json(homeDAL.GetCourierBuyerList(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult DeleteUserWiseBuyer(int id)
        {
            return Json(homeDAL.DeleteUserWiseBuyer(id), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult AddUserWiseBuyer(int UserId, int BuyerId)
        {
            return Json(homeDAL.AddUserWiseBuyer(UserId, BuyerId), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult AddUserWiseAllBuyer(int UserId)
        {
            return Json(homeDAL.AddUserWiseAllBuyer(UserId), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult RemoveUserWiseAllBuyer(int UserId)
        {
            return Json(homeDAL.RemoveUserWiseAllBuyer(UserId), JsonRequestBehavior.AllowGet);
        }

        //////////////////////////// Courier Bulk Rate Chart Entry ///////////////////////
        
        public ActionResult CourierRateChartEntry()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddCourierRateChart(List<CourierTypeVM> CourierRates)
        {
            return Json(homeDAL.AddCourierRateChart(CourierRates, Session["SQuserId"].ToString()));
        }

        ///////////////////////// Vehicle Rate Chart Entry /////////////////////////////////

        [HttpPost]
        public ActionResult CheckIfAlreadyRateExist(RateMatrix data)
        {
            return Json(homeDAL.isVehicleRateExist(data));
        }
        
        [HttpPost]
        public ActionResult AddVehicleVendor(string name)
        {
            return Json(homeDAL.addVehicleVendor(name));
        }
        
        [HttpPost]
        public ActionResult AddVehicleType(string name, int noOfSeats)
        {
            return Json(homeDAL.addVehicleType(name, noOfSeats));
        }
        
        [HttpPost]
        public ActionResult AddVehicleRoute(string name)
        {
            return Json(homeDAL.addVehicleRoute(name));
        }

        ///////////////////////// Vehicle Admin Panel ///////////////////////

        public ActionResult VehicleAdminPanel()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BusinessUnits()
        {
            return Json(homeDAL.getBusinessUnits(), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult VehicleBusinessUnitWiseApprovers(int busninesssUnitId)
        {
            return Json(homeDAL.getBusiessUnitWiseApprover(busninesssUnitId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteBusinessUnitWiseApprover(int id)
        {
            return Json(homeDAL.DeleteBusinessUnitWiseApprover(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddVehicleApprover(int userId, string designation, string role, int approverNo, int businessUnitId)
        {
            return Json(homeDAL.addVehicleApprover(userId, designation, role, approverNo, businessUnitId));
        }

        /////////////////////// Capex Admin Panel ///////////////////////////
        public ActionResult CapexAdminPanel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CapexUserWiseBusinessUnits(int id)
        {
            return Json(homeDAL.GetCapexUserWiseBusinessUnits(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult BusinessUnitsDD()
        {
            return Json(homeDAL.GetBusinessUnitsDD(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCapexUserWiseBusienssUnit(int id)
        {
            return Json(homeDAL.DeleteCapexUserWiseBusienssUnit(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCapexUserWiseBusienssUnit(int UserId, int BusinessUnitId)
        {
            return Json(homeDAL.AddCapexUserWiseBusienssUnit(UserId, BusinessUnitId), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult CapexUserWiseLocation(int id)
        {
            return Json(homeDAL.GetCapexUserWiseLocation(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LocationsDD()
        {
            return Json(homeDAL.GetLocationsDD(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCapexUserWiseLcoation(int id)
        {
            return Json(homeDAL.DeleteCapexUserWiseLocation(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCapexUserWiseLocation(int UserId, int LocationId)
        {
            return Json(homeDAL.AddCapexUserWiseLocation(UserId, LocationId), JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult CapexUserWiseCategory(int id)
        {
            return Json(homeDAL.GetCapexUserWiseCategory(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CategoriesDD()
        {
            return Json(homeDAL.GetCategoriesDD(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCapexUserWiseCategory(int id)
        {
            return Json(homeDAL.DeleteCapexUserWiseCategory(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCapexUserWiseCategory(int UserId, int CategoryId)
        {
            return Json(homeDAL.AddCapexUserWiseCategory(UserId, CategoryId), JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult CapexAssetsDD()
        {
            return Json(homeDAL.GetAssetsDD(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CategoryWiseAssets(int id)
        {
            return Json(homeDAL.GetCategoryWiseAsset(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCategoryWiseAsset(int CatId, int AssId)
        {
            return Json(homeDAL.AddCategoryWiseAsset(CatId, AssId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCategoryWiseAsset(int id)
        {
            return Json(homeDAL.DeleteCategoryWiseAsset(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CapexBusinessUnitCategoryWiseApprovers(int buId, int catId)
        {
            return Json(homeDAL.GetCapexBusinessUnitCategoryWiseApprovers(buId, catId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCapexBusinessUnitCategoryWiseApprover(int buId, int catId, int userId, int appNo)
        {
            return Json(homeDAL.AddCapexBusinessUnitCategoryWiseApprover(buId,catId,userId,appNo), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCapexBusinessUnitCategoryWiseApprover(int id)
        {
            return Json(homeDAL.DeleteCapexBusinessUnitCategoryWiseApprover(id), JsonRequestBehavior.AllowGet);
        }

        ///////////////// ER Admin Panel ////////////////////

        public ActionResult ERAdminPanel()
        {
            return View();
        }
    }
}