namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill_PODetailsTemp
    {
        [Key]
        public long PODetailsKey { get; set; }

        public long? POKey { get; set; }

        public int? PONo { get; set; }

        public string Article { get; set; }

        [StringLength(50)]
        public string ArticleCode { get; set; }

        public string Currency { get; set; }

        [StringLength(200)]
        public string Color { get; set; }

        [StringLength(200)]
        public string Size { get; set; }

        [StringLength(50)]
        public string UOM { get; set; }

        public decimal? POQty { get; set; }

        public decimal? Rate { get; set; }

        public decimal? POValue { get; set; }

        public decimal? UptodatePIQty { get; set; }

        public decimal? BalancePIQty { get; set; }

        public decimal? CheckedQty { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
