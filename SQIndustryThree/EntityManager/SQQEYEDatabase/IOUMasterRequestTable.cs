namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IOUMasterRequestTable")]
    public partial class IOUMasterRequestTable
    {
        [Key]
        public int IOURequestId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfRequest { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RequiredDate { get; set; }

        public int? LocationId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? Ammount { get; set; }

        public string Purpose { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SettlementDate { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? IsApproved { get; set; }

        public int? IsSettled { get; set; }

        public int? IouCatagoryId { get; set; }

        public int? DepartmentId { get; set; }

        public int? RevisionNo { get; set; }

        public int? TotalDisburseAmmount { get; set; }

        public int? TotalExpenceAmmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SettlementCreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SettlementUpdateDate { get; set; }

        public string RemarksSettlement { get; set; }

        public int? IsSettleApprove { get; set; }
    }
}
