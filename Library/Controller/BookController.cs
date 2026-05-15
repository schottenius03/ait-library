using System;
using System.Collections.Generic;
using System.Data;
using Model;

namespace Controller
{
    public class BookController
    {
        public List<BookDTO> GetAllBooks()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Book[] books = webService.GetAllBooks();

            List<BookDTO> listOfBooks = new List<BookDTO>();
            if (books != null)
            {
                foreach (var book in books)
                {
                    listOfBooks.Add(new BookDTO
                    {
                        Isbn = book.Isbn,
                        BookName = book.BookName,
                        Author = book.Author,
                        Category = book.Category,
                        Language = book.Language,
                        PublishYear = book.PublishYear,
                        Pages = book.Pages,
                        Publisher = book.Publisher
                    });
                }
            }

            return listOfBooks;
        }

        public List<BookDTO> GetAllBooksAvailable()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Book[] books = webService.GetAllBooksAvailable();

            List<BookDTO> listOfBooks = new List<BookDTO>();
            if (books != null)
            {
                foreach (var book in books)
                {
                    listOfBooks.Add(new BookDTO
                    {
                        Isbn = book.Isbn,
                        BookName = book.BookName,
                        Author = book.Author,
                        Category = book.Category,
                        Language = book.Language,
                        PublishYear = book.PublishYear,
                        Pages = book.Pages,
                        Publisher = book.Publisher
                    });
                }
            }

            return listOfBooks;
        }

        public List<BookDTO> GetAllBorrowedBooks()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Book[] books = webService.GetAllBorrowedBooks();

            List<BookDTO> listOfBooks = new List<BookDTO>();
            if (books != null)
            {
                foreach (var book in books)
                {
                    listOfBooks.Add(new BookDTO
                    {
                        Isbn = book.Isbn,
                        BookName = book.BookName,
                        Author = book.Author,
                        Category = book.Category,
                        Language = book.Language,
                        PublishYear = book.PublishYear,
                        Pages = book.Pages,
                        Publisher = book.Publisher
                    });
                }
            }

            return listOfBooks;
        }

        public List<BookDTO> SearchByBookName(string name)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Book[] books = webService.SearchByBookName(name);

            List<BookDTO> listOfBooks = new List<BookDTO>();
            if (books != null)
            {
                foreach (var book in books)
                {
                    listOfBooks.Add(new BookDTO
                    {
                        Isbn = book.Isbn,
                        BookName = book.BookName,
                        Author = book.Author,
                        Category = book.Category,
                        Language = book.Language,
                        PublishYear = book.PublishYear,
                        Pages = book.Pages,
                        Publisher = book.Publisher
                    });
                }
            }

            return listOfBooks;
        }

        public int AddBook(string isbn, string name, int author, int category, int language, int year, int pages, string publisher)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.AddBook(isbn, name, author, category, language, year, pages, publisher);
        }

        public int UpdateBook(string name, int author, int category, int language, int year, int pages, string publisher, string isbn)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.UpdateBook(name, author, category, language, year, pages, publisher, isbn);
        }

        public int DeleteBook(string isbn, string name, int author, int category, int language, int year, int pages, string publisher)
        {
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.DeleteBook(isbn, name, author, category, language, year, pages, publisher);
        }
    }
}
