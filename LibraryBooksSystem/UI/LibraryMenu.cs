using LibraryBooksSystem.Models;
using LibraryBooksSystem.Services;

namespace LibraryBooksSystem.UI;

// Owner: Kamel (Console Menu / UI)
public class LibraryMenu
{
    private readonly LibraryService _library;
    private readonly ValidationService _validation;

    public LibraryMenu(LibraryService library, ValidationService validation)
    {
        _library = library;
        _validation = validation;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            ShowMenu();
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    ShowBooks(_library.GetAllBooks(), "All Books");
                    break;
                case "3":
                    SearchBook();
                    break;
                case "4":
                    ShowBooks(_library.GetAvailableBooks(), "Available Books");
                    break;
                case "5":
                    BorrowBook();
                    break;
                case "6":
                    ReturnBook();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("=== Library Books System ===");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. View All Books");
        Console.WriteLine("3. Search by Title");
        Console.WriteLine("4. View Available Books");
        Console.WriteLine("5. Borrow Book");
        Console.WriteLine("6. Return Book");
        Console.WriteLine("7. Exit");
        Console.Write("Choose: ");
    }

    private void AddBook()
    {
        Console.Write("Book ID: ");
        if (!_validation.TryReadInt(Console.ReadLine(), out int id) || !_validation.IsValidId(id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        if (_validation.IsDuplicateId(_library.Books, id))
        {
            Console.WriteLine("A book with this ID already exists.");
            return;
        }

        Console.Write("Title: ");
        string? title = Console.ReadLine();
        if (!_validation.IsValidText(title))
        {
            Console.WriteLine("Invalid title.");
            return;
        }

        Console.Write("Author: ");
        string? author = Console.ReadLine();
        if (!_validation.IsValidText(author))
        {
            Console.WriteLine("Invalid author.");
            return;
        }

        var book = new Book
        {
            Id = id,
            Title = title?.Trim() ?? "",
            Author = author?.Trim() ?? ""
        };

        _library.AddBook(book, out string message);
        Console.WriteLine(message);
    }

    private void SearchBook()
    {
        Console.Write("Enter title to search: ");
        string? title = Console.ReadLine();

        if (!_validation.IsValidText(title))
        {
            Console.WriteLine("Invalid search text.");
            return;
        }

        ShowBooks(_library.SearchByTitle(title!.Trim()), "Search Results");
    }

    private void BorrowBook()
    {
        Console.Write("Book ID to borrow: ");
        if (!_validation.TryReadInt(Console.ReadLine(), out int id) || !_validation.IsValidId(id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        _library.BorrowBook(id, out string message);
        Console.WriteLine(message);
    }

    private void ReturnBook()
    {
        Console.Write("Book ID to return: ");
        if (!_validation.TryReadInt(Console.ReadLine(), out int id) || !_validation.IsValidId(id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        _library.ReturnBook(id, out string message);
        Console.WriteLine(message);
    }

    private void ShowBooks(List<Book> books, string title)
    {
        Console.WriteLine($"\n--- {title} ---");

        if (books.Count == 0)
        {
            Console.WriteLine("No books found.");
            return;
        }

        foreach (var b in books)
        {
            string status = b.IsAvailable ? "Available" : "Borrowed";
            Console.WriteLine($"[{b.Id}] {b.Title} by {b.Author} - {status}");
        }
    }
}