using LibraryBooksSystem.Models;

namespace LibraryBooksSystem.Services;

// Owner: Ego (Validation & Testing)
public class ValidationService
{
    public bool TryReadInt(string? input, out int value) => throw new NotImplementedException();
    public bool IsValidId(int id) => throw new NotImplementedException();
    public bool IsValidText(string? text) => throw new NotImplementedException();
    public bool IsDuplicateId(IEnumerable<Book> books, int id) => throw new NotImplementedException();
}
