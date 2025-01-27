namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_FileTable
    {
        [Key]
        public int BillFileId { get; set; }

        public string BillFileName { get; set; }

        public int? BillInvoiceKey { get; set; }

        public string BillFilePath { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? CreatedBy { get; set; }
    }
}
