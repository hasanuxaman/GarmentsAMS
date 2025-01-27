namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CapexCatagory")]
    public partial class CapexCatagory
    {
        [Key]
        [Column(Order = 0)]
        public int CapexCatagoryID { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CapexCatagoryName { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime UpdateDate { get; set; }
    }
}
