using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        //public List<double> grades;
        private List<double> grades;
        public string Name;

        public Book(string name){
            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter){
            switch(letter){
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade){
            if(grade <= 100 && grade>=0)
            {
                grades.Add(grade);
            }
            else
            {
                // Console.WriteLine("Invalid value");
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public Statistics GetStatistics(){
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            
            foreach(var number in grades){
                result.High=Math.Max(number,result.High);
                result.Low=Math.Min(number,result.Low);
                result.Average += number;
            }

            /* Using DO-WHILE Loop */

            // var index = 0;
            // do{
            //     result.High=Math.Max(grades[index],result.High);
            //     result.Low=Math.Min(grades[index],result.Low);
            //     result.Average += grades[index];
            //     index++;
            // }while(index < grades.Count) //THIS LOOP MIGHT FAIL IF THE LIST IS EMPTY; so can use WHILE loop instead


            /* Using FOR loop */

            // for(var index=0; index<grades.Count; index++){
                // if (grades[index] == 42.1){
                //     break;
                // }
                // if (grades[index] == 45.1){
                //     continue;
                // }
                // if (grades[index] == 52.1){
                //     goto done;
                // }
            //     result.High=Math.Max(grades[index],result.High);
            //     result.Low=Math.Min(grades[index],result.Low);
            //     result.Average += grades[index];
            //     index++;
            // }

            result.Average /= grades.Count;

            switch(result.Average){
                case var d when d>=90.0:
                    result.Letter = 'A';
                    break;
                case var d when d>=80.0:
                    result.Letter = 'B';
                    break;
                case var d when d>=70.0:
                    result.Letter = 'C';
                    break;
                case var d when d>=60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            // done:
            return result;
        }
    }
}