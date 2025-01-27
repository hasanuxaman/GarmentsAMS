namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_ChequeInfo
    {
        [Key]
        public int ChequeInfoId { get; set; }

        public int? InvoiceKey { get; set; }

        [StringLength(50)]
        public string ChequeNo { get; set; }

        public decimal? Amount { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Date { get; set; }

        public int? Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
