using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class UserInformation
    {
        public int UserInformationId { get; set; }
        public string UserInformationName { get; set; }
        public string UserInformationEmail { get; set; }
        public string UserInformationPassword { get; set; }
        public string UserInformationPhoneNumber { get; set; }
        public string UserSQNumber { get; set; }
        public int UserTypeId { get; set; }
        public int BusinessUnitId { get; set; }
        public int CreateBY { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public int ApproverNo { get; set; }
        public String DesignationName { get; set; }
        public String DepartmentName { get; set; }
        public int SectionId { get; set; }
        public String SectionName { get; set; }
        public int SubSectionId { get; set; }
        public String SubSectionName { get; set; }
        public int CategoryId { get; set; }
        public String CategoryName { get; set; }
        public int UnitId { get; set; }
        public String UnitName { get; set; }
        public int IsSupplier { get; set; }
        public bool Empty
        {
            get
            {
                return (UserInformationId == 0 &&
                        string.IsNullOrWhiteSpace(UserInformationName) &&
                        string.IsNullOrWhiteSpace(UserInformationEmail));
            }
        }
    }
}