using System;

class Person 
{
    protected string Name;
    protected int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Student : Person 
{
    private string StudentID;

    public Student(string name, int age, string studentID) : base(name, age)
    {
        StudentID = studentID;
    }

    public void ShowStudentDetails()
    {
        ShowDetails();
        Console.WriteLine($"Student ID: {StudentID}");
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student("Ali", 21, "S-1001");
        student.ShowStudentDetails();
    }
}
