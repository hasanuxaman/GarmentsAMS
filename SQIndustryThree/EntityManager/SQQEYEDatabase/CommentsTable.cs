namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CommentsTable")]
    public partial class CommentsTable
    {
        [Key]
        [Column(Order = 0)]
        public int QueryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CapexInfoId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReviewerBy { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReviewerTo { get; set; }

        public string ReviewMessage { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime CreateBy { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime UpdatedBY { get; set; }
    }
}
