namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationWiseStartPoint")]
    public partial class LocationWiseStartPoint
    {
        [Key]
        public int LWStartPointId { get; set; }

        public string StartPointName { get; set; }

        public int? StartingPointId { get; set; }

        public int? LocationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
