using System;
using System.Collections.Generic;

// Abstract class representing a Person
abstract class Person
{
    protected string Name;
    protected int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    // Abstract method - must be implemented by derived classes
    public abstract void ShowDetails();
}

// Interface defining salary-related behavior
interface ISalary
{
    void CalculateSalary();
}

// Student class inheriting from Person
class Student : Person
{
    private string StudentID;
    private double GPA;

    public Student(string name, int age, string studentID, double gpa) : base(name, age)
    {
        StudentID = studentID;
        GPA = gpa;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Student: {Name}, Age: {Age}, ID: {StudentID}, GPA: {GPA}");
    }
}

// Teacher class inheriting from Person and implementing ISalary
class Teacher : Person, ISalary
{
    private string Subject;
    private double MonthlySalary;

    public Teacher(string name, int age, string subject, double salary) : base(name, age)
    {
        Subject = subject;
        MonthlySalary = salary;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Teacher: {Name}, Age: {Age}, Subject: {Subject}");
    }

    public void CalculateSalary()
    {
        Console.WriteLine($"{Name}'s Monthly Salary: {MonthlySalary}");
    }
}

// Administrative Staff class inheriting from Person and implementing ISalary
class AdminStaff : Person, ISalary
{
    private string Department;
    private double Salary;

    public AdminStaff(string name, int age, string department, double salary) : base(name, age)
    {
        Department = department;
        Salary = salary;
    }

    public override void ShowDetails()
    {
        Console.WriteLine($"Admin Staff: {Name}, Age: {Age}, Department: {Department}");
    }

    public void CalculateSalary()
    {
        Console.WriteLine($"{Name}'s Salary: {Salary}");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        List<Person> people = new List<Person>();

        Student student1 = new Student("Ali", 20, "S123", 3.8);
        Teacher teacher1 = new Teacher("Dr. Ayesha", 45, "Mathematics", 120000);
        AdminStaff admin1 = new AdminStaff("Mr. Khan", 50, "Finance", 90000);

        people.Add(student1);
        people.Add(teacher1);
        people.Add(admin1);

        foreach (var person in people)
        {
            person.ShowDetails();
        }

        Console.WriteLine();

        // Handling Salaries
        List<ISalary> salaryPeople = new List<ISalary>() { teacher1, admin1 };
        foreach (var staff in salaryPeople)
        {
            staff.CalculateSalary();
        }
    }
}
