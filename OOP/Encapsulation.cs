using System;
using System.Collections.Generic;

// Book class implementing Encapsulation
class Book
{
    private string title;
    private string author;
    private bool isAvailable;

    public Book(string title, string author)
    {
        this.title = title;
        this.author = author;
        this.isAvailable = true;
    }

    // Public getters to access private fields
    public string GetTitle() { return title; }
    public string GetAuthor() { return author; }
    public bool GetAvailability() { return isAvailable; }

    // Public methods to control access to private fields
    public void Borrow()
    {
        if (isAvailable)
        {
            isAvailable = false;
            Console.WriteLine($"{title} has been borrowed.");
        }
        else
        {
            Console.WriteLine($"{title} is currently not available.");
        }
    }

    public void Return()
    {
        isAvailable = true;
        Console.WriteLine($"{title} has been returned.");
    }
}

// Library class demonstrating encapsulation
class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book added: {book.GetTitle()} by {book.GetAuthor()}");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Library Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.GetTitle()} by {book.GetAuthor()} - {(book.GetAvailability() ? "Available" : "Not Available")}");
        }
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Library library = new Library();

        // Adding books
        Book book1 = new Book("Pride and Prejudice", "Jane Austen");
        Book book2 = new Book("Great Expectations", "Charles Dickens");
        library.AddBook(book1);
        library.AddBook(book2);

        // Borrowing and returning books
        book1.Borrow();
        book2.Borrow();
        book1.Return();

        // Display books
        library.DisplayBooks();
    }
}
