using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    // Data Transfer Object for Book
    public class BookDTO
    {
        // Private fields
        private string isbn;
        private string bookName;
        private int publishYear;
        private int pages;
        private string publisher;

        private int authorID;
        private int categoryID;
        private int languageID;

        private string author;
        private string category;
        private string language;

        // Public properties
        public string Isbn { get => isbn; set => isbn = value; }
        public string BookName { get => bookName; set => bookName = value; }
        public int PublishYear { get => publishYear; set => publishYear = value; }
        public int Pages { get => pages; set => pages = value; }
        public string Publisher { get => publisher; set => publisher = value; }

        public int AuthorID { get => authorID; set => authorID = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int LanguageID { get => languageID; set => languageID = value; }

        public string Author { get => author; set => author = value; }
        public string Category { get => category; set => category = value; }
        public string Language { get => language; set => language = value; }
    }
}
