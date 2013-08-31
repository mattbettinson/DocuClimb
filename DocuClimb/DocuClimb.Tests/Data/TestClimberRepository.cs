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
    public class TestClimberRepository
    {
        [SetUp]
        public void SetUp()
        {
            //TODO find better way of deleting data for setup
            TestDataHelper.SetUp();
        }

        [Test]
        public void ClimberRepository_Create_Climber()
        {
            // Arrange
            var newClimber = TestDataHelper.CreateClimber();
            var repository = new ClimberRepository(new DocuClimbDbContext());

            // Act
            repository.Create(newClimber);

            // Assert
            var context = new DocuClimbDbContext();
            var climberFound = context.Climbers.SingleOrDefault<Climber>(c => c.ClimberID == newClimber.ClimberID);

            Assert.IsNotNull(climberFound);
        }

        [Test]
        public void ClimberRepository_Create_Climber_WithClimbs()
        {
            // Arrange
            var newClimber = TestDataHelper.CreateClimberWithClimbs();
            var repository = new ClimberRepository(new DocuClimbDbContext());

            // Act
            repository.Create(newClimber);

            // Assert
            var context = new DocuClimbDbContext();
            var climberFound = context.Climbers.SingleOrDefault<Climber>(c => c.ClimberID == newClimber.ClimberID);

            Assert.IsNotNull(climberFound);
            Assert.AreEqual(1, climberFound.Climbs.Count());
        }

        [Test]
        public void ClimberRepository_FindAll()
        {

            // Arrange
            var context = new DocuClimbDbContext();
            context.Climbers.Add(TestDataHelper.CreateClimber());
            context.Climbers.Add(TestDataHelper.CreateClimber());
            context.Climbers.Add(TestDataHelper.CreateClimber());
            context.SaveChanges();

            // Act
            var repository = new ClimberRepository(new DocuClimbDbContext());
            var allClimbers = repository.FindAll();

            // Assert
            Assert.AreEqual(3, allClimbers.Count());
        }

        [Test]
        public void ClimberRepository_FindBy()
        {
            // Arrange
            var climberToFind = TestDataHelper.CreateClimber();
            var context = new DocuClimbDbContext();
            context.Climbers.Add(climberToFind);
            context.SaveChanges();

            // Act
            var repository = new ClimberRepository(new DocuClimbDbContext());
            var climberFound = repository.FindBy(climberToFind.ClimberID);

            // Assert
            Assert_Climber_Matches(climberToFind, climberFound);
        }

        [Test]
        public void ClimberRepository_Update()
        {
            // Arrange
            var originalClimber = TestDataHelper.CreateClimber();
            var context = new DocuClimbDbContext();
            context.Climbers.Add(originalClimber);
            context.SaveChanges();

            // Act
            originalClimber.FirstName = "Updated First Name";

            var repository = new ClimberRepository(new DocuClimbDbContext());
            repository.Update(originalClimber);

            // Assert
            context = new DocuClimbDbContext();
            var foundClimber = context.Climbers.Single<Climber>(c => c.ClimberID == originalClimber.ClimberID);

            Assert.AreEqual("Updated First Name", foundClimber.FirstName);
        }

        [Test]
        public void ClimberRepository_Delete()
        {
            // Arrange
            var climberToDelete = TestDataHelper.CreateClimber();
            var context = new DocuClimbDbContext();
            context.Climbers.Add(climberToDelete);
            context.SaveChanges();

            // Act
            var repository = new ClimberRepository(new DocuClimbDbContext());
            repository.Delete(climberToDelete);

            // Assert
            context = new DocuClimbDbContext();
            var deletedClimber = context.Climbers.SingleOrDefault(c => c.ClimberID == climberToDelete.ClimberID);

            Assert.IsNull(deletedClimber);
        }

        private void Assert_Climber_Matches(Climber climber, Climber climberToMatch)
        {
            Assert.IsNotNull(climberToMatch);
            Assert.AreEqual(climber.ClimberID, climberToMatch.ClimberID);
        }
    }
}
