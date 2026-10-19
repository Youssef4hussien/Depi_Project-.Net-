using LibraryBooksSystem.Models;

namespace LibraryBooksSystem.Services;

// Owner: Ego (Validation & Testing)
public class ValidationService
{
    public bool TryReadInt(string? input, out int value)
    {
        return int.TryParse(input, out value); 
    }
    public bool IsValidId(int id)
    { 
        return id > 0; 
    }
    public bool IsValidText(string? text) 
    {
        return !string.IsNullOrWhiteSpace(text);
    }
    public bool IsDuplicateId(IEnumerable<Book> books, int id)
    {
        return books.Any(book => book.Id == id);
    }
}
