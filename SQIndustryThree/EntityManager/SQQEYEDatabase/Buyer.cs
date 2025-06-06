namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Buyer
    {
        public int BuyerId { get; set; }

        public string BuyerName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? UnitId { get; set; }
    }
}
