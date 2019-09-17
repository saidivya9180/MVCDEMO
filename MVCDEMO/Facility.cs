namespace MVCDEMO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Facility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FacilityID { get; set; }

        public int? EntityID { get; set; }

        [Required]
        [StringLength(50)]
        public string FacilityName { get; set; }

        public int? EmissionYear { get; set; }

        public virtual EntityInventory EntityInventory { get; set; }
    }
}
