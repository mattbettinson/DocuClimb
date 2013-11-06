using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain.Data
{
    public class DocuClimbDbContext: DbContext
    {

        public DocuClimbDbContext()
            : base("DocuClimb")
        {
            Database.SetInitializer<DocuClimbDbContext>(new DropCreateDatabaseAlways<DocuClimbDbContext>());
            // TODO custom initalizer to drop create and seed?  http://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx
        }

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<Climb> Climbs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competition>().HasMany<Round>(c => c.Rounds);

            base.OnModelCreating(modelBuilder);
        }
    }
}
