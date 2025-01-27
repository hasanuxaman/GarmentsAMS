namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorSubCategory")]
    public partial class VisitorSubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubCategoryID { get; set; }

        [StringLength(200)]
        public string SubCategoryName { get; set; }

        public int? CategoryID { get; set; }

        public int? Status { get; set; }

        public int? Created_By { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Created_At { get; set; }

        public int? Updated_By { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Updated_At { get; set; }

        public virtual VisitorCategory VisitorCategory { get; set; }
    }
}
