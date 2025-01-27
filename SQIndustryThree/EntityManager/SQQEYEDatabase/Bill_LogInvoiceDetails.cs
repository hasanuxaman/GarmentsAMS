namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_LogInvoiceDetails
    {
        [Key]
        public int LogInvoiceDetails { get; set; }

        public int? InvoiceKey { get; set; }

        public int? PONo { get; set; }

        [StringLength(200)]
        public string Article { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        public int? Unit { get; set; }

        public int? Revision { get; set; }

        public decimal? InitialQty { get; set; }

        public decimal? InvoiceQty { get; set; }

        public decimal? CheckedQty { get; set; }

        public decimal? InvoiceValue { get; set; }

        public decimal? CheckedValue { get; set; }

        public decimal? Rate { get; set; }

        public decimal? Discount { get; set; }

        public decimal? PaidValue { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
