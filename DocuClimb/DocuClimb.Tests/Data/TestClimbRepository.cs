using DocuClimb.Data;
using DocuClimb.Data.Repositories;
using DocuClimb.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuClimb.Tests.Data
{
    [TestFixture]
    public class TestClimbRepository
    {
        [SetUp]
        public void SetUp()
        {
            //TODO find better way of deleting data for setup
            TestDataHelper.SetUp();
        }

        [Test]
        public void ClimbRepository_Create_BasicClimb()
        {
            // Arrange
            var newClimb = TestDataHelper.CreateBasicClimb();
            var repository = new ClimbRepository(new DocuClimbDbContext());

            // Act
            repository.Create(newClimb);

            // Assert
            var context = new DocuClimbDbContext();
            var climbFound = context.Climbs.SingleOrDefault<Climb>(c => c.ClimbID == newClimb.ClimbID);

            Assert.IsNotNull(climbFound);
        }

        [Test]
        public void ClimbRepository_Create_GradedClimb()
        {
            // Arrange
            var newClimb = TestDataHelper.CreateGradedClimb(GradeValue);
            var repository = new ClimbRepository(new DocuClimbDbContext());

            // Act
            repository.Create(newClimb);

            // Assert
            var context = new DocuClimbDbContext();
            var climbFound = context.Climbs.SingleOrDefault<Climb>(c => c.ClimbID == newClimb.ClimbID);

            Assert.IsNotNull(climbFound);
            Assert.AreEqual(1, climbFound.Grades.Count);
            Assert.AreEqual(GradeValue, climbFound.Grades.ToList<Grade>()[0].Value);
        }

        [Test]
        public void ClimbRepository_FindAll(){

            // Arrange
            var context = new DocuClimbDbContext();
            context.Climbs.Add(TestDataHelper.CreateBasicClimb());
            context.Climbs.Add(TestDataHelper.CreateBasicClimb());
            context.Climbs.Add(TestDataHelper.CreateBasicClimb());
            context.SaveChanges();

            // Act
            var repository = new ClimbRepository(new DocuClimbDbContext());
            var allClimbs = repository.FindAll();

            // Assert
            Assert.AreEqual(3, allClimbs.Count());
        }

        [Test]
        public void ClimbRepository_FindBy(){
            
            // Arrange
            var climbToFind = TestDataHelper.CreateBasicClimb();
            var context = new DocuClimbDbContext();
            context.Climbs.Add(climbToFind);
            context.SaveChanges();

            // Act
            var repository = new ClimbRepository(new DocuClimbDbContext());
            var climbFound = repository.FindBy(climbToFind.ClimbID);

            // Assert
            Assert_Climb_Matches(climbToFind, climbFound);
        }

        [Test]
        public void ClimbRepository_Update()
        {
            // Arrange
            var originalClimb = TestDataHelper.CreateBasicClimb();
            var context = new DocuClimbDbContext();
            context.Climbs.Add(originalClimb);
            context.SaveChanges();

            // Act
            originalClimb.Name = "Updated Name";

            var repository = new ClimbRepository(new DocuClimbDbContext());
            repository.Update(originalClimb);

            // Assert
            context = new DocuClimbDbContext();
            var foundClimb = context.Climbs.Single<Climb>(c => c.ClimbID == originalClimb.ClimbID);

            Assert.AreEqual("Updated Name", foundClimb.Name);
        }

        [Test]
        public void ClimbRepository_Delete()
        {
            // Arrange
            var climbToDelete = TestDataHelper.CreateBasicClimb();
            var context = new DocuClimbDbContext();
            context.Climbs.Add(climbToDelete);
            context.SaveChanges();

            // Act
            var repository = new ClimbRepository(new DocuClimbDbContext());
            repository.Delete(climbToDelete);

            // Assert
            context = new DocuClimbDbContext();
            var deletedClimb = context.Climbs.SingleOrDefault(c => c.ClimbID == climbToDelete.ClimbID);

            Assert.IsNull(deletedClimb);
        }

        private void Assert_Climb_Matches(Climb climb, Climb climbToMatch)
        {
            Assert.IsNotNull(climbToMatch);
            Assert.AreEqual(climb.ClimbID, climbToMatch.ClimbID);
        }

        private const string GradeValue = "8a";
    }
}
