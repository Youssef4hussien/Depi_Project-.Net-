using LibraryBooksSystem.Models;

namespace LibraryBooksSystem.Services;

// Owner: Mohamed (Borrow & Return)
public partial class LibraryService
{
    // Borrow a book by ID
    public bool BorrowBook(int id, out string message)
    {
        // Check that the ID is valid
        if (id <= 0)
        {
            message = "Invalid book ID.";
            return false;
        }

        // Find the book using the central lookup method
        var book = GetBookById(id);

        // Check that the book exists
        if (book == null)
        {
            message = "Book not found.";
            return false;
        }

        // Check that the book is available
        if (!book.IsAvailable)
        {
            message = "Book is already borrowed.";
            return false;
        }

        // Mark the book as borrowed
        book.IsAvailable = false;
        message = "Book borrowed successfully.";
        return true;
    }

    // Return a book by ID
    public bool ReturnBook(int id, out string message)
    {
        // Check that the ID is valid
        if (id <= 0)
        {
            message = "Invalid book ID.";
            return false;
        }

        // Find the book using the central lookup method
        var book = GetBookById(id);

        // Check that the book exists
        if (book == null)
        {
            message = "Book not found.";
            return false;
        }

        // Check that the book is actually borrowed
        if (book.IsAvailable)
        {
            message = "Book is already available (not borrowed).";
            return false;
        }

        // Mark the book as available again
        book.IsAvailable = true;
        message = "Book returned successfully.";
        return true;
    }
}