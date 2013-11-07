using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuClimb.Domain.Data.Entity;

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

        public IDbSet<Competition> Competitions { get; set; }

        public IDbSet<Round> Rounds { get; set; }

        public IDbSet<Climb> Climbs { get; set; }

        public IDbSet<Climber> Climbers { get; set; }

        public IDbSet<Result> Results { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Entity configuration...
            modelBuilder.Configurations.Add(new CompetitionConfiguration());
            modelBuilder.Configurations.Add(new RoundConfiguration());
            modelBuilder.Configurations.Add(new ClimbConfiguration());
            modelBuilder.Configurations.Add(new ClimberConfiguration());
            modelBuilder.Configurations.Add(new ResultConfiguration());

            modelBuilder.Entity<Competition>()
                .HasMany(x => x.Entrants)
                .WithMany(x => x.Entries)
                .Map(x => x.ToTable("Entries", "DocuClimb"));

            modelBuilder.Entity<Round>()
                .HasMany(x => x.Climbs)
                .WithMany(x => x.Rounds)
                .Map(x => x.ToTable("RoundClimbs", "DocuClimb"));
        }
    }
}
