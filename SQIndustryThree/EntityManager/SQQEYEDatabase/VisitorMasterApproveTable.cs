namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorMasterApproveTable")]
    public partial class VisitorMasterApproveTable
    {
        [Key]
        public int VisitorMasterId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? LocationId { get; set; }

        public int? UserId { get; set; }

        public int? ApproverNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? FrontDesk { get; set; }
    }
}
