namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminUser")]
    public partial class AdminUser
    {
        [Key]
        [Column(Order = 0)]
        public int AdminId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string AdminName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string AdminMail { get; set; }

        [Key]
        [Column(Order = 3)]
        public string AdminPassword { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
