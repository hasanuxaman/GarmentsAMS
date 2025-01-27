namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_POMaster
    {
        [Key]
        public long POKey { get; set; }

        public int? PONo { get; set; }

        [StringLength(200)]
        public string Supplier { get; set; }

        public int? CurrencyID { get; set; }

        public int? TotalQty { get; set; }

        public decimal? TotalValue { get; set; }

        public DateTime? POCreationDate { get; set; }

        public DateTime? POApprovedDate { get; set; }

        [StringLength(200)]
        public string Status { get; set; }

        public DateTime? UploadDate { get; set; }

        public int? UploadBy { get; set; }
    }
}
