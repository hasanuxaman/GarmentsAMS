namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorDetailsTable")]
    public partial class VisitorDetailsTable
    {
        [Key]
        public int VisitorId { get; set; }

        public int? RequestorId { get; set; }

        [StringLength(50)]
        public string SQID { get; set; }

        public int? SQUnitId { get; set; }

        public string SQDepartmentId { get; set; }

        public string VisitorName { get; set; }

        public string VisitorEmail { get; set; }

        public string VisitorMobile { get; set; }

        public string VisitorDesignation { get; set; }

        public string VisitorCompany { get; set; }

        public string VisitorNationality { get; set; }

        public string VisitorCardNo { get; set; }

        public string VisitorVehicleNo { get; set; }

        [StringLength(20)]
        public string NIDorPassport { get; set; }

        public string Image { get; set; }

        public string ImagePath { get; set; }

        public string Chainavisit { get; set; }

        public DateTime? CraeteDate { get; set; }

        public string PurposeOfVisitSQ { get; set; }

        public string MeetingWith { get; set; }

        public string Remarks { get; set; }

        public string GateRemarks { get; set; }

        public int? Approved { get; set; }

        [StringLength(50)]
        public string CheckIn { get; set; }

        public DateTime? InTime { get; set; }

        [StringLength(50)]
        public string CheckOut { get; set; }

        public DateTime? OutTime { get; set; }

        public DateTime? ApprovedTime { get; set; }

        public string ApproverRemarks { get; set; }

        public int? FrontDeskId { get; set; }
    }
}
