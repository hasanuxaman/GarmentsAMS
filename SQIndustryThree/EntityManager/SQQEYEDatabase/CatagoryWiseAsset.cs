namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CatagoryWiseAsset")]
    public partial class CatagoryWiseAsset
    {
        [Key]
        public int CataWiseAssetId { get; set; }

        public int? AssetCatagoryId { get; set; }

        public int? CatagoryId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? UpdateDate { get; set; }
    }
}
