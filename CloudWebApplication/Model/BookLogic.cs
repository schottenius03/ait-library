using System;
using System.Collections.Generic;
using System.Data;

namespace Model
{
    public class BookLogic
    {
        public List<Book> GetAllBooks()
        {
            BookDAO dao = new BookDAO();
            return dao.GetAllBooks();
        }

        public List<Book> GetAllBooksAvailable()
        {
            BookDAO dao = new BookDAO();
            return dao.GetAllBooksAvailable();
        }

        public List<Book> GetAllBorrowedBooks()
        {
            BookDAO dao = new BookDAO();
            return dao.GetAllBorrowedBooks();
        }

        public List<Book> SearchByBookName(string bookName)
        {
            BookDAO dao = new BookDAO();
            return dao.SearchByBookName(bookName);
        }

        public int AddBook(string isbn, string bookName, int author, int category, int language, int year, int pages, string publisher)
        {
            BookDAO dao = new BookDAO();
            return dao.AddBook(isbn, bookName, author, category, language, year, pages, publisher);
        }

        public int UpdateBook(string bookName, int author, int category, int language, int year, int pages, string publisher, string isbn)
        {
            BookDAO dao = new BookDAO();
            return dao.UpdateBook(bookName, author, category, language, year, pages, publisher, isbn);
        }

        public int DeleteBook(string isbn, string bookName, int author, int category, int language, int year, int pages, string publisher)
        {
            BookDAO dao = new BookDAO();
            return dao.DeleteBook(isbn, bookName, author, category, language, year, pages, publisher);
        }

        public int DeleteBookAvailable(string isbn)
        {
            BookDAO dao = new BookDAO();
            return dao.DeleteBookAvailable(isbn);
        }
    }
}
