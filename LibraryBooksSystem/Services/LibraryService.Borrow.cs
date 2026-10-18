using LibraryBooksSystem.Models;

namespace LibraryBooksSystem.Services;

// Owner: Mohamed (Borrow & Return)
public partial class LibraryService
{
    // Borrow a book by ID
    public bool BorrowBook(int id, out string message)
    {
        // «· Õﬁﬁ „‰ ÊÃÊœ «·ﬂ «» «’·« 
        if (id <= 0)
        {
            message = "Invalid book ID.";
            return false;
        }

        // »‰” Œœ„ «·œ«·… «·Ã«Â“… «··Ì » œÊ— ⁄‰ √Ê· ﬂ «» »Ìÿ«»ﬁ —ﬁ„ «·ﬂ «» «··Ì « »⁄ ·‰«
        var book = GetBookById(id);

        // ·Ê „›Ì‘ ﬂ «» »«·—ﬁ„ œÂ
        if (book == null)
        {
            message = "Book not found.";
            return false;
        }

        // ·Ê «·ﬂ «» „” ⁄«—
        if (!book.IsAvailable)
        {
            message = "Book is already borrowed.";
            return false;
        }

        // ≈⁄«—… «·ﬂ «» 
        book.IsAvailable = false;
        message = "Book borrowed successfully.";
        return true;
    }

    // Return a book by ID
    public bool ReturnBook(int id, out string message)
    {
        // «· Õﬁﬁ „‰ ÊÃÊœ «·ﬂ «» «’·«
        if (id <= 0)
        {
            message = "Invalid book ID.";
            return false;
        }

        // »‰” Œœ„ «·œ«·… «·Ã«Â“… «··Ì » œÊ— ⁄‰ √Ê· ﬂ «» »Ìÿ«»ﬁ —ﬁ„ «·ﬂ «» «··Ì « »⁄ ·‰«
        var book = GetBookById(id);

        // ·Ê „›Ì‘ ﬂ «» »«·—ﬁ„ œÂ
        if (book == null)
        {
            message = "Book not found.";
            return false;
        }

        // ·Ê «·ﬂ «» „ «Õ √’·« Ê„‘ „” ⁄«—
        if (book.IsAvailable)
        {
            message = "Book is already available (not borrowed).";
            return false;
        }

        // ≈—Ã«⁄ «·ﬂ «» 
        book.IsAvailable = true;
        message = "Book returned successfully.";
        return true;
    }
}
