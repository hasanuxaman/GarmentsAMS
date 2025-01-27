namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierUserWiseCustomerPermission")]
    public partial class CourierUserWiseCustomerPermission
    {
        [Key]
        public int UserCustomerId { get; set; }

        public int? UserId { get; set; }

        public int? BuyerId { get; set; }

        public int? Active { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? UpdateDate { get; set; }
    }
}
