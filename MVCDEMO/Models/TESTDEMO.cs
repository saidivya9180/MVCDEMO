namespace MVCDEMO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TESTDEMOContext : DbContext
    {
        public TESTDEMOContext()
            : base("name=TESTDEMO")
        {
        }

        public  DbSet<EntityInventory> EntityInventories { get; set; }
        public  DbSet<Facility> Facilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
               
        }
    }
}
