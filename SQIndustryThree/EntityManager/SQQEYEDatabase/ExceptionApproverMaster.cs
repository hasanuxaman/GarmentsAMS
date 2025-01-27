namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionApproverMaster")]
    public partial class ExceptionApproverMaster
    {
        [Key]
        public int ExceptionMasterID { get; set; }

        public int? UnitId { get; set; }

        [StringLength(10)]
        public string BuyeId { get; set; }

        public int? ApproverNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Updatedate { get; set; }

        public int? UserId { get; set; }

        public int? SupplyID { get; set; }
    }
}
