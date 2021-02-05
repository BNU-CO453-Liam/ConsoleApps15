using System;
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// An App to convert miles to feet
    /// </summary>
    /// <author>
    /// Liam Smith version 0.1
    /// </author>
    public class DistanceConverter
    {
        private double miles;
        private double feet;


        /// <summary>
        /// 
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.1
        /// </author>
        public void Run()
        {
            OutputHeading();
            InputMiles();
            CalculateFeet();
            OutputFeet();
        }
        /// <summary>
        /// Displays a heading to the user
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.1
        /// </author>
        private void OutputHeading()
        {
            Console.WriteLine();
            Console.WriteLine(" -----------------------------");
            Console.WriteLine("     Convert Miles to Feet    ");
            Console.WriteLine("         by Liam Smith        ");
            Console.WriteLine(" -----------------------------");
            Console.WriteLine();
        }

        /// <summary>
        /// Promt the user to enter the distance in miles
        /// Input the miles in a double number
        /// </summary>
        /// /// <author>
        /// Liam Smith version 0.1
        /// </author>
        private void InputMiles()
        {
            Console.Write("Please enter the number of miles > ");
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
    }
}
