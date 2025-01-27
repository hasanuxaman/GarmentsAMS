namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorApproverTable")]
    public partial class VisitorApproverTable
    {
        [Key]
        public int VisitorApproverId { get; set; }

        public int? VisitorRequestId { get; set; }

        public int? ApproverId { get; set; }

        public int? ApproverNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? IsApproved { get; set; }
    }
}
