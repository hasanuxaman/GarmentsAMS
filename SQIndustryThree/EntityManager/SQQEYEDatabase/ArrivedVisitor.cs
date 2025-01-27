namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArrivedVisitor")]
    public partial class ArrivedVisitor
    {
        public int ArrivedVisitorId { get; set; }

        public int? RequestorId { get; set; }

        public int? VisitorId { get; set; }

        public int? RowId { get; set; }

        [StringLength(50)]
        public string VisitorCardNo { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        [StringLength(50)]
        public string VehicleNo { get; set; }

        [StringLength(5)]
        public string CheckIn { get; set; }

        public DateTime? InTime { get; set; }

        [StringLength(5)]
        public string CheckOut { get; set; }

        public DateTime? OutTime { get; set; }

        public string Remarks { get; set; }
    }
}
