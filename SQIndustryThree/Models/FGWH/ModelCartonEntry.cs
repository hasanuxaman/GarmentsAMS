using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SQInventory.Models.FGWH
{
    public class ModelCartonEntry
    {
       
            [Key]
            public int CartonID { get; set; }

            [StringLength(250)]
            public string CartonNo { get; set; }

            [StringLength(250)]
            public string BuyerID { get; set; }

            [StringLength(50)]
            public string BusinessUnitID { get; set; }

            [StringLength(250)]
            public string PO { get; set; }

            [StringLength(250)]
            public string Style { get; set; }

            [StringLength(250)]
            public string ORDER_QTY { get; set; }

            public double? WinShip_Quty { get; set; }

            [StringLength(250)]
            public string PLUSE { get; set; }

            [StringLength(250)]
            public string PERCENTAGE { get; set; }

            public double? TOTAL_CTN { get; set; }

            [StringLength(250)]
            public string DESTIN { get; set; }

            [StringLength(250)]
            public string Solid_ColourORSolid_Size { get; set; }

            [StringLength(250)]
            public string CartonMeasurement { get; set; }

            public DateTime? CreateDate { get; set; }

            [StringLength(250)]
            public string CreateBy { get; set; }

            public DateTime? UpdateDate { get; set; }

            [StringLength(250)]
            public string UpdateBy { get; set; }
            public List<ModelCartonDetail> CartonDetailsList { get; set; }
        
    }
}