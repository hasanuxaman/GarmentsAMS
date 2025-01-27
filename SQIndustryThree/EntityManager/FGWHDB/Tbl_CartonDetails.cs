namespace SQIndustryThree.EntityManager.FGWHDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_CartonDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CartonDetailsID { get; set; }

        [StringLength(50)]
        public string CartonMasterID { get; set; }

        [StringLength(50)]
        public string CartonNo { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string SizeXS { get; set; }

        [StringLength(50)]
        public string SizeS { get; set; }

        [StringLength(50)]
        public string SizeM { get; set; }

        [StringLength(50)]
        public string SizeL { get; set; }

        [StringLength(50)]
        public string SizeXL { get; set; }

        [StringLength(50)]
        public string SizeXX { get; set; }

        [StringLength(50)]
        public string SizeXXX { get; set; }

        public decimal? Quentity { get; set; }

        public decimal? Net_Weight { get; set; }

        [StringLength(50)]
        public string Gross_Weight { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }
    }
}
