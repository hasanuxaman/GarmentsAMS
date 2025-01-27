namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExceptionRequestDetail
    {
        [Key]
        public int ExceptionRequestDetailstId { get; set; }

        public int? ExpReqsMastertId { get; set; }

        public string PositionCode { get; set; }

        public int? Department { get; set; }

        public int? Designation { get; set; }

        public int? StaffCategory { get; set; }

        public int? Current_Bdg_Man { get; set; }

        public int? No_Of_Add_Req { get; set; }

        public int? To_Bdg_Man { get; set; }

        public string Remarks { get; set; }
    }
}
