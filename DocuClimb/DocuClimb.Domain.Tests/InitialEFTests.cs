using System;
using NUnit.Framework;
using DocuClimb.Domain.Data;
using System.Data.Entity;

namespace DocuClimb.Domain.Tests
{
    public class InitialEFTests
    {
        [Test]
        public void CreateDB()
        {

            var initializer = new DocuClimbInitializer();
            Database.SetInitializer(initializer);
            initializer.InitializeDatabase(new DocuClimbDbContext());
                
            var context = new DocuClimbDbContext();

            var climber = new Climber()
            {
                FirstName = "Bill",
                LastName = "Jones"
            };

            var climb = new Climb()
            {
                Name = "Climb 1"
            };

            var round = new Round()
            {
                Name = "Round 1",
                Climbs = { climb }
            };

            var competition = new Competition()
            {
                Name = "Comp 1",
                Rounds =
                {
                    round
                },
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Entrants =
                {
                    climber
                }
            };

            var result = new Result()
            {

                Points = 20,
                Climb = climb,
                Climber = climber,
                Round = round
            };


            context.Competitions.Add(competition);
            context.Results.Add(result);

            context.SaveChanges();
        }
    }
}
