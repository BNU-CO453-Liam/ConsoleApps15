using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This app will prompt a user to select a unit of distance to be converted to another unit
    /// either FEET, METRES or MILES. The user will be prompted for a measurement of the selected distance.
    /// The distance will be converted and the output will be displayed.
    /// </summary>
    /// <author>
    /// Liam Smith version 0.4
    /// </author>
    public class DistanceConverter
    {
        private const int FEET_IN_MILES = 5280;
        private const double METRES_IN_MILES = 1609.34;
        private const double FEET_IN_METRES = 3.28084;

        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        private double fromDistance;
        private double toDistance;

        private string fromUnit;
        private string toUnit;

        ///<summary>
        /// Main method used to run application.
        ///</summary>
        public void Run()
        {
            OutputHeading();
            ConvertDistance();
        }

        /// <summary>
        /// Displays a heading to the user
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("      Distance Converter    ");
            Console.WriteLine("        by Liam Smith        ");
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine();
        }

        /// <summary>
        /// Separates the display of unit choices from the execution of choice selected.
        /// Displays what unit has been chosen to the user.
        /// </summary>
        public string SelectUnit(string prompt)
        {
            string choice = DisplayChoices(prompt);

            string unit = ExecuteChoice(choice);

            Console.WriteLine($"\n You have chosen {unit}");

            return unit;
        }

        /// <summary>
        /// Displays choice of units to be selected from.
        /// </summary>
        private static string DisplayChoices(string prompt)
        {
            Console.WriteLine();
            Console.WriteLine($" 1. {FEET}");
            Console.WriteLine($" 2. {METRES}");
            Console.WriteLine($" 3. {MILES}");
            Console.WriteLine();

            Console.Write(prompt);

            string choice = Console.ReadLine();

            return choice;
        }

        /// <summary>
        /// Executes choice selected.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns></returns>
        private static string ExecuteChoice(string choice)
        {
            if (choice == "1")
            {
                return FEET;
            }

            else if (choice == "2")
            {
                return METRES;
            }

            else if (choice == "3")
            {
                return MILES;
            }

            return null;
        }

        /// <summary>
        /// Promts the user to input distance converting from.
        /// Stores value as a double number.
        /// </summary>
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);
            string value = Console.ReadLine();
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Displays what is about to be converted using strings captured previously.
        /// If both selected units are identical, the user is displayed an error message
        /// and forced to repeat the unit selection process.
        /// </summary>
        private void Converting()
        {
            if (fromUnit != toUnit)
            {
                Console.WriteLine($"\n Converting {fromUnit} to {toUnit} \n");
            }

            else
            {
                Console.WriteLine("\n Please select a different pair of units !\n");
                ConvertDistance();
            }
        }

        /// <summary>
        /// Selects what conversions to perform based on the combination
        /// of options previously selected by the user.
        /// </summary>
        public void Conversion()
        {
            if (fromUnit == FEET && toUnit == METRES)
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }

            else if (fromUnit == FEET && toUnit == MILES)
            {
                toDistance = fromDistance / FEET_IN_MILES;
            }

            else if (fromUnit == METRES && toUnit == FEET)
            {
                toDistance = fromDistance / FEET_IN_METRES;
            }

            else if (fromUnit == METRES && toUnit == MILES)
            {
                toDistance = fromDistance / METRES_IN_MILES;
            }

            else if (fromUnit == MILES && toUnit == FEET)
            {
                toDistance = fromDistance * FEET_IN_MILES;
            }

            else if (fromUnit == MILES && toUnit == METRES)
            {
                toDistance = fromDistance * METRES_IN_MILES;
            }
        }

        /// <summary>
        /// Displays result of conversion.
        /// </summary>
        public void OutputResult()
        {
            Console.Write($"\n {fromDistance} {fromUnit} is {toDistance} {toUnit} !\n");
        }

        /// <summary>
        /// Prompts the user for the units to be converted.
        /// Displays what is about to be converted.
        /// 
        /// </summary>
        public void ConvertDistance()
        {
            fromUnit = SelectUnit(" Select the from distance unit > ");
            toUnit = SelectUnit(" Select the to distance unit > ");

            Converting();

            fromDistance = InputDistance($" Enter the distance in {fromUnit} > ");

            Conversion();

            OutputResult();
        }
    }
}
