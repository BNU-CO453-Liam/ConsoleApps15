using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App01;

namespace ConsoleAppTests
{

    [TestClass]
    public class TestDistanceConverter
    {
        [TestMethod]
        public void TestMilesToFeet()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.MILES;
            converter.ToUnit = DistanceConverter.FEET;

            converter.FromDistance = 1.0;
            converter.Conversion();

            double expectedDistance = 5280;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }
        [TestMethod]
        public void TestMilesToMetres()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.MILES;
            converter.ToUnit = DistanceConverter.METRES;

            converter.FromDistance = 1.0;
            converter.Conversion();

            double expectedDistance = 1609.344;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }

        [TestMethod]
        public void MetresToFeet()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.METRES;
            converter.ToUnit = DistanceConverter.FEET;

            converter.FromDistance = 1.0;
            converter.Conversion();

            double expectedDistance = 3.28084;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }

        [TestMethod]
        public void MetresToMiles()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.METRES;
            converter.ToUnit = DistanceConverter.MILES;

            converter.FromDistance = 1609.344;
            converter.Conversion();

            double expectedDistance = 1.0;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }

        [TestMethod]
        public void FeetToMetres()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.FEET;
            converter.ToUnit = DistanceConverter.METRES;

            converter.FromDistance = 3.28084;
            converter.Conversion();

            double expectedDistance = 1.0;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
            
        }

        [TestMethod]
        public void FeetToMiles()
        {
            DistanceConverter converter = new DistanceConverter();

            converter.FromUnit = DistanceConverter.FEET;
            converter.ToUnit = DistanceConverter.MILES;

            converter.FromDistance = 5280;
            converter.Conversion();

            double expectedDistance = 1.0;

            Assert.AreEqual(expectedDistance, converter.ToDistance);
        }


    }
}
