using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This app will prompt a user to select a unit of distance to be converted to another unit
    /// either FEET, METRES or MILES. The user will be prompted for a measurement of the selected distance.
    /// The user selections will be validated.
    /// The distance will be converted and the output will be displayed.
    /// </summary>
    /// <author>
    /// Liam Smith version 0.4
    /// </author>
    public class DistanceConverter
    {
        private const int FEET_IN_MILES = 5280;
        private const double METRES_IN_MILES = 1609.344;
        private const double FEET_IN_METRES = 3.28084;

        public const string FEET = "Feet";
        public const string METRES = "Metres";
        public const string MILES = "Miles";

        public double FromDistance { get; set; }
        public double ToDistance { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }

        ///<summary>
        /// Main method used to run application.
        ///</summary>
        public void Run()
        {
            OutputHeading();

            ConvertDistance();

            RoundResult();

            OutputResult();
        }

        /// <summary>
        /// Displays a heading to the user.
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
        public static string DisplayChoices(string prompt)
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
        private static string ExecuteChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    return FEET;

                case "2":
                    return METRES;

                case "3":
                    return MILES;

                default:
                    break;
                }

            return choice;
        }

        /// <summary>
        /// Promts the user to input distance converting from.
        /// Validates user input is a double number or prompts the user again.
        /// </summary>
        private double InputDistance(string prompt)
        {
            Console.Write(prompt);

            string value = Console.ReadLine();

            value = ValidateDouble(value);

            return Convert.ToDouble(value);
        }

        /// <summary>
        /// If user input is not a double number, they will be prompted for input again.
        /// </summary>
        private string ValidateDouble(string value)
        {
            double num = -1;

            while (!double.TryParse(value, out num))
            {
                Console.WriteLine("\n Invalid distance\n");

                FromDistance = InputDistance($" Enter the distance in {FromUnit} > ");

                value = Convert.ToString(FromDistance);

                break;
            }

            return value;
        }

        /// <summary>
        /// Displays what is about to be converted using strings captured previously.
        /// If both selected units are identical, the user is displayed an error message
        /// and forced to repeat the previous unit selection process.
        /// </summary>
        private void Converting()
        {
            if (FromUnit != ToUnit)
            {
                Console.WriteLine($"\n Converting {FromUnit} to {ToUnit} \n");
            }

            else
            {
                Console.WriteLine("\n Please select a different pair of units !\n");
                ValidateToUnit();
            }
        }

        /// <summary>
        /// Selects what conversions to perform based on the combination
        /// of options previously selected by the user.
        /// </summary>
        public void Conversion()
        {
            if (FromUnit == FEET && ToUnit == METRES)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }

            else if (FromUnit == FEET && ToUnit == MILES)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }

            else if (FromUnit == METRES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }

            else if (FromUnit == METRES && ToUnit == MILES)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }

            else if (FromUnit == MILES && ToUnit == FEET)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }

            else if (FromUnit == MILES && ToUnit == METRES)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }

        }

        /// <summary>
        /// Displays result of conversion.
        /// </summary>
        public void OutputResult()
        {
            double result = RoundResult();

            Console.Write($"\n {FromDistance} {FromUnit} is {result} {ToUnit} !\n");
        }

        /// <summary>
        /// Rounds result to appropriate decimal place.
        /// </summary>
        private double RoundResult()
        {
            return Math.Round(ToDistance, 5, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Prompts the user for the units to be converted.
        /// Displays what is about to be converted.
        /// </summary>
        public void ConvertDistance()
        {
            ValidateFromUnit();

            FromDistance = InputDistance($" Enter the distance in {FromUnit} > ");

            Conversion();
        }

        /// <summary>
        /// Checks if the user has selected a valid option.
        /// </summary>
        private void ValidateFromUnit()
        {
            FromUnit = SelectUnit("\n Select the from distance unit > ");
            
            if (FromUnit == FEET || FromUnit == METRES || FromUnit == MILES)
            {
                ValidateToUnit();
            }
            else
            {    
                Console.WriteLine("\n Invalid unit\n");
                ValidateFromUnit();
            }
        }

        /// <summary>
        /// Checks if the user has selected a valid option
        /// </summary>
        private void ValidateToUnit()
        {
            ToUnit = SelectUnit("\n Select the to distance unit > ");

            if (ToUnit == FEET || ToUnit == METRES || ToUnit == MILES)
            {
                Converting();
            }
            else
            {
                Console.WriteLine("\n Invalid unit\n");
                ValidateToUnit();
            }
        }
    }
}