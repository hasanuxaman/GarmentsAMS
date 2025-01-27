using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models
{
    public class QMSUserCreate
    {
        public int QmsUserId { get; set; }
        public int BusinessUnitId { get; set; }
        public int ProductionUnitId { get; set; }
        public int ModuleId { get; set; }
        public int LineId { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public List<QMSUserCreate> QMSUserCreateDetails { get; set; }
        

    }
}