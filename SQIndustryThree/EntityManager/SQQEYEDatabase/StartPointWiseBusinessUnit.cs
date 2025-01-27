namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StartPointWiseBusinessUnit")]
    public partial class StartPointWiseBusinessUnit
    {
        [Key]
        public int SWBusinessUnitId { get; set; }

        public string BusinessUnitName { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? StartingPointId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
