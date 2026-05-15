using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetBookTableAdapters;

namespace Model
{
    public class BookDAO
    {
        public List<Book> GetAllBooks()
        {
            try
            {
                TabBookTableAdapter adapter = new TabBookTableAdapter();
                DataSetBook.TabBookDataTable table = adapter.GetData();

                if (table == null || table.Count == 0) return new List<Book>();

                List<Book> books = new List<Book>();
                foreach (DataRow row in table.Rows)
                {
                    books.Add(new Book
                    {
                        Isbn = row["ISBN"].ToString().Trim(),
                        BookName = row["BookName"].ToString().Trim(),
                        Author = row["Author"].ToString().Trim(),
                        Category = row["Category"].ToString().Trim(),
                        Language = row["Language"].ToString().Trim(),
                        PublishYear = Convert.ToInt32(row["PublishYear"]),
                        Pages = Convert.ToInt32(row["Pages"]),
                        Publisher = row["Publisher"].ToString().Trim()
                    });
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllBooks: {ex.Message}");
                return new List<Book>();
            }
        }

        public List<Book> GetAllBooksAvailable()
        {
            try
            {
                ViewBookAvailableTableAdapter adapter = new ViewBookAvailableTableAdapter();
                DataSetBook.ViewBookAvailableDataTable table = adapter.GetData();

                if (table == null || table.Count == 0) return new List<Book>();

                List<Book> books = new List<Book>();
                foreach (DataRow row in table.Rows)
                {
                    books.Add(new Book
                    {
                        Isbn = row["ISBN"].ToString().Trim(),
                        BookName = row["BookName"].ToString().Trim(),
                        Author = row["Author"].ToString().Trim(),
                        Category = row["Category"].ToString().Trim(),
                        Language = row["Language"].ToString().Trim(),
                        PublishYear = Convert.ToInt32(row["PublishYear"]),
                        Pages = Convert.ToInt32(row["Pages"]),
                        Publisher = row["Publisher"].ToString().Trim()
                    });
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllBooksAvailable: {ex.Message}");
                return new List<Book>();
            }
        }

        public List<Book> GetAllBorrowedBooks()
        {
            try
            {
                ViewBookBorrowedTableAdapter adapter = new ViewBookBorrowedTableAdapter();
                DataSetBook.ViewBookBorrowedDataTable table = adapter.GetData();

                if (table == null || table.Count == 0) return new List<Book>();

                List<Book> books = new List<Book>();
                foreach (DataRow row in table.Rows)
                {
                    books.Add(new Book
                    {
                        Isbn = row["ISBN"].ToString().Trim(),
                        BookName = row["BookName"].ToString().Trim(),
                        Author = row["Author"].ToString().Trim(),
                        Category = row["Category"].ToString().Trim(),
                        Language = row["Language"].ToString().Trim(),
                        PublishYear = Convert.ToInt32(row["PublishYear"]),
                        Pages = Convert.ToInt32(row["Pages"]),
                        Publisher = row["Publisher"].ToString().Trim()
                    });
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllBorrowedBooks: {ex.Message}");
                return new List<Book>();
            }
        }

        public List<Book> SearchByBookName(string bookName)
        {
            try
            {
                TabBookTableAdapter adapter = new TabBookTableAdapter();
                DataSetBook.TabBookDataTable table = adapter.SearchByBookName(bookName);

                if (table == null || table.Count == 0) return new List<Book>();

                List<Book> books = new List<Book>();
                foreach (DataRow row in table.Rows)
                {
                    books.Add(new Book
                    {
                        Isbn = row["ISBN"].ToString().Trim(),
                        BookName = row["BookName"].ToString().Trim(),
                        Author = row["Author"].ToString().Trim(),
                        Category = row["Category"].ToString().Trim(),
                        Language = row["Language"].ToString().Trim(),
                        PublishYear = Convert.ToInt32(row["PublishYear"]),
                        Pages = Convert.ToInt32(row["Pages"]),
                        Publisher = row["Publisher"].ToString().Trim()
                    });
                }

                return books;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchByBookName: {ex.Message}");
                return new List<Book>();
            }
        }

        public int AddBook(string isbn, string bookName, int author, int category, int language, int year, int pages, string publisher)
        {
            try
            {
                TabBookTableAdapter adapter = new TabBookTableAdapter();
                return adapter.AddBook(isbn, bookName, author, category, language, year, pages, publisher);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddBook: {ex.Message}");
                return -1;
            }
        }

        public int UpdateBook(string bookName, int author, int category, int language, int year, int pages, string publisher, string isbn)
        {
            try
            {
                TabBookTableAdapter adapter = new TabBookTableAdapter();
                return adapter.UpdateBook(bookName, author, category, language, year, pages, publisher, isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateBook: {ex.Message}");
                return -1;
            }
        }

        public int DeleteBook(string isbn, string bookName, int author, int category, int language, int year, int pages, string publisher)
        {
            try
            {
                TabBookTableAdapter adapter = new TabBookTableAdapter();
                return adapter.DeleteBook(isbn, bookName, author, category, language, year, pages, publisher);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteBook: {ex.Message}");
                return -1;
            }
        }

        public int DeleteBookAvailable(string isbn)
        {
            try
            {
                ViewBookAvailableTableAdapter adapter = new ViewBookAvailableTableAdapter();
                return adapter.DeleteBookAvailable(isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteBookAvailable: {ex.Message}");
                return -1;
            }
        }
    }
}
