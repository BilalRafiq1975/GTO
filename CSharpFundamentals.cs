using System;

namespace ManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // C# Output
            Console.WriteLine("Welcome to the Employee Management System");

            // C# Variables
            string companyName = "DPL";
            int totalEmployees = 100;
            double revenue = 500000.75;

            // Constants
            const string CEO = "Syed Ahmed";

            // Display Variables
            Console.WriteLine("Company: " + companyName + ", Employees: " + totalEmployees + ", Revenue: " + revenue);

            // Multiple Variables
            int maleEmployees = 60, femaleEmployees = 40;
            Console.WriteLine("Male Employees: " + maleEmployees + ", Female Employees: " + femaleEmployees);

            // Identifiers (Proper naming conventions used)
            int employeeID = 101;

            // C# Data Types
            bool isHiring = true;
            char grade = 'A';
            
            // Type Casting
            double salary = 55000.50;
            int roundedSalary = (int)salary; // Explicit casting
            string salaryString = salary.ToString(); // Implicit casting

            // User Input
            Console.Write("Enter new employee name: ");
            string newEmployee = Console.ReadLine();

            // Operators
            int newTotal = totalEmployees + 1; // Arithmetic Operator
            bool isBigCompany = totalEmployees > 50; // Comparison Operator
            bool hiringDecision = isHiring && isBigCompany; // Logical Operator

            // C# Math
            Console.WriteLine("Max salary package: " + Math.Max(50000, 75000));

            // C# Strings
            string welcomeMessage = $"Welcome, {newEmployee}, to {companyName}"; // String Interpolation
            Console.WriteLine(welcomeMessage);

            // Booleans
            bool isEmployeeActive = true;

            // If-Else
            if (newTotal > 100)
            {
                Console.WriteLine("Company size is large.");
            }
            else if (newTotal > 50)
            {
                Console.WriteLine("Company size is medium.");
            }
            else
            {
                Console.WriteLine("Company size is small.");
            }

            // Switch Case
            switch (grade)
            {
                case 'A':
                    Console.WriteLine("Excellent Employee");
                    break;
                case 'B':
                    Console.WriteLine("Good Employee");
                    break;
                default:
                    Console.WriteLine("Average Employee");
                    break;
            }

            // Loops
            int i = 1;
            while (i <= 3)
            {
                Console.WriteLine("Processing payroll... " + i);
                i++;
            }

            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("Performance review pending: Employee " + j);
            }

            // Break and Continue
            for (int k = 1; k <= 5; k++)
            {
                if (k == 3) continue;
                Console.WriteLine("Processing employee: " + k);
            }

            // Arrays
            string[] departments = { "HR", "IT", "Finance" };
            foreach (string dept in departments)
            {
                Console.WriteLine("Department: " + dept);
            }

            // Multidimensional Arrays
            int[,] employeeData = { { 101, 102 }, { 201, 202 } };
            Console.WriteLine("Employee ID at row 1, column 2: " + employeeData[0, 1]);
        }
    }
}
