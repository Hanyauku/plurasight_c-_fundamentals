using System;
using System.Collections.Generic;

namespace Gradebook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            foreach (var grade in Grades)
            {
                result.Add(grade);
            }
            return result;
        }

        public List<double> Grades;
        // radonly can be set only inside constructors
        public const string CATEGORY = "Science";
    }
}