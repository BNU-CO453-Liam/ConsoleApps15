using System;
using System.Text.RegularExpressions;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// Student Marks 1.2
    /// 
    /// This app will prompt a user to select from a list of options:
    /// input marks, output marks, output stats, output grade profile,
    /// and quit.
    /// The user will be prompted to enter the marks for each student.
    /// The user input will be validated and added to an array.
    /// The user will be able to select from the list of options again to
    /// input another set of marks, display the requested data or quit the application.
    /// </summary>
    /// <author>
    /// Liam Smith
    /// </author>
    public class StudentGrades
    {
        // Constants
        public const int LowestMark = 0;
        public const int LowestGradeF = 39;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;
        public const string AllowedChars = @"^[0-9]*$";

        // Properties
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public int addMark;

        public string inputMark;

        public int student = 0;

        /// <summary>
        /// Class constructor called when an object
        /// is created and sets up an array of Students.
        /// </summary>
        public StudentGrades()
        {
            Students = new string[]
            {
                "John", "David", "Kevin",
                "Alice", "Luke", "Asad",
                "Tom", "Leon", "Nicki",
                "Lance"
            };

            GradeProfile = new int[(int)Grades.A + 1];
            Marks = new int[Students.Length];             
        }

        /// <summary>
        /// The method used to initiate the program
        /// calls to other methods to output the heading, show the options,
        /// and select an option.
        /// </summary>
        public void Run()
        {
            OutputHeading();
            ShowOptions();
            SelectOption();
        }

        /// <summary>
        /// Outputs the heading of the application
        /// </summary>
        private void OutputHeading()
        {
            Console.WriteLine("BNU CO453 Applications Programming 2020-2021!");
            Console.WriteLine();
            Console.WriteLine("\n------------------------------");
            Console.WriteLine("        Student Marks ");
            Console.WriteLine("        by Liam Smith        ");
            Console.WriteLine("------------------------------\n");
            Console.WriteLine();
        }

        /// <summary>
        /// Displays a list of options for the user to select from.
        /// </summary>
        private void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine(" 1. Input Marks | 2. Output Marks | 3. Output Stats");
            Console.WriteLine(" 4. Output Grade Profile | 5. Quit");

            student = 0;
            SelectOption();
        }

        /// <summary>
        /// Prompts the user to select an option.
        /// If the user input does not match an option, the user is prompted again.
        /// </summary>
        private void SelectOption()
        {
            Console.Write("\n Please enter your choice > ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StudentMarks();
                    break;

                case "2":
                    OutputMarks();
                    break;

                case "3":
                    OutputStats();
                    break;

                case "4":
                    OutputGradeProfile();
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine(" Invalid option.\n");
                    SelectOption();
                    break;
            }
        }

        /// <summary>
        /// Calls other methods for user to input student marks,
        /// calculate stats, calculate grade profile and show options again.
        /// </summary>
        public void StudentMarks()
        {
            InputMarks();

            CalculateStats();

            CalculateGradeProfile();

            ShowOptions();
        }

        /// <summary>
        /// Input a mark between 0 - 100 for each
        /// student and store it in the marks array
        /// </summary>
        private void InputMarks()
        {
            Console.WriteLine("\n Please enter a mark for each student:\n");

            while (student < Students.Length)
            {
                Console.Write($" Mark for { Students[student] } > ");

                inputMark = Console.ReadLine();

                ValidateInput();

                Marks[student] = addMark;

                student++;
            }
        }

        /// <summary>
        /// List all the students and display their
        /// name and current mark
        /// </summary>
        public void OutputMarks()
        {
            Console.WriteLine("\n Student marks:");

            int i = 0;
            while (i < Students.Length)
            {
                Console.Write($"\n Mark for { Students[i] } > {Marks[i]}");

                i++;
            }

            Console.WriteLine("\n");

            ShowOptions();
        }

        /// <summary>
        /// Convert a student mark to a grade
        /// from F (Fail) to A (First Class)
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= LowestMark && mark < LowestGradeD)
            {
                return Grades.F;
            }

            else if (mark >= LowestGradeD && mark < LowestGradeC)
            {
                return Grades.D;
            }

            else if (mark >= LowestGradeC && mark < LowestGradeB)
            {
                return Grades.C;
            }

            else if (mark >= LowestGradeB && mark < LowestGradeA)
            {
                return Grades.B;
            }

            else if (mark >= LowestGradeA && mark <= HighestMark)
            {
                return Grades.A;
            }

            return Grades.A;
        }

        /// <summary>
        /// Calculate and display the minimum, maximum,
        /// and mean mark for all the students
        /// </summary>
        public void CalculateStats()
        {
            Minimum = Marks[0];
            Maximum = Marks[0];

            double total = 0;

            foreach(int mark in Marks)
            {
                if (mark > Maximum) Maximum = mark;

                if (mark < Minimum) Minimum = mark;

                total += mark;
            }

            Mean = total / Marks.Length;
        }

        /// <summary>
        /// Displays the maximum, minimum and mean marks
        /// </summary>
        private void OutputStats()
        {
            Console.WriteLine($"\n Maximum mark is {Maximum}");
            Console.WriteLine($" Minimum mark is {Minimum}");
            Console.WriteLine($" Mean mark is {Mean}\n");

            ShowOptions();
        }

        /// <summary>
        /// Calculates the grade profile for the class of students.
        /// </summary>
        public void CalculateGradeProfile()
        {
            for(int i = 0; i < GradeProfile.Length; i++)
            {
                GradeProfile[i] = 0;
            }

            foreach(int mark in Marks)
            {
                Grades grade = ConvertToGrade(mark);

                GradeProfile[(int)grade]++;
            }
        }

        /// <summary>
        /// Displays the grade profile for the class of students.
        /// </summary>
        private void OutputGradeProfile()
        {
            Grade grade = Grade.F;

            Console.WriteLine();

            foreach(int count in GradeProfile)
            {
                int percentage = count * 100 / Marks.Length;

                Console.WriteLine($" Grade {grade} {percentage}% Count {count}");

                grade++;
            }

            Console.WriteLine();

            ShowOptions();
        }

        /// <summary>
        /// Checks that the user input for a students mark is a number using regular expressions.
        /// Checks the number is between 0 and 100.
        /// If not the user is prompted to re enter the mark.
        /// </summary>
        private int ValidateInput()
        {
            if (Regex.IsMatch(inputMark, AllowedChars))
            {
                addMark = Convert.ToInt32(inputMark);
            }

            else
            {
                Console.WriteLine($" Enter a value in the range of {LowestMark} and {HighestMark}!");

                Console.Write($"\n Mark for { Students[student] } > ");

                inputMark = Console.ReadLine();

                ValidateInput();

            }

            if (addMark < LowestMark || addMark > HighestMark)
            {

                Console.WriteLine($" Enter a value in the range of {LowestMark} and {HighestMark}");

                Console.Write($"\n Mark for { Students[student] } > ");

                inputMark = Console.ReadLine();

                ValidateInput();
            }

            else
            {
                addMark = Convert.ToInt32(inputMark);
            }

            return addMark;
        }
    }
}
