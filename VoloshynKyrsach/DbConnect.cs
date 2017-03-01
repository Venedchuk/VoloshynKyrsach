using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoloshynKursach
{
    public class Context : DbContext
    {
        public Context() : base("FactoryOrders")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
           // Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Factory> Factories { get; set; }

    }
}
