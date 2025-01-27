namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionGenaralInformation")]
    public partial class ExceptionGenaralInformation
    {
        [Key]
        public int ExceptionGenralId { get; set; }

        public int? ExceptionMasterId { get; set; }

        public string StyleNo { get; set; }

        public string Color { get; set; }

        public string PO { get; set; }

        public string FOB { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public double? Quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OriginalDD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RevisedDD { get; set; }

        public double? Discount { get; set; }

        public double? Claim { get; set; }

        public double? MaterialLiability { get; set; }

        public double? GarmentsLiability { get; set; }
    }
}
