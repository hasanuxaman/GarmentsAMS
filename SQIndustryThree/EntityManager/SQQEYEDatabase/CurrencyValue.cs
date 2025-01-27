namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrencyValue")]
    public partial class CurrencyValue
    {
        [Key]
        public int CurrencyId { get; set; }

        [Required]
        public string CurrencyName { get; set; }

        public double? ConverterValue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? UpdateDate { get; set; }
    }
}
