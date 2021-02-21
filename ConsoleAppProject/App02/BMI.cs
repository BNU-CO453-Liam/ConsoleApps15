using System;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This app will display a selection of units to be used for height.
    /// Promt the user to enter their height.
    /// Display a selection of units of weight.
    /// Promt the user to enter their weight.
    /// Convert user inputs to meters and kilograms respectively.
    /// Calculate BMI and convert result to integer.
    /// Display results to the user.
    /// </summary>
    /// <author>
    /// Student Name version 1.3
    /// </author>

    public class BMI
    {

        private const double POUNDS_IN_KG = 0.453592;
        private const double STONE_IN_KG = 6.35029;

        private const double CM_IN_M = 100;
        private const double FT_IN_M = 0.3048;

        public const string KG = "Kilograms";
        public const string POUNDS = "Pounds";
        public const string STONE = "Stone";
        public const string FEET = "Feet";
        public const string METERS = "Meters";
        public const string CM = "Centimeters";

        private string heightUnit;
        private double heightInput;
        private double heightInMetres;

        private string weightUnit;
        private double weightInput;
        private double weightInKilograms;

        private double bmiFormula;
        private int bmiResult;
        private string bmiCategory;

        public void Run()
        {
            OutputHeading();
            SelectCalculation();
        }

        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("         BMI Calculator    ");
            Console.WriteLine("         by Liam Smith        ");
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine();
        }

        private void SelectCalculation()
        {
            Console.WriteLine(" Are you aged 20 or younger? Enter Y/N");
            string age = Console.ReadLine();

            while (age != "")
            {
                if (age.ToUpper() == "Y")
                {
                    YouthCalculations();
                    break;
                }

                else if (age.ToUpper() == "N")
                {
                    AdultCalculations();
                    break;
                }
            }

        }

        private void YouthCalculations()
        {
            Console.WriteLine(" do this");
        }

        private string SelectHeightUnit()
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METERS}");
            Console.WriteLine($" 3. {CM}");
            Console.WriteLine();

            Console.WriteLine(" Select a unit of height > ");

            heightUnit = Console.ReadLine();

            // new method

            if (heightUnit == "1")
            {
                heightUnit = FEET;
            }

            else if (heightUnit == "2")
            {
                heightUnit = METERS;
            }

            else if (heightUnit == "3")
            {
                heightUnit = CM;
            }

            return heightUnit;

        }

        private double EnterHeight(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);   
        }

        public void ConvertHeight()
        {
            if (heightUnit == FEET)
            {
                heightInMetres = heightInput * FT_IN_M;
            }

            else if (heightUnit == METERS)
            {
                heightInMetres = heightInput;
            }

            else if (heightUnit == CM)
            {
                heightInMetres = heightInput / CM_IN_M;
            }
        }

        private void SelectWeightUnit()
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {KG}");
            Console.WriteLine($" 2. {POUNDS}");
            Console.WriteLine($" 3. {STONE}");
            Console.WriteLine();

            Console.WriteLine("\n Select a unit of weight > ");

            weightUnit = Console.ReadLine();

            if (weightUnit == "1")
            {
                weightUnit = KG;
            }

            else if (weightUnit == "2")
            {
                weightUnit = POUNDS;
            }

            else if (weightUnit == "3")
            {
                weightUnit = STONE;
            }

        }

        private double EnterWeight(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        public void ConvertWeight()
        {

            if (weightUnit == KG)
            {
                weightInKilograms = weightInput;
            }

            else if (weightUnit == POUNDS)
            {
                weightInKilograms = weightInput * POUNDS_IN_KG;
            }

            else if (weightUnit == STONE)
            {
                weightInKilograms = weightInput * STONE_IN_KG;
            }
        }

        private void AdultCalculations()
        {

            SelectHeightUnit();
            heightInput = EnterHeight($"\n Enter height in {heightUnit} > ");

            ConvertHeight();

            SelectWeightUnit();
            weightInput = EnterWeight($"\n Enter weight in {weightUnit} > ");

            ConvertWeight();

            CalculateBMI();
            AdultResultsCategory();

            Console.WriteLine($"\n Your BMI is {bmiResult}");
            Console.WriteLine($"\n You are {bmiCategory}");

        }

        private void CalculateBMI()
        {
            bmiFormula = weightInKilograms / (heightInMetres * heightInMetres);
            bmiResult = Convert.ToInt32(bmiFormula);
        }

        private void AdultResultsCategory()
        {
            if (bmiResult > 12 && bmiResult < 18.5)
            {
                bmiCategory = "Underweight";
            }

            else if (bmiResult > 18.5 && bmiResult < 24.9)
            {
                bmiCategory = "a Healthy weight";
            }

            else if (bmiResult > 25 && bmiResult < 29.9)
            {
                bmiCategory = "Overweight";
            }

            else if (bmiResult > 29.9)
            {
                bmiCategory = "Obese";
            }
        }
    }
}

