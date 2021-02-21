using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Liam Smith 04/02/2021
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.WriteLine(" 1. Distance Converter 1.4");
            Console.WriteLine(" 2. BMI Calculator 1.0");
            Console.WriteLine();
            Console.WriteLine(" Select a program > \n");

            string a = Console.ReadLine();

            if (a == "1")
            {
                DistanceConverter converter = new DistanceConverter();
                converter.Run();
            }
            else if (a == "2")
            {
                BMI converter = new BMI();
                converter.Run();
            }

        }
    }
}
