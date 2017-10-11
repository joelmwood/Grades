using System;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello, this is the Grade Book Program.");

            GradeBook book = new GradeBook();
            book.NameChanged += new NameChangedDelegate(OnNameChange);

            book.Name = "Scott's Grade Book";
            book.Name = "Grade Book";

            Console.WriteLine("");

            book.AddGrade(91);
            book.AddGrade(70.5f);
            book.AddGrade(40);

            Console.WriteLine(book.Name);

            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);

            Console.WriteLine("");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

        static void OnNameChange(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"GradeBook changing name from {args.ExistingName} to {args.NewName}.");
        }
    }
}
