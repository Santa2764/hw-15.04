using System;

class Student
{
    public string Name { get; set; }
    public double AverageGrade { get; set; }
}

// делегат для критерия сортировки
delegate double RateCriteria(Student student);

class Program
{
    static void Main(string[] args)
    {
        Student[] students = new Student[]
        {
            new Student() { Name = "Alice", AverageGrade = 4.5 },
            new Student() { Name = "Bob", AverageGrade = 3.2 },
            new Student() { Name = "Charlie", AverageGrade = 4.1 },
            new Student() { Name = "Dave", AverageGrade = 3.8 },
            new Student() { Name = "Eve", AverageGrade = 4.9 }
        };

        SortStudentsByGrade(students, s => s.AverageGrade);

        foreach (Student student in students)
        {
            Console.WriteLine("{0}: {1}", student.Name, student.AverageGrade);
        }
    }

    // метод сортировки, использующий делегат
    static void SortStudentsByGrade(Student[] students, RateCriteria rateCriteria)
    {
        Array.Sort(students, (s1, s2) => rateCriteria(s2).CompareTo(rateCriteria(s1)));
    }
}
