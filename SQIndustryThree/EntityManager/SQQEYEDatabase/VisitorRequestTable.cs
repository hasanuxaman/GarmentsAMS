namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorRequestTable")]
    public partial class VisitorRequestTable
    {
        [Key]
        public int RequestorId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? LocationId { get; set; }

        public string RequestorName { get; set; }

        public string RequestorEmail { get; set; }

        public string RequerstorMobile { get; set; }

        public string RequestorDesignation { get; set; }

        public string RequestorDepartment { get; set; }

        public string VisitorName { get; set; }

        public string VisitorEmail { get; set; }

        public string VisitorMobile { get; set; }

        public string VisitorCompany { get; set; }

        public string VisitorNationality { get; set; }

        public string PurposeOfVisitSQ { get; set; }

        public string Chainavisit { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CraeteDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? IsApproved { get; set; }

        public string VisitorDesignation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VisitDate { get; set; }
    }
}
