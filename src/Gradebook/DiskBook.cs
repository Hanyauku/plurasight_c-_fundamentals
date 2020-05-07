using System;
using System.IO;

namespace Gradebook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name) { }
        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            // "using" makes sure dispose will be called at the end in any case
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
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
                string line = reader.ReadLine();
                while ((line != null))
                {
                    result.Add(double.Parse(line));
                    line = reader.ReadLine();
                }
            }
            return result;
        }
    }
}