using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App03;
using ConsoleAppProject.Helpers;

namespace ConsoleAppTests
{
    [TestClass]
    public class TestStudentGrades
    {
        private readonly StudentGrades converter = new StudentGrades();

        private readonly int[] StatsMarks = new int[]
            {
                10, 20, 30, 40, 50, 60, 70, 80, 90, 100
            };

        [TestMethod]
        public void TestGradeProfile()
        {
            converter.Marks = StatsMarks;
            bool expectedProfile = false;

            converter.CalculateGradeProfile();

            expectedProfile = ((converter.GradeProfile[0] == 3) &&
                               (converter.GradeProfile[1] == 1) &&
                               (converter.GradeProfile[2] == 1) &&
                               (converter.GradeProfile[3] == 1) &&
                               (converter.GradeProfile[4] == 4));

            Assert.IsTrue(expectedProfile);
        }

        [TestMethod]
        public void TestCalculateMax()
        {
            converter.Marks = StatsMarks;
            int expectedMax = 100;

            converter.CalculateStats();

            Assert.AreEqual(expectedMax, converter.Maximum);
        }

        [TestMethod]
        public void TestCalculateMin()
        {
            converter.Marks = StatsMarks;
            int expectedMin = 10;

            converter.CalculateStats();

            Assert.AreEqual(expectedMin, converter.Minimum);
        }

        [TestMethod]
        public void TestCalculateMean()
        {
            converter.Marks = StatsMarks;

            double expectedMean = 55.0;

            converter.CalculateStats();

            Assert.AreEqual(expectedMean, converter.Mean);
        }

        [TestMethod]
        public void Convert0ToGradeF()
        {
            // Arrange

            Grades expectedGrade = Grades.F;

            // Act

            Grades actualGrade = converter.ConvertToGrade(0);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert39ToGradeF()
        {
            // Arrange

            Grades expectedGrade = Grades.F;

            // Act

            Grades actualGrade = converter.ConvertToGrade(39);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert40ToGradeD()
        {
            // Arrange

            Grades expectedGrade = Grades.D;

            // Act

            Grades actualGrade = converter.ConvertToGrade(40);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert49ToGradeD()
        {
            // Arrange

            Grades expectedGrade = Grades.D;

            // Act

            Grades actualGrade = converter.ConvertToGrade(49);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert50ToGradeC()
        {
            // Arrange

            Grades expectedGrade = Grades.C;

            // Act

            Grades actualGrade = converter.ConvertToGrade(50);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert59ToGradeC()
        {
            // Arrange

            Grades expectedGrade = Grades.C;

            // Act

            Grades actualGrade = converter.ConvertToGrade(59);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert60ToGradeB()
        {
            // Arrange

            Grades expectedGrade = Grades.B;

            // Act

            Grades actualGrade = converter.ConvertToGrade(60);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert69ToGradeB()
        {
            // Arrange

            Grades expectedGrade = Grades.B;

            // Act

            Grades actualGrade = converter.ConvertToGrade(69);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert70ToGradeA()
        {
            // Arrange

            Grades expectedGrade = Grades.A;

            // Act

            Grades actualGrade = converter.ConvertToGrade(70);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        [TestMethod]
        public void Convert100ToGradeA()
        {
            // Arrange

            Grades expectedGrade = Grades.A;

            // Act

            Grades actualGrade = converter.ConvertToGrade(100);

            // Assert

            Assert.AreEqual(expectedGrade, actualGrade);
        }

        
    }
}
