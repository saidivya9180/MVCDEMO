namespace MVCDEMO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EntityInventory")]
    public partial class EntityInventory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntityInventory()
        {
            Facilities = new HashSet<Facility>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntityId { get; set; }

        [StringLength(50)]
        public string EntityName { get; set; }

        public int? EmissionYear { get; set; }

        //public virtual EntityInventory EntityInventory1 { get; set; }

        //public virtual EntityInventory EntityInventory2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facility> Facilities { get; set; }
    }
}
