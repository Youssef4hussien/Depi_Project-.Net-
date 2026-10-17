using LibraryBooksSystem.Models;

namespace LibraryBooksSystem.Services;

public partial class LibraryService
{
    private readonly List<Book> _books = new();

    public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);
    public IReadOnlyList<Book> Books => _books;
}
