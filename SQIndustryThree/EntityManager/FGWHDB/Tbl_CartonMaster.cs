namespace SQIndustryThree.EntityManager.FGWHDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_CartonMaster
    {
        [Key]
        public int CartonMasterID { get; set; }

        [StringLength(50)]
        public string BuyerID { get; set; }

        [StringLength(50)]
        public string BusinessUnitID { get; set; }

        [StringLength(50)]
        public string PO { get; set; }

        [StringLength(50)]
        public string Style { get; set; }

        public decimal? Order_Quty { get; set; }

        public decimal? WinShip_Quty { get; set; }

        [StringLength(50)]
        public string Pluse { get; set; }

        [StringLength(50)]
        public string Persentes { get; set; }

        public decimal? Total_Carton { get; set; }

        [StringLength(50)]
        public string Dstination { get; set; }

        [StringLength(50)]
        public string Solid_Colour { get; set; }

        [StringLength(50)]
        public string Solid_Size { get; set; }

        [StringLength(50)]
        public string CartonMeasurement { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }
    }
}
