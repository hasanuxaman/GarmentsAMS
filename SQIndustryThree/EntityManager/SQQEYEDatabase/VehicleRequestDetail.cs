namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleRequestDetail
    {
        [Key]
        public int VehicleRequestDetailstId { get; set; }

        public int? VehicleRequesMastertId { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int? Designation { get; set; }

        public int? Department { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }
    }
}
