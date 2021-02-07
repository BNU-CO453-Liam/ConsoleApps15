using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// An App to convert distance
    /// </summary>
    /// <author>
    /// Liam Smith version 0.4
    /// </author>
    public class DistanceConverter
    {
        private const int FEET_IN_MILES = 5280;
        private double miles;
        private double feet;
        private double metres;


        /// <summary>
        /// Calls all methods to be run in order
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.2
        /// </author>
        public void Run()
        {
            OutputHeading();
            InputMiles();
            CalculateFeet();
            OutputFeet();
            InputFeet();
            CalculateMiles();
            OutputMiles();
            InputMiles();
            CalculateMetres();
            OutputMetres();
        }
        /// <summary>
        /// Displays a heading to the user
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.3
        /// </author>
        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("         Distance Converter    ");
            Console.WriteLine("           by Liam Smith        ");
            Console.WriteLine("-----------------------------\n");
            Console.WriteLine();
        }

        /// <summary>
        /// Promt the user to select a unit of distance to convert from
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.4
        /// </author>
        private void ConvertFrom()
        {
            Console.Write("Select unit to convert from> ");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
            metres = Convert.ToDouble(value);
        }

        /// <summary>
        /// Promt the user to enter the distance in miles
        /// Input the miles in a double number
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.3
        /// </author>
        private void InputMiles()
        {
            Console.Write("Please enter the number of miles> ");
            string value = Console.ReadLine();
            miles = Convert.ToDouble(value);
        }

        /// <summary>
        /// Convert the input to feet
        /// Multiply miles * 5280
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.1
        /// </author>
        private void CalculateFeet()
        {
            feet = miles * 5280;
        }

        /// <summary>
        /// Display result of the previous calculation to the user
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.1
        /// </author>
        private void OutputFeet()
        {
            Console.WriteLine(miles + " miles is " + feet + " feet!");
        }

        /// <summary>
        /// Promts the user for an input in feet
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.3
        /// </author>
        private void InputFeet()
        {
            Console.Write("Please enter the number of feet> ");
            string value = Console.ReadLine();
            feet = Convert.ToDouble(value);
        }

        /// <summary>
        /// Convert the input of feet to miles
        /// Divide input by 5280
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.2
        /// </author>
        private void CalculateMiles()
        {
            miles = feet / 5280;
        }

        /// <summary>
        /// Display output of feet to miles
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.2
        /// </author>
        private void OutputMiles()
        {
            Console.WriteLine(feet + " feet is " + miles + " miles!");
        }

        /// <summary>
        /// Converts input of miles to metres
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.3
        /// </author>
        private void CalculateMetres()
        {
            metres = miles * 1609.34;
        }

        /// <summary>
        /// Displays output of miles to metres
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.3
        /// </author>
        private void OutputMetres()
        {
            Console.WriteLine(miles + " miles is " + metres + " metres!");
        }
        
    }
}
