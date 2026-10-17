using LibraryBooksSystem.Services;

namespace LibraryBooksSystem.UI;

// Owner: Abdelmohsen (Console Menu / UI)
public class LibraryMenu
{
    private readonly LibraryService _library;
    private readonly ValidationService _validation;

    public LibraryMenu(LibraryService library, ValidationService validation)
    {
        _library = library;
        _validation = validation;
    }

    public void Run() => throw new NotImplementedException();
}
