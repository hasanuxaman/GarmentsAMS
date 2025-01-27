namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_InvoiceType
    {
        [Key]
        public int InvoiceTypeID { get; set; }

        [StringLength(100)]
        public string InvoiceType { get; set; }

        public bool? IsActive { get; set; }
    }
}
