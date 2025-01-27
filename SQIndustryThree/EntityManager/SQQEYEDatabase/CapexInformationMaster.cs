namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CapexInformationMaster")]
    public partial class CapexInformationMaster
    {
        [Key]
        [Column(Order = 0)]
        public int CapexInfoId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CapexName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessUnitId { get; set; }

        [Key]
        [Column(Order = 3)]
        public string CapexAssetType { get; set; }

        [Key]
        [Column(Order = 4)]
        public string CapexDescription { get; set; }

        public DateTime? CapexCreateDate { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsApproved { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CapexCatagoryID { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "date")]
        public DateTime UpdateDate { get; set; }

        public int? Revision { get; set; }

        public int? Currency { get; set; }

        public int? LocationId { get; set; }
    }
}
