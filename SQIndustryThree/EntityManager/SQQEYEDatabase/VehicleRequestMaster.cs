namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VehicleRequestMaster")]
    public partial class VehicleRequestMaster
    {
        [Key]
        public int VehicleRequesMastertId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfRequest { get; set; }

        public int? RequestorId { get; set; }

        public int? LocationId { get; set; }

        public int? BusinessUnitId { get; set; }

        public int? DepartmentHeadId { get; set; }

        public DateTime? TravelStratDate { get; set; }

        public DateTime? TravelEndDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public string StartingPoint { get; set; }

        public string RouteType { get; set; }

        public string PurposeofTravel { get; set; }

        public string TripType { get; set; }

        public string PreferredVehicle { get; set; }

        public int? NoofUser { get; set; }

        public int? NoofDays { get; set; }

        public string Remarks { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? IsApproved { get; set; }

        public int? ApproverStatus { get; set; }

        public int? DeligationUserId { get; set; }

        public string Destination { get; set; }
    }
}
