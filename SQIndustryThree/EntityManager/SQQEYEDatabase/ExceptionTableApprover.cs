namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionTableApprover")]
    public partial class ExceptionTableApprover
    {
        [Key]
        public int ExceptionApproverId { get; set; }

        public int? ExceptionMasterId { get; set; }

        public int? UserId { get; set; }

        public int? ApproverNo { get; set; }

        public int? IsApproved { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string ReviewComment { get; set; }
    }
}
