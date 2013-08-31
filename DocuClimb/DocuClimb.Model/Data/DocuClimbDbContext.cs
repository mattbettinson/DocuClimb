using DocuClimb.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Data
{
    public class DocuClimbDbContext: DbContext
    {
        public DocuClimbDbContext(): base()
        {
            Database.SetInitializer<DocuClimbDbContext>(new DropCreateDatabaseIfModelChanges<DocuClimbDbContext>());

            // TODO custom initalizer to drop create and seed?  http://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx
        }

        public DbSet<Climber> Climbers { get; set; }
        public DbSet<Climb> Climbs { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Climb>().HasRequired<Location>(c => c.Location).WithMany(l => l.Climbs).Map(l => l.MapKey("LocationID"));
            
            modelBuilder.Entity<Climb>().HasMany<Grade>(c => c.Grades).WithMany(g => g.Climbs).Map(g =>
            {
                g.MapLeftKey("ClimbID");
                g.MapRightKey("GradeID");
                g.ToTable("ClimbAndGrade");
            });

            modelBuilder.Entity<Climber>().HasMany<Climb>(c => c.Climbs).WithMany(c => c.Climbers).Map(c =>
            {
                c.MapLeftKey("ClimberID");
                c.MapRightKey("ClimbID");
                c.ToTable("ClimberAndClimb");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
