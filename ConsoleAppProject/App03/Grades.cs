using System.ComponentModel;

namespace ConsoleAppProject.Helpers


{
    /// <summary>
    /// Grade A is First Class   : 70 - 100
    /// Grade B is Upper Second  : 60 - 69
    /// Grade C is Lower Second  : 50 - 59
    /// Grade D is Third Class   : 40 - 49
    /// Grade E is Fourth Class  : 30 - 39
    /// Grade F is Fail          :  0 - 29
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
        A
    }

    public enum Grade
    {
        F, E, D, C, B, A
    }
}
