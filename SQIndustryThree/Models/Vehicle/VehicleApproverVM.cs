using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.Vehicle
{
    public class VehicleApproverVM
    {
        public int VehicleApproverid { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Designation { get; set; }

        public string Role { get; set; }

        public int? UnitId { get; set; }

        public string UnitName { get; set; }

        public int ApproverSequence { get; set; }
    }
}