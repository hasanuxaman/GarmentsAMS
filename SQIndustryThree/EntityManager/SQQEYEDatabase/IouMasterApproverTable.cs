namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IouMasterApproverTable")]
    public partial class IouMasterApproverTable
    {
        [Key]
        public int IouApproverId { get; set; }

        public int? UserId { get; set; }

        public int? BusinessUnitID { get; set; }

        public int? DepartmentId { get; set; }

        public int? MinimumValue { get; set; }

        public int? MaximumValue { get; set; }

        public int? ApproverNo { get; set; }

        public int? IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }

        public int? ApproverStatus { get; set; }

        public int? LocationID { get; set; }

        public int? Settlement { get; set; }
    }
}
