using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleAppProject.App02;

namespace ConsoleAppTests
{
    /// <summary>
    /// Each test will test for a bmi index with corresponding height and weight inputs
    /// for imperial and metric units.
    /// </summary>
    [TestClass]
    public class TestBMI
    {
        [TestMethod]
        public void TestImperial16()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 5.6;
            calculator.WeightInput = 7.5;
            calculator.CalculateBMI();

            int expectedResult = 16;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric16()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.7;
            calculator.WeightInput = 47.6;
            calculator.CalculateBMI();

            int expectedResult = 16;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial18()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 5.5;
            calculator.WeightInput = 7.8;
            calculator.CalculateBMI();

            int expectedResult = 18;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric18()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.67;
            calculator.WeightInput = 50;
            calculator.CalculateBMI();

            int expectedResult = 18;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial20()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 6;
            calculator.WeightInput = 10.7;
            calculator.CalculateBMI();

            int expectedResult = 20;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric20()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.83;
            calculator.WeightInput = 68;
            calculator.CalculateBMI();

            int expectedResult = 20;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial21()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 6.5;
            calculator.WeightInput = 12.9;
            calculator.CalculateBMI();

            int expectedResult = 21;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric21()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.99;
            calculator.WeightInput = 82;
            calculator.CalculateBMI();

            int expectedResult = 21;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial22()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 5.7;
            calculator.WeightInput = 10.23;
            calculator.CalculateBMI();

            int expectedResult = 22;
        
            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric22()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.73;
            calculator.WeightInput = 65;
            calculator.CalculateBMI();

            int expectedResult = 22;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial23()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 5.8;
            calculator.WeightInput = 11.1;
            calculator.CalculateBMI();

            int expectedResult = 23;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric23()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.76;
            calculator.WeightInput = 70.5;
            calculator.CalculateBMI();

            int expectedResult = 23;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial24()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 5.8;
            calculator.WeightInput = 11.8;
            calculator.CalculateBMI();

            int expectedResult = 24;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric24()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.76;
            calculator.WeightInput = 75.5;
            calculator.CalculateBMI();

            int expectedResult = 24;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial25()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 5.9;
            calculator.WeightInput = 12.5;
            calculator.CalculateBMI();

            int expectedResult = 25;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric25()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.79;
            calculator.WeightInput = 79;
            calculator.CalculateBMI();

            int expectedResult = 25;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial26()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 6.3;
            calculator.WeightInput = 14.9;
            calculator.CalculateBMI();

            int expectedResult = 26;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric26()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.92;
            calculator.WeightInput = 95;
            calculator.CalculateBMI();

            int expectedResult = 26;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial28()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 5.5;
            calculator.WeightInput = 12.2;
            calculator.CalculateBMI();

            int expectedResult = 28;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric28()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.67;
            calculator.WeightInput = 78;
            calculator.CalculateBMI();

            int expectedResult = 28;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial30()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 4.9;
            calculator.WeightInput = 10.4;
            calculator.CalculateBMI();

            int expectedResult = 30;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric30()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 1.49;
            calculator.WeightInput = 66;
            calculator.CalculateBMI();

            int expectedResult = 30;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestImperial32()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.IMPERIAL;

            calculator.HeightInput = 6.6;
            calculator.WeightInput = 20.1;
            calculator.CalculateBMI();

            int expectedResult = 32;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }

        [TestMethod]
        public void TestMetric32()
        {
            BmiCalculator calculator = new BmiCalculator();

            calculator.UnitType = BmiCalculator.METRIC;

            calculator.HeightInput = 2.01;
            calculator.WeightInput = 128;
            calculator.CalculateBMI();

            int expectedResult = 32;

            Assert.AreEqual(expectedResult, calculator.BmiResult);
        }


    }
}
