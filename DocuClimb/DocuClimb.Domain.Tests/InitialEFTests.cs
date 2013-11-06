using System;
using NUnit.Framework;
using DocuClimb.Domain.Data;

namespace DocuClimb.Domain.Tests
{
    public class InitialEFTests
    {
        [Test]
        public void CreateDB()
        {
            var context = new DocuClimbDbContext();

            context.Competitions.Add(new Competition()
            {
                Name = "Comp 1",
                Rounds = { new Round(){
                    Name = "Round 1"
                }},
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            });

            context.SaveChanges();
        }
    }
}
