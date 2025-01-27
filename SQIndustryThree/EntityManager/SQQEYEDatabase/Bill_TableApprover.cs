namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_TableApprover
    {
        [Key]
        public int BillApproverId { get; set; }

        public int? InvoiceKey { get; set; }

        public int? UserId { get; set; }

        public int? ApproverNo { get; set; }

        public int? IsApproved { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string ReviewComment { get; set; }

        public int? ApproverStatus { get; set; }

        public int? QualityRate { get; set; }

        [StringLength(50)]
        public string QualityRateName { get; set; }

        public int? CertifyingCompleted { get; set; }

        public double? CompletionPercent { get; set; }

        public string CompletionRemarks { get; set; }
    }
}
