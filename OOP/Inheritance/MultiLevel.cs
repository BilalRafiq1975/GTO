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

class Teacher : Person 
{
    protected string Subject;

    public Teacher(string name, int age, string subject) : base(name, age)
    {
        Subject = subject;
    }

    public void ShowTeacherDetails()
    {
        ShowDetails();
        Console.WriteLine($"Subject: {Subject}");
    }
}

class HeadOfDepartment : Teacher 
{
    private string Department;

    public HeadOfDepartment(string name, int age, string subject, string department) : base(name, age, subject)
    {
        Department = department;
    }

    public void ShowHodDetails()
    {
        ShowTeacherDetails();
        Console.WriteLine($"Department: {Department}");
    }
}

class Program
{
    static void Main()
    {
        HeadOfDepartment hod = new HeadOfDepartment("Dr. Usman", 45, "Computer Science", "CS Department");
        hod.ShowHodDetails();
    }
}
