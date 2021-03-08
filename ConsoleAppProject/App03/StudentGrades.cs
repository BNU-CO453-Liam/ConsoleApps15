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

        public const int LowestMark = 0;
        public const int LowestGradeD = 40;
        public const int LowestGradeC = 50;
        public const int LowestGradeB = 60;
        public const int LowestGradeA = 70;
        public const int HighestMark = 100;


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

        /// <summary>
        /// Input a mark between 0 - 100 for each
        /// student and store it in the marks array
        /// </summary>
        public void InputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all the students and display their
        /// name and current mark
        /// </summary>
        public void OutputMarks()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert a student mark to a grade
        /// from F (Fail) to A (First Class)
        /// </summary>
        public Grades ConvertToGrade(int mark)
        {
            if (mark >= 0 && mark < LowestGradeD)
            {
                return Grades.F;
            }
            else
            {
                return Grades.B;
            }
        }

        /// <summary>
        /// Calculate and display the minimum, maximum,
        /// and mean mark for all the students
        /// </summary>
        public void CalculateStats()
        {
            throw new NotImplementedException();
        }
    }
}
