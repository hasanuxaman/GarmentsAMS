namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_AllocationMaster
    {
        [Key]
        public int BillAllocationMasterId { get; set; }

        public long? PaymentTransactionNo { get; set; }

        public int? PaymentModeId { get; set; }

        [StringLength(50)]
        public string PaymentModeType { get; set; }

        [StringLength(50)]
        public string ChequeOrTTNo { get; set; }

        public decimal? ChequeOrTTAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ChequeOrTTDate { get; set; }

        public int? SupplierId { get; set; }

        public string TdsReference { get; set; }

        public decimal? TdsAmount { get; set; }

        public decimal? NetPay { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
