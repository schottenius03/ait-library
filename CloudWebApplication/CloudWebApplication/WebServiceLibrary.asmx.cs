using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;

namespace CloudWebApplication
{
    /// <summary>
    /// Summary description for WebServiceLibrary
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceLibrary : System.Web.Services.WebService
    {
        // authoe methods

        [WebMethod]
        public List<Author> GetAllAuthors()
        {
            AuthorDAO authorDao = new AuthorDAO();
            List<Author> listOfAuthors = authorDao.GetAllAuthors();

            return listOfAuthors;

        }

        [WebMethod]
        public int AddAuthor(string authorName)
        {
            AuthorDAO authorDAO = new AuthorDAO();
            int iStatus = authorDAO.AddAuthor(authorName);
            return iStatus;
        }

        [WebMethod]
        public int UpdateAuthor(string authorName, int authorId)
        {
            AuthorDAO authorDAO = new AuthorDAO();
            int iStatus = authorDAO.UpdateAuthor(authorName, authorId);
            return iStatus;
        }

        [WebMethod]
        public int DeleteAuthor(string authorName)
        {
            AuthorDAO authorDAO = new AuthorDAO();
            int iStatus = authorDAO.DeleteAuthor(authorName);
            return iStatus;
        }

        [WebMethod]
        public List<Author> SearchByAuthor(string sAuthor)
        {
            AuthorDAO authorDao = new AuthorDAO();
            List<Author> listOfAuthors = authorDao.SearchByAuthor(sAuthor);

            return listOfAuthors;

        }

        // book methods

        [WebMethod]
        public List<Book> GetAllBooks()
        {
            BookDAO dao = new BookDAO();
            return dao.GetAllBooks();
        }

        [WebMethod]
        public List<Book> GetAllBooksAvailable()
        {
            BookDAO dao = new BookDAO();
            return dao.GetAllBooksAvailable();
        }

        [WebMethod]
        public List<Book> GetAllBorrowedBooks()
        {
            BookDAO dao = new BookDAO();
            return dao.GetAllBorrowedBooks();
        }

        [WebMethod]
        public List<Book> SearchByBookName(string bookName)
        {
            BookDAO dao = new BookDAO();
            return dao.SearchByBookName(bookName);
        }

        [WebMethod]
        public int AddBook(string isbn, string bookName, int author, int category, int language, int year, int pages, string publisher)
        {
            BookDAO dao = new BookDAO();
            return dao.AddBook(isbn, bookName, author, category, language, year, pages, publisher);
        }

        [WebMethod]
        public int UpdateBook(string bookName, int author, int category, int language, int year, int pages, string publisher, string isbn)
        {
            BookDAO dao = new BookDAO();
            return dao.UpdateBook(bookName, author, category, language, year, pages, publisher, isbn);
        }

        [WebMethod]
        public int DeleteBook(string isbn, string bookName, int author, int category, int language, int year, int pages, string publisher)
        {
            BookDAO dao = new BookDAO();
            return dao.DeleteBook(isbn, bookName, author, category, language, year, pages, publisher);
        }

        [WebMethod]
        public int DeleteBookAvailable(string isbn)
        {
            BookDAO dao = new BookDAO();
            return dao.DeleteBookAvailable(isbn);
        }

        // borrow methods

        [WebMethod]
        public bool AddBorrow(int uid, string isbn)
        {
            BorrowDAO borrowDAO = new BorrowDAO();
            return borrowDAO.AddBorrow(uid, isbn) > 0;
        }

        [WebMethod]
        public DataTable GetBorrowedBooks(int uid)
        {
            BorrowDAO borrowDAO = new BorrowDAO();
            return borrowDAO.GetBorrowedBooksByUser(uid);
        }

        // return methods

        [WebMethod]
        public void UpdateReturn(int uid, string isbn)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            returnDAO.UpdateReturnDate(uid, isbn);
        }

