using System;
using System.Text;
using System.ComponentModel;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// This app will . . . 
    /// </summary>
    /// <author>
    /// Liam Smith 1.0
    /// </author>
    class StudentGrades
    {
        public string[] Students { get; set; }
        public int[] Marks { get; set; }
        public int[] GradeProfile { get; set; }
        public double Mean { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        /// <summary>
        /// Grade A is First Class      : 70 - 100
        /// Grade B is Upper Second     : 60 - 69
        /// Grade C is Lower Second     : 50 - 59
        /// Grade D is Third Class      : 40 - 49
        /// Grade E is Fourth Class     : 30 - 39
        /// Grade F is Fail             : 0 - 29
        /// </summary>
        public enum Grades
        {
            [Description("Fail")]
            F,
            [Description("Fourth Class")]
            E,
            [Description("Third Class")]
            D,
            [Description("Lower Second")]
            C,
            [Description("Upper Second")]
            B,
            [Description("First Class")]
            A,
        }

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

            GradeProfile = new int[(int)Grade.A + 1];
            Marks = new int[Students.Length];
                
        }

        /// <summary>
        /// Input a mark between 0 - 100 for each
        /// student and store it in the marks array
        /// </summary>
        public void InputMarks()
        {
            throw new NotImplementedException;
        }

        /// <summary>
        /// List all the students and display their
        /// name and current mark
        /// </summary>
        public void OutputMarks()
        {
            throw new NotImplementedException;
        }

        /// <summary>
        /// Convert a student mark to a grade
        /// from F (Fail) to A (First Class)
        /// </summary>
        public Grade ConvertToGrade(int mark)
        {
            throw new NotImplementedException;
        }

        /// <summary>
        /// Calculate and display the minimum, maximum,
        /// and mean mark for all the students
        /// </summary>
        public void CalculateStats()
        {
            throw new NotImplementedException;
        }
    }
}
