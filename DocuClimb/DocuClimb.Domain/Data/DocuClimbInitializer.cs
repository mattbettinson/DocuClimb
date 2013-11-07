using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Domain.Data
{
    public class DocuClimbInitializer : DropCreateDatabaseIfModelChanges<DocuClimbDbContext>
    {
        protected override void Seed(DocuClimbDbContext context)
        {
            var competition = CreateCompetition();
            var round = CreateRound();
            var climb = CreateClimb();
            var climber = CreateClimber();
            var result = CreateResult();

            competition.Rounds.Add(round);
            competition.Entrants.Add(climber);
            round.Climbs.Add(climb);

            result.Climb = climb;
            result.Round = round;
            result.Climber = climber;

            context.Competitions.Add(competition);
            context.Results.Add(result);

            context.SaveChanges();

            base.Seed(context);
        }

        public static Climber CreateClimber()
        {
            return new Climber{
                FirstName = "Matt",
                LastName = "Bettinson",
                Email = "test@gmail.com",
                HomeTown = "Nottingham"
            };
        }

        public static Climb CreateClimb()
        {
            return new Climb()
            {
                Name = "Pink 22",
                Location = "The Depot, Nottingham",
                Grade = "V5"
            };
        }

        public static Round CreateRound()
        {
            return new Round()
            {
                Name = "Round 1"
            };
        }

        public static Competition CreateCompetition()
        {
            return new Competition()
            {
                Name = "Summer League",
                StartDate = new DateTime(2014, 06, 01),
                EndDate = new DateTime(2014, 09, 01),
                IsOpen = false
            };
        }

        public static Result CreateResult()
        {
            return new Result(){
                Points = 10
            };
        }

    }
}
