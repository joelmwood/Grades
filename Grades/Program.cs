﻿using System;
using System.IO;

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
            //book.Name = null;

            GetBookName(book);

            Console.WriteLine("");

            AddGrades(book);

            SaveGrades(book);

            Console.WriteLine("");

            WriteResults(book);

            Console.WriteLine("");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);

            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            Console.WriteLine("All Grades:");
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(70.5f);
            book.AddGrade(40);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Enter a GradeBook Name:");
                book.Name = Console.ReadLine();
                Console.WriteLine(book.Name);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1:F2}", description, result);
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void OnNameChange(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"GradeBook changing name from {args.ExistingName} to {args.NewName}.");
        }
    }
}
