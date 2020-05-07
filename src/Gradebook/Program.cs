using System;
using System.Collections.Generic;

namespace Gradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Polina's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            // Console.WriteLine("Do you want to enter some grades? (y/n)?");
            // var answer = Console.ReadLine();
            // while (answer == "y")
            // {
            //     Console.WriteLine("Please enter your grade here");
            //     var grade = double.Parse(Console.ReadLine());
            //     book.AddGrade(grade);
            //     Console.WriteLine("Do you want to enter more grades?(y/n)");
            //     answer = Console.ReadLine();
            // }

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The letter is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grad or 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("***");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade've been added");

        }
    }
}
