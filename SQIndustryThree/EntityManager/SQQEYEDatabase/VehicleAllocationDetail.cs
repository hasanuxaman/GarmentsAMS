namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleAllocationDetail
    {
        [Key]
        public int VehicleAllocationDetailsId { get; set; }

        public int? VehicleAllocationMasterId { get; set; }

        public int? VehicleRequestMasterId { get; set; }

        public decimal? AllocatedCost { get; set; }
    }
}
