using System;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This app will . . . 
    /// </summary>
    /// <author>
    /// Liam Smith 1.0
    /// </author>
    public class StudentGrades
    {
        // Constants
        public const int LowestMark = 0;
        public const int LowestGradeE = 35;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;

        // Properties
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }


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

        public void Run()
        {
            OutputHeading();
            ShowOptions();
            SelectOption();

        }

        private void OutputHeading()
        {
            Console.WriteLine("Student Marks\n\n");
        }

        private void ShowOptions()
        {
            Console.WriteLine(" 1. Input Marks");
            Console.WriteLine(" 2. Output Marks");
            Console.WriteLine(" 3. Output Stats");
            Console.WriteLine(" 4. Output Grade Profile");
            Console.WriteLine(" 5. Quit");

            SelectOption();
        }

        private void SelectOption()
        {
            Console.Write("\n Please enter your choice > ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InputMarks();
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
            }
        }

        /// <summary>
        /// Input a mark between 0 - 100 for each
        /// student and store it in the marks array
        /// </summary>
        public void InputMarks()
        {
            Console.WriteLine("\n Please enter a mark for each student\n");

            int i = 0;
            while (i < Students.Length)
            {
                Console.Write($" Mark for { Students[i] } > ");
                string input = Console.ReadLine();
                int put = Convert.ToInt32(input);
                Marks[i] = put;
                i++;
            }

            CalculateStats();
            CalculateGradeProfile();
            ShowOptions();

        }

        /// <summary>
        /// List all the students and display their
        /// name and current mark
        /// </summary>
        public void OutputMarks()
        {
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
            if (mark >= LowestMark && mark < LowestGradeE)
            {
                return Grades.F;
            }

            else if (mark >= LowestGradeE && mark < LowestGradeD)
            {
                return Grades.E;
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

        private void OutputStats()
        {
            Console.WriteLine($"\n Maximum mark is {Maximum}");
            Console.WriteLine($" Minimum mark is {Minimum}");
            Console.WriteLine($" Mean mark is {Mean}");

            ShowOptions();
        }

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
    }
}
