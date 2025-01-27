namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleAllocationMaster")]
    public partial class VehicleAllocationMaster
    {
        public int VehicleAllocationMasterId { get; set; }

        public string VehicleNo { get; set; }

        public string DriverName { get; set; }

        public string DriverPhone { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? StartPointId { get; set; }

        public int? TripTypeId { get; set; }

        public int? RouteId { get; set; }

        public int? TripCost { get; set; }

        public int? TransactionBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransactionDate { get; set; }
    }
}
