namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleApproverMaster")]
    public partial class VehicleApproverMaster
    {
        [Key]
        public int VehicleMasterID { get; set; }

        public int? UnitId { get; set; }

        [StringLength(10)]
        public string COOId { get; set; }

        public int? StationManagerId { get; set; }

        public int? ApproverNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Updatedate { get; set; }
    }
}
