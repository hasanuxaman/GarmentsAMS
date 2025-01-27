namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RateMatrix")]
    public partial class RateMatrix
    {
        public int RateMatrixId { get; set; }

        public int? VendorId { get; set; }

        public int? VehicleTypeId { get; set; }

        public int? RouteId { get; set; }

        public int? TripTypeId { get; set; }

        public decimal? Rate { get; set; }
    }
}
