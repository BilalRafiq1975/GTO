using System;

class Course 
{
    protected string CourseName;
    protected string Instructor;

    public Course(string courseName, string instructor)
    {
        CourseName = courseName;
        Instructor = instructor;
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine($"Course: {CourseName}, Instructor: {Instructor}");
    }
}

class OnlineCourse : Course 
{
    private string Platform;

    public OnlineCourse(string courseName, string instructor, string platform) : base(courseName, instructor)
    {
        Platform = platform;
    }

    public void ShowOnlineCourseDetails()
    {
        ShowCourseDetails();
        Console.WriteLine($"Platform: {Platform}");
    }
}

class OnCampusCourse : Course 
{
    private string RoomNumber;

    public OnCampusCourse(string courseName, string instructor, string roomNumber) : base(courseName, instructor)
    {
        RoomNumber = roomNumber;
    }

    public void ShowOnCampusCourseDetails()
    {
        ShowCourseDetails();
        Console.WriteLine($"Room Number: {RoomNumber}");
    }
}

class Program
{
    static void Main()
    {
        OnlineCourse online = new OnlineCourse("Data Structures", "Dr. Adeel", "Udemy");
        OnCampusCourse campus = new OnCampusCourse("Algorithms", "Dr. Hassan", "Room A-101");

        Console.WriteLine("Online Course Details:");
        online.ShowOnlineCourseDetails();

        Console.WriteLine("\nOn-Campus Course Details:");
        campus.ShowOnCampusCourseDetails();
    }
}
