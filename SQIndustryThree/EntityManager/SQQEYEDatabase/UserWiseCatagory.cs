namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserWiseCatagory")]
    public partial class UserWiseCatagory
    {
        [Key]
        public int UserCatId { get; set; }

        public int? UserId { get; set; }

        public int? CatagoryId { get; set; }

        public int? IsActive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
