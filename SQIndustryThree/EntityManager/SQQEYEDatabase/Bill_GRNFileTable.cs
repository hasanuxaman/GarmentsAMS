namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_GRNFileTable
    {
        [Key]
        public int BillGRNFileId { get; set; }

        public string BillGRNFileName { get; set; }

        public int? BillInvoiceKey { get; set; }

        public string BillGRNFilePath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
