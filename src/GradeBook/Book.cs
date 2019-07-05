using System;
using System.IO;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject{
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name{
            get;
            set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        // public virtual event GradeAddedDelegate GradeAdded;
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();

        // public virtual Statistics GetStatistics()
        // {
        //     throw new NotImplementedException();
        // }
    }

    public class InMemoryBook : Book
    {
        //public List<double> grades;
        private List<double> grades;

        // DEFINING PROPERTIES
        // OLDER WAY:

        // public string Name{
        //     //GETTER
        //     get{
        //         return name;
        //     }
        //     //SETTER
        //     set{
        //         if(!String.IsNullOrEmpty(value)){
        //             name = value;   //value is an implicit variable that already exists
        //         }
        //     }
        // }
        // private string name;

        // NEWER WAY: we don't need to define 'name' explicitly or write anything inside get and set blocks
        // Known as AUTO PROPERTY

        //WE SHALL INHERIT THIS FROM NamedObject CLASS
        
        /*public string Name{
            get;
            set;
            //private set;    //after constructing the name of the book we won't be able to change it
        }*/

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        //DEFINING readonly and const FIELDS (constants):
        readonly string category="Science";   //can only initialise or change in the CONSTRUCTOR
        public const string CLASSES="11th";    //cannot be changed anywhere, not even in the constructor
        //convention - const values are written in CAPS, they can be made public as no one can change them
        //const members are treated as static members, so to access -> Book.CLASSES, objname.CLASSES won't work

        public void AddGrade(char letter){  //the return type is not a part of method signature
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

        public override void AddGrade(double grade){
            if(grade <= 100 && grade>=0)
            {
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                // Console.WriteLine("Invalid value");
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics(){
            var result = new Statistics();
            // result.Average = 0.0;
            // result.High = double.MinValue;
            // result.Low = double.MaxValue;
            
            foreach(var number in grades){
                result.Add(number);
                //result.High=Math.Max(number,result.High);
                //result.Low=Math.Min(number,result.Low);
                //result.Average += number;
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

            //result.Average /= grades.Count;

            // switch(result.Average){
            //     case var d when d>=90.0:
            //         result.Letter = 'A';
            //         break;
            //     case var d when d>=80.0:
            //         result.Letter = 'B';
            //         break;
            //     case var d when d>=70.0:
            //         result.Letter = 'C';
            //         break;
            //     case var d when d>=60.0:
            //         result.Letter = 'D';
            //         break;
            //     default:
            //         result.Letter = 'F';
            //         break;
            // }
            // done:
            return result;
        }
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            // var writer = File.AppendText($"{Name}.txt");
            // writer.WriteLine(grade);
            // writer.Close(); //or writer.Dispose(); -- from the inbuilt interface IDisposable that does garbage collection

            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }   
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line!=null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}