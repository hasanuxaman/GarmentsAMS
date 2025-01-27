namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurposeofVisit")]
    public partial class PurposeofVisit
    {
        [Key]
        [Column(Order = 0)]
        public int PurposeofVisitId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string PurposeofTravelName { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
