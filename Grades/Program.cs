using System;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, this is the Grade Book Program.");

            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(70);
            book.AddGrade(40);

            GradeStatistics stats = book.ComputeStatistics();

            Console.WriteLine("Highest Grade: " + stats.HighestGrade);
            Console.WriteLine("Lowest Grade: " + stats.LowestGrade);
            Console.WriteLine("Average Grade: " + stats.AverageGrade);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
