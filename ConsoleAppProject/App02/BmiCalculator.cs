using System;
using System.Text;
namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This app will display an option to calculate BMI for a child.
    /// If not calculating for a child then the default is BMI for adults.
    /// Prompt the user to select from either imperial or metric units.
    /// Promt the user to enter their height.
    /// Promt the user to enter their weight.
    /// Calculate BMI.
    /// Display results to the user with associated bmi range.
    /// </summary>
    /// <author>
    /// Student Name version 0.4
    /// </author>

    public class BmiCalculator
    {
        public const string IMPERIAL = "Imperial";
        public const string METRIC = "Metric";

        public string UnitType { get; set; }
        public double HeightInput { get; set; }
        public double WeightInput { get; set; }

        public int BmiType { get; set; }
        public double BmiFormula { get; set; }

        public int BmiResult { get; set; }

        public string BmiCategory { get; set; }

        /// <summary>
        /// Initiates the starting methods of the BMI calculator.
        /// </summary>
        public void Run()
        {
            OutputHeading();
            SelectVersion();
        }

        /// <summary>
        /// Outputs the heading of the program to the user.
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("  Body Mass Index Calculator ");
            Console.WriteLine("        by Liam Smith        ");
            Console.WriteLine("------------------------------\n");
            Console.WriteLine();
        }

        /// <summary>
        /// Prompts the user to answer if they would like to check bmi of a child,
        /// if not the adult version is selected by default
        /// </summary>
        private void SelectVersion()
        {
            Console.Write(" Would you like to check BMI for child\n aged 2-4 years? Enter Y/N > ");
            string age = Console.ReadLine();

            while (age != "")
            {
                if (age == "y" || age == "Y")
                {
                    ChildVersion();
                    break;
                }
                    
                else if (age == "n" || age == "N")
                {
                    Console.Clear();
                    BmiType = 1;
                    OutputHeading();
                    DisplayUnits();
                    Events();
                    break;
                }

                else
                {
                    Console.WriteLine(" Invalid option\n");
                    SelectVersion();
                }
            }
        }

        /// <summary>
        /// Displays available unit types to the user.
        /// </summary>
        private void DisplayUnits()
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {IMPERIAL}");
            Console.WriteLine($" 2. {METRIC}");
            Console.WriteLine();
        }

        /// <summary>
        /// Prompts user to select either imperial or metric units.
        /// </summary>
        private void SelectUnits()
        {
            Console.Write(" Select a unit of measurement > ");
            UnitType = Console.ReadLine();

            if (UnitType == "1")
            {
                UnitType = IMPERIAL;
                
                ImperialUnits();
            }

            else if (UnitType == "2")
            {
                UnitType = METRIC;

                MetricUnits();
            }

            else
            {
                Console.WriteLine("\n Invalid option\n");

                SelectUnits();
            }
        }

        /// <summary>
        /// Prompts user for childs age and gender.
        /// </summary>
        private void ChildVersion()
        {     
            Console.Write("\n Enter child's age > ");

            int age = Convert.ToInt32(Console.ReadLine());

            if (age >= 2 && age <= 4)
            {
                Console.WriteLine("\n 1. Boy");
                Console.Write(" 2. Girl");
                Console.WriteLine();
                Console.Write("\n Select child's gender > ");

                string gender = Console.ReadLine();

                switch (gender)
                {
                    case "1": 
                        BmiType = 2;
                        DisplayUnits();
                        Events();
                        break;

                    case "2":
                        BmiType = 3;
                        DisplayUnits();
                        Events();
                        break;

                    default:
                        Console.WriteLine(" Invalid age\n");
                        ChildVersion();
                        break;
                }
            }

            else
            {
                Console.WriteLine(" Invalid age\n");
                ChildVersion();
            }             
        }

        /// <summary>
        /// Prompts user for height and weight in imperial units.
        /// </summary>
        private void ImperialUnits()
        {
            UnitType = IMPERIAL;

            Console.WriteLine(" \n Enter height to the nearest feet and inches");
            Console.Write("\n Enter height in Feet > ");
            string heightInFeet = Console.ReadLine();

            Console.Write(" Enter height in Inches > ");
            string heightInInches = Console.ReadLine();
            heightInInches = "0." + heightInInches;

            HeightInput = Convert.ToDouble(heightInFeet) + Convert.ToDouble(heightInInches);

            Console.WriteLine(" \n Enter weight to the nearest stones and pounds");
            Console.Write("\n Enter weight in Stones > ");
            string weightInStones = Console.ReadLine();

            Console.Write(" Enter weight in Pounds > ");
            string weightInPounds = Console.ReadLine();
            weightInPounds = "0." + weightInPounds;

            WeightInput = Convert.ToDouble(weightInStones) + Convert.ToDouble(weightInPounds);
        }

        /// <summary>
        /// Prompts user for height and weight in metric units.
        /// </summary>
        private void MetricUnits()
        {
            UnitType = METRIC;

            Console.Write("\n Enter height in Metres > ");
            string heightInMetres = Console.ReadLine();

            HeightInput = Convert.ToDouble(heightInMetres);

            Console.Write("\n Enter weight in Kilograms > ");
            string weightInKilograms = Console.ReadLine();

            WeightInput = Convert.ToDouble(weightInKilograms);
        }

        /// <summary>
        /// Prepares user inputs for bmi calculations based on units previously selected.
        /// </summary>
        public void CalculateBMI()
        {
            if (UnitType == IMPERIAL)
            {
                CalculateImperial();
            }

            else if (UnitType == METRIC)
            {
                CalculateMetric();
            }
        }

        public void CalculateMetric()
        {
            BmiFormula = WeightInput / (HeightInput * HeightInput);
            BmiResult = Convert.ToInt32(BmiFormula);
        }

        public void CalculateImperial()
        {
            WeightInput = (WeightInput * 14);

            HeightInput = HeightInput * 12;

            BmiFormula = (WeightInput * 703) / (HeightInput * HeightInput);
            BmiResult = Convert.ToInt32(BmiFormula);
        }

        /// <summary>
        /// Order of methods to perform BMI calculation and display results.
        /// </summary>
        private void Events()
        {
            SelectUnits();

            CalculateBMI();

            SelectResults();

            OutputResults();
        }

        /// <summary>
        /// Selects results to display
        /// </summary>
        private void SelectResults()
        {
            if (BmiType == 1)
            {
                AdultResults();
            }

            else if (BmiType == 2)
            {
                BoysResults();
            }

            else if (BmiType == 3)
            {
                GirlsResults();
            }
        }

        /// <summary>
        /// Selects adults BMI range to be displayed for BMI results.
        /// </summary>
        public string AdultResults()
        {
            StringBuilder message = new StringBuilder("\n");

            if (BmiResult > 12 && BmiResult < 18.5)
            {
                message.Append($" Your BMI is {BmiResult}. " +
                    $"You are in the underweight range.");
            }

            else if (BmiResult > 18.5 && BmiResult < 24.9)
            {
                message.Append($" Your BMI is {BmiResult}. " +
                    $"You are in a healthy weight range.");
            }

            else if (BmiResult > 25 && BmiResult < 29.9)
            {
                message.Append($" Your BMI is {BmiResult}. " +
                    $"You are in the overweight range.");
            }

            else if (BmiResult > 30 && BmiResult < 34.9)
            {
                message.Append($" Your BMI is {BmiResult}. " +
                    $"You are in the Obese Class 1 range.");
            }

            else if (BmiResult > 35 && BmiResult < 39.9)
            {
                message.Append($" Your BMI is {BmiResult}. " +
                    $"You are in the Obese Class 2 range.");
            }

            else if (BmiResult >= 40)
            {
                message.Append($" Your BMI is {BmiResult}. " +
                    $"You are in the Obese Class 3 range.");
            }

            return message.ToString();
        }

        /// <summary>
        /// Selects girls percentile group to be displayed for BMI results.
        /// </summary>
        private string GirlsResults()
        {
            StringBuilder message = new StringBuilder("\n");

            if (BmiResult >= 12 && BmiResult <= 13.2)
            {
                message.Append($" Child's BMI is {BmiResult}. " + 
                    $" Child is in the 0.4th centile - Very thin)");
            }

            else if (BmiResult >= 13.2 && BmiResult <= 14)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 2nd centile - Low BMI");
            }

            else if (BmiResult >= 14.1 && BmiResult <= 17.5)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the healthy range");
            }

            else if (BmiResult >= 17.6 && BmiResult <= 18.7)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 91st centile - Overweight");
            }

            else if (BmiResult >= 18.8 && BmiResult <= 19.9)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 98th centile - Very overweight (Obese)");
            }

            else if (BmiResult >= 20)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 99.6th centile - Severely overweight (Severely obese)");
            }

            return message.ToString();
        }

        /// <summary>
        /// Selects boys percentile group to be displayed for BMI results.
        /// </summary>
        private string BoysResults()
        {
            StringBuilder message = new StringBuilder("\n");

            if (BmiResult >= 12.4 && BmiResult <= 13.2)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 0.4th centile - Very thin)");
            }

            else if (BmiResult >= 13.2 && BmiResult <= 13.7)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 2nd centile - Low BMI");
            }

            else if (BmiResult >= 13.8 && BmiResult <= 17.8)
            {
                message.Append($" Child'sBMI is {BmiResult}. " +
                    $" Child is in the healthy range");
            }

            else if (BmiResult >= 17.9 && BmiResult <= 18.8)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 91st centile - Overweight");
            }

            else if (BmiResult >= 18.9 && BmiResult <= 19.9)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 98th centile - Very overweight (Obese)");
            }

            else if (BmiResult >= 20)
            {
                message.Append($" Child's BMI is {BmiResult}. " +
                    $" Child is in the 99.6th centile - Severely overweight (Severely obese)");
            }
            return message.ToString();
        }

        /// <summary>
        /// Displays results of BMI and associated range
        /// </summary>
        private void OutputResults()
        {
            if (BmiType == 1)
            {
                Console.WriteLine(AdultResults());
            }

            else if (BmiType == 2)
            {
                Console.WriteLine(BoysResults());
            }

            else if (BmiType == 3)
            {
                Console.WriteLine(GirlsResults());
            }

            Console.WriteLine(BameWarning());
        }

        /// <summary>
        /// Displays warning message applicable to ethnic groups
        /// </summary>
        public string BameWarning()
        {
            StringBuilder message2 = new StringBuilder("\n");

            message2.Append("\n If you are Black, Asian or other minority " +
                "ethnic groups, you have a higher risk." +
                "\n Adults 23.0 or more are at increased risk" +
                " Adults 27.5 or more are at high risk");

            return message2.ToString();
        }
    }
}

