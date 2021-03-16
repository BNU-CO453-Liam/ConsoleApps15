using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
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
    /// Liam Smith 09/03/2021
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
            Console.WriteLine("        Apps 01 - 03    ");
            Console.WriteLine("        by Liam Smith        ");
            Console.WriteLine(" -----------------------------\n");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" 1. App 01 - Distance Converter 0.4");
            Console.WriteLine(" 2. App 02 - Body Mass Index Calculator 0.4");
            Console.WriteLine(" 2. App 03 - Student Grades 0.1");
            Console.WriteLine();

            int i = 0;
            
            while(i < 1)         
            {
                Console.Write(" Select a program > ");
                string programChoice = Console.ReadLine();

                switch (programChoice)
                {
                    case "1":
                        DistanceConverter converter = new DistanceConverter();
                        i++;
                        Console.Clear();
                        Console.WriteLine(" \nApp 01 - Distance Converter selected. . . ");

                        Task.Delay(1000).Wait();
                        Console.Clear();

                        converter.Run();
                        break;

                    case "2":
                        BmiCalculator calculator = new BmiCalculator();
                        i++;
                        Console.Clear();
                        Console.WriteLine(" \nApp 02 - BMI Calculator selected. . . ");

                        Task.Delay(1000).Wait();
                        Console.Clear();

                        calculator.Run();
                        break;

                    case "3":
                        StudentGrades grades = new StudentGrades();
                        i++;
                        Console.Clear();
                        Console.WriteLine(" \nApp 03 - Student Grades selected. . . ");

                        Task.Delay(1000).Wait();
                        Console.Clear();

                        grades.Run();
                        break;

                    default:
                        Console.WriteLine(" \nThis App does not exist, Choose another option \n");
                        break;
                }
            } 
        }
    }
}
