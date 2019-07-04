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

            var book = new Book("Class X");
            book.AddGrade(89.1);
            book.AddGrade(98.3);
            book.AddGrade(65.6);
            //book.grades.Add(45.6);
            var stats = book.GetStatistics();

            Console.WriteLine($"The average grade is {stats.Average}.");
            Console.WriteLine($"The lowest grade is {stats.Low}.");
            Console.WriteLine($"The highest grade is {stats.High}.");
            
            
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
    }
}
