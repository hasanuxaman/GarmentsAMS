using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class ExceptionRequestHRMaster
    {
        public int ExpReqMastertId { get; set; }
        public int ExpTypeId { get; set; }
        public string ExceptionTypeName { get; set; }
        public int ExpReasonId { get; set; }
        public string ExceptionReasonName { get; set; }
        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Month { get; set; }
        public string Comment { get; set; }
        public string CreateDate { get; set; }
        public int IsApproved { get; set; }
        public string UpdateDate { get; set; }
        public int? RivisionNo { get; set; }
        public int? NoApprover { get; set; }
        public string RequestBy { get; set; }
        public int RequestorId { get; set; }
        public string UserName { get; set; }
        public int ExceptionRequestDetailstId { get; set; }
        public string PositionCode { get; set; }
        public int Department { get; set; }
        public string DepartmentName { get; set; }
        public int Designation { get; set; }
        public string DesignationName { get; set; }
        public int StaffCategory { get; set; }
        public string StaffCategoryName { get; set; }
        public int Current_Bdg_Man { get; set; }
        public int No_Of_Add_Req { get; set; }
        public int To_Bdg_MAn { get; set; }
        public string Remarks { get; set; }
        public string DateOfRequest { get; set; }
        public int Pending { get; set; }
        public int Status { get; set; }
        public List<ExceptionRequestHRMaster> ExceptionDetailsList { get; set; }
        public List<ExceptionRequestHRDetailsExtend> ExceptionDetailsExtendList { get; set; }
        public List<CourierApproverModel> ApproverList { get; set; }
        public List<CommentsTable> ExceptionComments { get; set; }
        public List<LogSection> ExceptionLogSection { get; set; }
    }
}