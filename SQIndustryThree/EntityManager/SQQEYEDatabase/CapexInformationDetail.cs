namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CapexInformationDetail
    {
        [Key]
        [Column(Order = 0)]
        public int CapexInfoDetailsId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CapexAssetCatagory { get; set; }

        [Key]
        [Column(Order = 2)]
        public string CapexAssetDescription { get; set; }

        [Key]
        [Column(Order = 3)]
        public double CapexDetailsQty { get; set; }

        [Key]
        [Column(Order = 4)]
        public double CapexUnitPrice { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal CapexEstimatedCost { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CapexInfoId { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "date")]
        public DateTime UpdateDate { get; set; }
    }
}
