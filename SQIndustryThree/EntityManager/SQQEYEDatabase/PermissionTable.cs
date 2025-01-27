namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermissionTable")]
    public partial class PermissionTable
    {
        [Key]
        public int PermissionKey { get; set; }

        public int UserId { get; set; }

        public int ModuleKey { get; set; }

        public int Permission { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PermissionCreate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PermissionUpdate { get; set; }
    }
}
