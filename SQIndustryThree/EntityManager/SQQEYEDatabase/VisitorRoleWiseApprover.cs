namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorRoleWiseApprover")]
    public partial class VisitorRoleWiseApprover
    {
        [Key]
        public int rwaid { get; set; }

        public int? UserId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string UserEmail { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        [StringLength(100)]
        public string Role { get; set; }

        public int? UnitId { get; set; }

        [StringLength(100)]
        public string UnitName { get; set; }

        public byte? ApproverSequence { get; set; }
    }
}
