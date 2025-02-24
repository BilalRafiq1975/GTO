using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPatternDemo
{
    // The Model 
    public class Book
    {
        public string Title { get; set; }

        public Book(string title)
        {
            Title = title;
        }
    }

    // The Repository Interface 
    public interface IBookRepository
    {
        void Add(Book book);
        Book Get(string title);
        List<Book> GetAll();
    }

    // The Repository (the helper using a List)
    public class BookRepository : IBookRepository
    {
        private List<Book> _books; // data source

        public BookRepository()
        {
            _books = new List<Book>(); // Start with an empty list
        }

        public void Add(Book book)
        {
            _books.Add(book); // Add to the list
        }

        public Book Get(string title)
        {
            return _books.FirstOrDefault(b => b.Title == title); // Find by title
        }

        public List<Book> GetAll()
        {
            return _books; // Return all books
        }
    }

    // The App (using the repository)
    class Program
    {
        static void Main(string[] args)
        {
            // Create the repository
            IBookRepository bookManager = new BookRepository();

            // Add a book
            bookManager.Add(new Book("Harry Potter"));

            // Find a book
            var book = bookManager.Get("Harry Potter");
            if (book != null)
            {
                Console.WriteLine($"Found: {book.Title}"); // Output: Found: Harry Potter
            }

            // Show all books
            var allBooks = bookManager.GetAll();
            foreach (var b in allBooks)
            {
                Console.WriteLine($"Book: {b.Title}"); // Output: Book: Harry Potter
            }
        }
    }
}
