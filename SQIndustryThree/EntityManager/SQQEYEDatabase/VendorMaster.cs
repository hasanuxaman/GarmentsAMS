namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorMaster")]
    public partial class VendorMaster
    {
        [Key]
        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string VendorAddress { get; set; }

        public string PhoneNo { get; set; }

        public string ContactPerson { get; set; }
    }
}
