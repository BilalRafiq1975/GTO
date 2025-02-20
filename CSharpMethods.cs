using System;

namespace ManagementSystem
{
    class EmployeeManager
    {
        // C# Method: A simple method to display a message
        static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Employee Management System!");
        }

        // C# Method with Parameters
        static void AddEmployee(string name, int age, string department)
        {
            Console.WriteLine($"Employee Added: Name: {name}, Age: {age}, Department: {department}");
        }

        // Default Parameter Value
        static void AssignDepartment(string name, string department = "General")
        {
            Console.WriteLine($"{name} has been assigned to the {department} department.");
        }

        // Method with Return Value
        static double CalculateBonus(double salary, double bonusPercentage)
        {
            return salary * (bonusPercentage / 100);
        }

        // Named Arguments
        static void DisplayEmployeeInfo(string name, int age, string department)
        {
            Console.WriteLine($"Employee Info -> Name: {name}, Age: {age}, Department: {department}");
        }

        // Method Overloading (Same method name, different parameters)
        static void PromoteEmployee(string name)
        {
            Console.WriteLine($"{name} has been promoted!");
        }

        static void PromoteEmployee(string name, string newTitle)
        {
            Console.WriteLine($"{name} has been promoted to {newTitle}!");
        }

        static void Main(string[] args)
        {
            // Calling Methods
            WelcomeMessage();
            AddEmployee("Bilal Rafiq", 22, "SE");
            AssignDepartment("Ahmed");
            AssignDepartment("Ahmed", "HR");
            
            double bonus = CalculateBonus(50000, 10);
            Console.WriteLine($"Bonus Amount: {bonus}");
            
            DisplayEmployeeInfo(name: "Qasim", age: 25, department: "Finance");
            
            PromoteEmployee("Ahmed");
            PromoteEmployee("Ali", "Senior Manager");
        }
    }
}
