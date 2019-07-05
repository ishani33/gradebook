using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var p = new Program();
            p.Main(args); //doesn't work because Main method is static
            Program.Main(args); //now the program would go into infinite loop because Main calls Main
            */

            IBook book = new DiskBook("Class X");
            book.GradeAdded += OnGradeAdded; //subscribing an event
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded; //unsubscribing an event

            // book.GradeAdded = null; //this is not allowed since we are not using pure delegates. Using events puts some restrictions on the delegates. (refer notes)

            // book.AddGrade(89.1);
            // book.AddGrade(98.3);
            // book.AddGrade(65.6);
            //book.grades.Add(45.6);

            EnterGrades(book);

            var stats = book.GetStatistics();

            // Console.WriteLine(InMemoryBook.category);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average}.");
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            Console.WriteLine($"The letter grade is {stats.Letter}.");


            /*var x=4.1;
                var y=2.1; //can also do double y=2.1
                var result=x+y;
                Console.WriteLine(result);
                System.Console.WriteLine("here");*/

            // double[] numbers = new double[3];
            // numbers[0] = 12.7;
            // numbers[1] = 3.2;
            // numbers[2] = 8.9;

            //var numbers = new[] {12.5, 3.1, 9.9};

            //List<double> grades = new List<double>();   //dynamic Data Structure
            //var grades = new List<double>(); //can also initialise like this

            // grades.Add(23.1);
            // grades.Add(43.3);
            // grades.Add(34.8);

            // var result=0.0;
            // foreach(var number in grades){
            //     result+=number;
            // }
            // result /= grades.Count;
            // Console.WriteLine($"The average grade is {result:N1}."); //N1 means upto 1 place after decimal

            // if(args.Length > 0)
            // {
            //     //Console.WriteLine("Hello "+args[0]+"!");
            //     Console.WriteLine($"Hello {args[0]}!");          //WRITELINE METHOD IS STATIC IN NATURE
            // }
            // else
            // {
            //     Console.WriteLine("Hello!");
            // }
        }

        private static void EnterGrades(IBook book)
        {
            Console.WriteLine("Please enter the grades. Press 'Q' to quit and display results.");
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Q"))
                {
                    break;
                }
                try
                {
                    var inputGrade = double.Parse(input);
                    book.AddGrade(inputGrade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                } //to rethrow the exception we can write throw; below Console.WriteLine statement, this could be done if we didn't know the exception type
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally //a piece of block which always executes irrespective of any exceptions
                {
                    Console.WriteLine("*");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args){
            Console.WriteLine("A grade was added.");
        }
    }
}
