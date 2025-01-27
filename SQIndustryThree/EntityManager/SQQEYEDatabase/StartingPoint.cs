namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StartingPoint")]
    public partial class StartingPoint
    {
        [Key]
        [Column(Order = 0)]
        public int StartingPointId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string StartingPointName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
