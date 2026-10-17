using LibraryBooksSystem.Services;
using LibraryBooksSystem.UI;

var menu = new LibraryMenu(new LibraryService(), new ValidationService());
menu.Run();
