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
    public class TestGradeRepository
    {
        [SetUp]
        public void SetUp()
        {
            //TODO find better way of deleting data for setup
            TestDataHelper.SetUp();
        }

        [Test]
        public void GradeRepository_Create_Grade()
        {
            // Arrange
            var newGrade = TestDataHelper.CreateGrade();
            var repository = new GradeRepository(new DocuClimbDbContext());

            // Act
            repository.Create(newGrade);

            // Assert
            var context = new DocuClimbDbContext();
            var gradeFound = context.Grades.SingleOrDefault<Grade>(g => g.GradeID == newGrade.GradeID);

            Assert.IsNotNull(gradeFound);
        }
    
        [Test]
        public void GradeRepository_FindAll()
        {
            // Arrange
            var context = new DocuClimbDbContext();
            context.Grades.Add(TestDataHelper.CreateGrade());
            context.Grades.Add(TestDataHelper.CreateGrade());
            context.Grades.Add(TestDataHelper.CreateGrade());
            context.SaveChanges();

            // Act
            var repository = new GradeRepository(new DocuClimbDbContext());
            var allGrades = repository.FindAll();

            // Assert
            Assert.AreEqual(3, allGrades.Count());
        }

        [Test]
        public void GradeRepository_FindBy()
        {
            // Arrange
            var gradeToFind = TestDataHelper.CreateGrade();
            var context = new DocuClimbDbContext();
            context.Grades.Add(gradeToFind);
            context.SaveChanges();

            // Act
            var repository = new GradeRepository(new DocuClimbDbContext());
            var gradeFound = repository.FindBy(gradeToFind.GradeID);

            // Assert
            Assert_Grade_Matches(gradeToFind, gradeFound);
        }

        [Test]
        public void GradeRepository_Update()
        {
            // Arrange
            var originalGrade = TestDataHelper.CreateGrade();
            var context = new DocuClimbDbContext();
            context.Grades.Add(originalGrade);
            context.SaveChanges();

            // Act
            originalGrade.Value = "1";

            var repository = new GradeRepository(new DocuClimbDbContext());
            repository.Update(originalGrade);

            // Assert
            context = new DocuClimbDbContext();
            var foundGrade = context.Grades.Single<Grade>(g => g.GradeID == originalGrade.GradeID);

            Assert.AreEqual("1", foundGrade.Value);
        }

        [Test]
        public void GradeRepository_Delete()
        {
            // Arrange
            var gradeToDelete = TestDataHelper.CreateGrade();
            var context = new DocuClimbDbContext();
            context.Grades.Add(gradeToDelete);
            context.SaveChanges();

            // Act
            var repository = new GradeRepository(new DocuClimbDbContext());
            repository.Delete(gradeToDelete);

            // Assert
            context = new DocuClimbDbContext();
            var deletedGrade = context.Grades.SingleOrDefault(g => g.GradeID == gradeToDelete.GradeID);

            Assert.IsNull(deletedGrade);
        }

        private void Assert_Grade_Matches(Grade grade, Grade gradeToMatch)
        {
            Assert.IsNotNull(gradeToMatch);
            Assert.AreEqual(grade.GradeID, gradeToMatch.GradeID);
        }
    }
}
