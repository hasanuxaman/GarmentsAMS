namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RouteMaster")]
    public partial class RouteMaster
    {
        [Key]
        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }
    }
}
