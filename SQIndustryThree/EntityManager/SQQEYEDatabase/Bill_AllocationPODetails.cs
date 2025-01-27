namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_AllocationPODetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AllocationPOID { get; set; }

        public int? SupplierId { get; set; }

        public int? InvoiceKey { get; set; }

        [StringLength(100)]
        public string InvoiceNo { get; set; }

        public int? PONo { get; set; }

        public decimal? POQty { get; set; }

        public decimal? POValue { get; set; }

        public decimal? ApprovedValue { get; set; }

        public decimal? PaidAmount { get; set; }

        public decimal? OutstandingAmount { get; set; }

        public decimal? PaymentValue { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
