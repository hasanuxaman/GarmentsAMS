using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SQInventory.Models.FGWH
{
    public class ModelCartonDetail
    {
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int CartonDetailsID { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int CartonID { get; set; }

            [StringLength(250)]
            public string CartonNo { get; set; }

            [StringLength(250)]
            public string Color { get; set; }

            [StringLength(250)]
            public string SizeXS { get; set; }

            [StringLength(250)]
            public string SizeS { get; set; }

            [StringLength(250)]
            public string SizeM { get; set; }

            [StringLength(250)]
            public string SizeL { get; set; }

            [StringLength(250)]
            public string SizeXL { get; set; }

            [StringLength(250)]
            public string SizeXX { get; set; }

            [StringLength(250)]
            public string SizeXXX { get; set; }

            public double? Quentity { get; set; }

            public double? NET_WEIGHT { get; set; }

            public double? GROSS_WEIGHT { get; set; }
        
    }
}