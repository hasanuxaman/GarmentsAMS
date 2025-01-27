namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_AllocationDetails
    {
        [Key]
        public int BillAllocationDetailsId { get; set; }

        public int? BillAllocationMasterId { get; set; }

        public long? PaymentTransactionNo { get; set; }

        public int? InvoiceKey { get; set; }

        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? InvoiceDate { get; set; }

        [StringLength(100)]
        public string PO { get; set; }

        public decimal? BillAmount { get; set; }

        public decimal? Paid { get; set; }

        public decimal? BalanceAmount { get; set; }
    }
}
