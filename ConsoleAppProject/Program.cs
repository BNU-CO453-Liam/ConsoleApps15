using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using System;
using System.Threading.Tasks;

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
        /// <summary>
        /// Displays a heading
        /// Displays a list of apps to select from
        /// </summary>
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.WriteLine("\n -----------------------------");
            Console.WriteLine("        Apps 01 - 02    ");
            Console.WriteLine("        by Liam Smith        ");
            Console.WriteLine(" -----------------------------\n");
            Console.WriteLine();
            Console.WriteLine();

            int i = 0;
            
            while(i < 1)         
            {
                Console.WriteLine(" Select a program > ");
                Console.WriteLine();
                Console.WriteLine(" 1. App 01 - Distance Converter 1.4");
                Console.WriteLine(" 2. App 02 - BMI Calculator 1.3");
                Console.WriteLine();

                string programChoice = Console.ReadLine();

                switch (programChoice)
                {
                    case "1":
                        DistanceConverter converter = new DistanceConverter();
                        i++;
                        Console.Clear();
                        Console.WriteLine(" \nApp 01 - Distance Converter selected. . . ");

                        Task.Delay(2000).Wait();
                        Console.Clear();

                        converter.Run();
                        break;

                    case "2":
                        BMI calculator = new BMI();
                        i++;
                        Console.Clear();
                        Console.WriteLine(" \nApp 02 - BMI Calculator selected. . . ");

                        Task.Delay(2000).Wait();
                        Console.Clear();

                        calculator.Run();
                        break;

                    default:
                        Console.WriteLine(" \nThis App does not exist, Choose another option \n");
                        break;
                }
            } 
        }
    }
}
