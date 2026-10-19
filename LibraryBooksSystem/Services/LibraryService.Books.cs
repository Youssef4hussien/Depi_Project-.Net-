using LibraryBooksSystem.Models;

namespace LibraryBooksSystem.Services;

// Owner: Mostafa (Book Management)
public partial class LibraryService
{
    public bool AddBook(Book? book, out string message)
    {
        if (book is null)
        {
            message = "Book details are required.";
            return false;
        }

        if (book.Id <= 0)
        {
            message = "Invalid book ID.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(book.Title))
        {
            message = "Book title is required.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(book.Author))
        {
            message = "Book author is required.";
            return false;
        }

        if (_books.Any(existingBook => existingBook.Id == book.Id))
        {
            message = "A book with this ID already exists.";
            return false;
        }

        book.Title = book.Title.Trim();
        book.Author = book.Author.Trim();
        _books.Add(book);

        message = "Book added successfully.";
        return true;
    }

    public List<Book> GetAllBooks() => _books.ToList();

    public List<Book> SearchByTitle(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return [];
        }

        string searchTerm = title.Trim();
        return _books
            .Where(book => book.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Book> GetAvailableBooks() => _books
        .Where(book => book.IsAvailable)
        .ToList();
}
