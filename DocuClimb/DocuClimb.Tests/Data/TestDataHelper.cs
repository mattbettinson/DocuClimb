using DocuClimb.Data;
using DocuClimb.Domain;
using DocuClimb.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Tests.Data
{
    public static class TestDataHelper
    {
        public static void SetUp()
        {
            var context = new DocuClimbDbContext();
            context.Database.ExecuteSqlCommand("DELETE FROM ClimbAndGrade");
            context.Database.ExecuteSqlCommand("DELETE FROM ClimberAndClimb");
            context.Database.ExecuteSqlCommand("DELETE FROM Climbers");
            context.Database.ExecuteSqlCommand("DELETE FROM Climbs");
            context.Database.ExecuteSqlCommand("DELETE FROM Locations");
            context.Database.ExecuteSqlCommand("DELETE FROM Grades");
        }

        public static Climb CreateBasicClimb()
        {
            return new Climb()
            {
                Name = "Climb A",
                Location = CreateTestLocation()
            };
        }

        public static Climb CreateGradedClimb(string grade = GradeValue)
        {
            var climb = CreateBasicClimb();

            climb.Grades.Add(CreateGrade(grade));

            return climb;

        }

        public static Location CreateTestLocation()
        {
            return new Location()
            {
                AddressLine1 = "AddressLine1",
                AddressLine2 = "AddressLine2",
                AddressLine3 = "AddressLine3",
                Postcode = "Postcode",
                AdditionalInformation = "AdditionalInformation"
            };
        }

        public static Climber CreateClimber()
        {
            return new Climber()
            {
                FirstName = "Matt",
                LastName = "Bettinson",
                Email = "m@google.com",
                HomeTown = "Nottingham",
            };
        }

        public static Climber CreateClimberWithClimbs()
        {
            var climber = CreateClimber();
            climber.Climbs.Add(CreateBasicClimb());

            return climber;
        }

        public static Grade CreateGrade(string gradeValue = GradeValue)
        {
            return new Grade(gradeValue)
            {
                System = GradeSystem.British,
            };
        }

        private const string GradeValue = "5a";

    }
}
