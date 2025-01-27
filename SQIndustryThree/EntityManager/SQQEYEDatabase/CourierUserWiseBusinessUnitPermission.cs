namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierUserWiseBusinessUnitPermission")]
    public partial class CourierUserWiseBusinessUnitPermission
    {
        [Key]
        public int UserBusinessUnit { get; set; }

        public int? UserId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? Active { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? UpdateDate { get; set; }
    }
}
