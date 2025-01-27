namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StartPointWiseRoute")]
    public partial class StartPointWiseRoute
    {
        [Key]
        public int SWRouteId { get; set; }

        public string RouteName { get; set; }

        public int? StartPointId { get; set; }

        public int? RouteId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
