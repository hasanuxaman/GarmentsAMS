namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationWisePurposeofVisit")]
    public partial class LocationWisePurposeofVisit
    {
        [Key]
        public int LcWPurposeofVisitId { get; set; }

        public string PurposeofTravelName { get; set; }

        public int? PurposeofVisitId { get; set; }

        public int? LocationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
