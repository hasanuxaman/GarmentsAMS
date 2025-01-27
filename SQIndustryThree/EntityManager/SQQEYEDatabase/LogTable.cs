namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LogTable")]
    public partial class LogTable
    {
        [Key]
        [Column(Order = 0)]
        public int LogNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CapexNo { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Status { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string Comments { get; set; }
    }
}