        [WebMethod]
        public DataTable GetActiveBorrowedBooks(int uid)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            return returnDAO.GetActiveBorrowedBooks(uid);
        }

        [WebMethod]
        public void UpdateReturnDate(int uid, string isbn)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            returnDAO.UpdateReturnDate(uid, isbn);
        }

        [WebMethod]
        public bool AddBookBorrow(int uid, string isbn)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            return returnDAO.AddBookBorrow(uid, isbn) > 0;
        }

        // reservation 

        [WebMethod]
        public List<Reservation> GetAllReservations()
        {
            ReservationDAO reservationDAO = new ReservationDAO();
            return reservationDAO.GetAllReservations();
        }

        [WebMethod]
        public bool AddNewReservation(int uid, string isbn)
        {
            ReservationDAO reservationDAO = new ReservationDAO();
            return reservationDAO.AddNewReservation(uid, isbn) > 0;
        }

        [WebMethod]
        public List<Reservation> GetReservationByID(int uid)
        {
            ReservationDAO reservationDAO = new ReservationDAO();
            return reservationDAO.GetReservationByID(uid);
        }

        [WebMethod]
        public bool RemoveReservation(int uid, string isbn)
        {
            ReservationDAO dao = new ReservationDAO();
            return dao.DeleteReservation(uid, isbn);
        }

        // category methods

        [WebMethod]
        public List<Category> GetAllCategories()
        {
            CategoryDAO categoryDao = new CategoryDAO();
            List<Category> listOfCategories = categoryDao.GetAllCategories();

            return listOfCategories;

        }

        [WebMethod]
        public int AddCategory(string categoryName)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            int iStatus = categoryDAO.AddCategory(categoryName);

            return iStatus;
        }

        [WebMethod]
        public int UpdateCategory(string categoryName, int categoryId)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            int iStatus = categoryDAO.UpdateCategory(categoryName, categoryId);
            return iStatus;
        }

        [WebMethod]
        public int DeleteCategory(string categoryName)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            int iStatus = categoryDAO.DeleteCategory(categoryName);
            return iStatus;
        }

        [WebMethod]
        public List<Category> SearchByBookCategory(string sBookCategory)
        {
            CategoryDAO categoryDao = new CategoryDAO();
            List<Category> listOfCategories = categoryDao.SearchByBookCategory(sBookCategory);

            return listOfCategories;

        }

        // language 

        [WebMethod]
        public List<Language> GetAllLanguages()
        {
            LanguageDAO LanguageDAO = new LanguageDAO();
            List<Language> listOfLanguages = LanguageDAO.GetAllLanguages();

            return listOfLanguages;

        }

        [WebMethod]
        public int AddLanguage(string languageName)
        {
            LanguageDAO languageDAO = new LanguageDAO();
            int iStatus = languageDAO.AddLanguage(languageName);
            return iStatus;
        }

        [WebMethod]
        public int UpdateLanguage(string lenguage, int lid)
        {
            LanguageDAO languageDAO = new LanguageDAO();
            int iStatus = languageDAO.UpdateLanguage(lenguage, lid);
            return iStatus;
        }

        [WebMethod]
        public int DeleteLanguage(int lid, string lenguage)
        {

            LanguageDAO languageDAO = new LanguageDAO();
            int iStatus = languageDAO.DeleteLanguage(lid, lenguage);
            return iStatus;
        }

        [WebMethod]
        public List<Language> SearchByBookLanguage(string sBookLanguage)
        {
            LanguageDAO langugageDao = new LanguageDAO();
            List<Language> listOfLanguages = langugageDao.SearchByBookLanguage(sBookLanguage);

            return listOfLanguages;

        }

        // user method 

        [WebMethod]
        public List<User> GetAllUsers()
        {
            UserDAO userDao = new UserDAO();
            List<User> listOfUsers = userDao.GetAllUsers();

            return listOfUsers;

        }

        [WebMethod]
        public int AddUser(string userName, string password, int userLevel)
        {
            UserDAO userDAO = new UserDAO();
            int userId = userDAO.AddUser(userName, password, userLevel);
            return userId;
        }

        [WebMethod]
        public int UpdateUser(int userId, string userName, string password, int userLevel)
        {
            UserDAO dao = new UserDAO();
            return dao.UpdateUser(userId, userName, password, userLevel);
        }

        [WebMethod]
        public User Login(string username, string password)
        {
            UserDAO userDao = new UserDAO();
            User user = userDao.Login(username, password);

            return user;
        }

        [WebMethod]
        public int DeleteUser(int originalUID, string originalUserName, string originalPassword, int originalUserLevel)
        {
            UserDAO userDAO = new UserDAO();
            return userDAO.DeleteUser(originalUID, originalUserName, originalPassword, originalUserLevel);
        }
    }
}
