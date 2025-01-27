namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_ApproverMaster
    {
        [Key]
        public int BillMasterID { get; set; }

        public int? ApproverNo { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? InvoiceType { get; set; }

        public int? SubCategoryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Updatedate { get; set; }

        public int? UserId { get; set; }

        public int? DepartmentID { get; set; }
    }
}
