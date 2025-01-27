namespace SQIndustryThree.EntityManager.SQQEYEDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VisitorCategory")]
    public partial class VisitorCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VisitorCategory()
        {
            VisitorSubCategories = new HashSet<VisitorSubCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryID { get; set; }

        [StringLength(200)]
        public string CategoryName { get; set; }

        public int? Status { get; set; }

        public int? Created_By { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Created_At { get; set; }

        public int? Updated_By { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Updated_At { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitorSubCategory> VisitorSubCategories { get; set; }
    }
}
