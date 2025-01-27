using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class PositionCodeDetails
    {
        public int PWManpowerId { get; set; }
        public int BusinessUnitId { get; set; }
        public string PositionName { get; set; }
        public int DepartmentId { get; set; }
        public int StaffCategoryId { get; set; }
        public int DesignationId { get; set; }
        public string Month { get; set; }
        public string BudgetedHead { get; set; }
        public string StaffCategoryName { get; set; }
        public string DesignationName { get; set; }
        public string DepartmentName { get; set; }

        public List<CommonModel> commonModelList { get; set; }
    }
}