using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This app will prompt a user to select a unit of distance to be converted to another unit
    /// either feet, metres or miles. The user will be prompted for a measurement of the selected distance.
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

        private double miles;
        private double feet;
        private double metres;

        public string input_string;
        public string output_string;

        /// <summary>
        /// Calls all methods to be run in order
        /// </summary>
        public void Run()
        {
            OutputHeading();
            ConvertFrom();
            ConvertTo();
            Converting();
            Conversion(); 
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
        /// Promt the user to select a unit of distance to convert from
        /// uses an if statement to check for conditions
        /// </summary>
        private void ConvertFrom()
        {
            Console.Write(" Select unit to convert from > \n\n");
            Console.Write(" 1. Feet\n 2. Metres\n 3. Miles\n\n Please enter your choice > ");
            string input_unit = Console.ReadLine();
            if (input_unit == "1")
            {
                Console.WriteLine("\n You have selected Feet");
                input_string = "Feet";
            }
            else if (input_unit == "2")
            {
                Console.WriteLine("\n You have selected Metres");
                input_string = "Metres";
            }
            else if (input_unit == "3")
            {
                Console.WriteLine("\n You have selected Miles");
                input_string = "Miles";
            }
        }

        /// <summary>
        /// Displays options of unit to convert to and stores a public output variable to be displayed later
        /// </summary>
        public void ConvertTo()
        {
            Console.Write("\n Select distance unit to convert to > \n\n");
            Console.Write(" 1. Feet\n 2. Metres\n 3. Miles\n\n Please enter your choice > ");
            string output_unit = Console.ReadLine();
            if (output_unit == "1")
            {
                Console.WriteLine("\n You have selected Feet");
                output_string = "Feet";
            }
            else if (output_unit == "2")
            {
                Console.WriteLine("\n You have selected Metres");
                output_string = "Metres";
            }
            else if (output_unit == "3")
            {
                Console.WriteLine("\n You have selected Miles");
                output_string = "Miles";
            }
        }

        /// <summary>
        /// Displays what is about to be converted using strings captured previously
        /// </summary>
        private void Converting()
        {
            if (input_string != output_string)
            {
                Console.WriteLine("\n Converting " + input_string + " to " + output_string + "\n");
            }

            else
            {
                Console.WriteLine("\n Please select a different pair of units");
            }
        }

        /// <summary>
        /// Selects what conversions to perform
        /// </summary>
        private void Conversion()
        {
            if (input_string == "Feet" && output_string == "Metres")
            {
                InputFeet();
                FeetToMetres();
                Console.WriteLine("\n " + feet + " Feet is " + metres + " Metres !");
            }

            else if (input_string == "Feet" && output_string == "Miles")
            {
                InputFeet();
                CalculateMiles();
                OutputMiles();
            }

            else if (input_string == "Metres" && output_string == "Feet")
            {
                InputMetres();
                MetresToFeet();
                Console.WriteLine("\n " + metres + " Metres is " + feet + " Feet !");
            }

            else if (input_string == "Metres" && output_string == "Miles")
            {
                InputMetres();
                MetresToMiles();
                Console.WriteLine("\n " + metres + " Metres is " + miles + " Miles !");
            }

            else if (input_string == "Miles" && output_string == "Feet")
            {
                InputMiles();
                CalculateFeet();
                OutputFeet();
            }

            else if (input_string == "Miles" && output_string == "Metres")
            {
                InputMiles();
                CalculateMetres();
                OutputMetres();
            }
        }

        /// <summary>
        /// Promt the user to enter the distance in miles
        /// Input the miles in a double number
        /// </summary>
        private void InputMiles()
        {
            Console.Write("  Enter distance in miles > ");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        /// <summary>
        /// Convert the input of miles to feet
        /// </summary>
        private void CalculateFeet()
        {
            feet = miles * 5280;
        }

        /// <summary>
        /// Display result of the previous calculation to the user
        /// </summary>
        private void OutputFeet()
        {
            Console.WriteLine("\n " + miles + " miles is " + feet + " feet!");
        }

        /// <summary>
        /// Promts the user for an input in feet
        /// </summary>
        private void InputFeet()
        {
            Console.Write("  Enter distance in feet > ");
            string value = Console.ReadLine();
            feet = Convert.ToDouble(value);
        }

        /// <summary>
        /// Convert the input of feet to miles
        /// </summary>
        private void CalculateMiles()
        {
            miles = feet / 5280;
        }

        /// <summary>
        /// Calculates feet to metres
        /// </summary>
        private void FeetToMetres()
        {
            metres = feet * 0.3048;
        }

        /// <summary>
        /// Display output of feet to miles
        /// </summary>
        private void OutputMiles()
        {
            Console.WriteLine("\n " + feet + " feet is " + miles + " miles!");
        }

        /// <summary>
        /// Converts input of miles to metres
        /// </summary>
        private void CalculateMetres()
        {
            metres = miles * 1609.34;
        }

        /// <summary>
        /// Displays output of miles to metres
        /// </summary>
        private void OutputMetres()
        {
            Console.WriteLine("\n " + miles + " miles is " + metres + " metres!");
        }

        /// <summary>
        /// promts user for input of metres and converts the input string to a double
        /// </summary>
        private void InputMetres()
        {
                Console.Write("  Enter distance in metres > ");
                string value = Console.ReadLine();
                metres = Convert.ToDouble(value);
        }

        /// <summary>
        /// Calculates metres to feet and stores value as feet
        /// </summary>
        private void MetresToFeet()
        {
            feet = metres / 0.3048;
        }

        /// <summary>
        /// Calculates metres to miles and stores value as miles
        /// </summary>
        private void MetresToMiles()
        {
            miles = metres / 1609.34;
        }
        
    }
}
