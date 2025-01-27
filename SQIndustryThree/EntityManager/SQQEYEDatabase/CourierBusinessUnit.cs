namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourierBusinessUnit")]
    public partial class CourierBusinessUnit
    {
        [Key]
        [Column(Order = 0)]
        public int BusinessUnitId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string BusinessUnitName { get; set; }

        public int? CompanyId { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime UpdateDate { get; set; }
    }
}
