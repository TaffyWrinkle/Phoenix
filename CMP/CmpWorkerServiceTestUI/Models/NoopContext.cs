using System.Data.Entity;
using CmpWorkerServiceTestUI.Models.Mapping;

namespace CmpWorkerServiceTestUI.Models
{
    public partial class NoopContext : DbContext
    {
        static NoopContext()
        {
            Database.SetInitializer<NoopContext>(null);
        }

        public NoopContext()
            : base("Name=NoopContext")
        {
        }

        public DbSet<Nodat> Nodats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NodatMap());
        }
    }
}
