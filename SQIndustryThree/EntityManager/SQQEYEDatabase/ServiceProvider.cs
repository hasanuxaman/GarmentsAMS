namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServiceProvider")]
    public partial class ServiceProvider
    {
        public int ServiceProviderId { get; set; }

        [StringLength(100)]
        public string ServiceProviderName { get; set; }
    }
}
