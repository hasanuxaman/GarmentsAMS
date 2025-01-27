namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleDeligation")]
    public partial class VehicleDeligation
    {
        public int VehicleDeligationId { get; set; }

        public int? UserId { get; set; }

        public int? AssignUserId { get; set; }
    }
}
