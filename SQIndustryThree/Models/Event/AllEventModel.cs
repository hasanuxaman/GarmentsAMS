using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQIndustryThree.Models.Event
{
    public class AllEventModel
    {
        //      r.RegisterID, r.GeneratedID, e.EventName, l.LocationName, r.Name, 
        //r.EmployeeID, r.Designation, r.Department, CASE
        //              WHEN r.BusinessUnitId = 0 THEN 'Central'
        //		ELSE b.BusinessUnitName

        //              END AS BusinessUnitName

        public int RegisterID { get; set; }
        public string GeneratedID { get; set; }
        public string EventName { get; set; }
        public string LocationName { get; set; }
        public string Name { get; set; }
        public string EmployeeID { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string BusinessUnitName { get; set; }
    }
}