namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_Quality
    {
        [Key]
        public int QualityID { get; set; }

        [StringLength(100)]
        public string QualityParam { get; set; }

        public int? QualityResultID { get; set; }

        public string QualityComment { get; set; }

        [StringLength(100)]
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public int? InvoiceKey { get; set; }

        [StringLength(100)]
        public string InvoiceNo { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? Rate { get; set; }

        [StringLength(100)]
        public string RateName { get; set; }

        public int? UpdatedBy { get; set; }

        [StringLength(100)]
        public string UpdatedDate { get; set; }
    }
}
