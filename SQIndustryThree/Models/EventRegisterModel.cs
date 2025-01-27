using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class EventRegisterModel
    {
        public int RegisterID { get; set; }
      
        public string GeneratedID { get; set; }
        public int EventID { get; set; }
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string EmployeeID { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public int BusinessUnitID { get; set; }
        public int EventMemberDetailstId { get; set; }
        public int EventItemDetailstId { get; set; }
        public string ItemName { get; set; }
        public int UnitPrice { get; set; }
        public string Allergens { get; set; }
        public string RouteTypeName { get; set; }
        public string PurposeofTravel { get; set; }
        public string PurposeofTravelName { get; set; }
        public string TripType { get; set; }
        public string TripTypeName { get; set; }
        public string PreferredVehicle { get; set; }
        public string PreferredVehicleName { get; set; }
        public int NoofUser { get; set; }
        public int NoofDays { get; set; }
        public string Remarks { get; set; }
        public int VehicleRequestDetailstId { get; set; }
        public string UserId { get; set; }
       
        public string DesignationName { get; set; }
  
        public string DepartmentName { get; set; }
        public string MemberUserName { get; set; }
        public string PhoneNo { get; set; }
        public string MemberEmail { get; set; }
        public int IsApproved { get; set; }
         public int Pending { get; set; }
        public string CreateDate { get; set; }
        public string RequestorName { get; set; }

        public string RequestorEmail { get; set; }

        public string RequerstorMobile { get; set; }

        public string RequestorDesignation { get; set; }

        public string RequestorDepartment { get; set; }
        public int Created_By { get; set; }
        public int DepartmentID { get; set; }
        public string BudgetYear { get; set; }
        public string MonthOfYear { get; set; }
        public string InialAmount { get; set; }
        public string Amount { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Budget_MTD { get; set; }
        public string MTDcost { get; set; }
        public string ReaminsCost { get; set; }
        public string Central_Budget_MTD { get; set; }
        public string Central_MTDcost { get; set; }
        public string Central_ReaminsCost { get; set; }
        public string VehicleRate { get; set; }
        public int VehicleBudgetEntryId { get; set; }
        public string AllocatedCost { get; set; }
        public List<CapexFileUploadDetails> IOurequestfiles { get; set; }
        public List<CapexFileUploadDetails> IouSettlementFiles { get; set; }
        public List<CourierApproverModel> VehicleApproverList { get; set; }
        public List<EventRegisterModel>MemberDetailsList { get; set; }
        public List<EventRegisterModel> ItemDetailsList { get; set; }
        public List<CommentsTable> VehicleComments { get; set; }
        public List<LogSection> VehicleLogSection { get; set; }


    }
}