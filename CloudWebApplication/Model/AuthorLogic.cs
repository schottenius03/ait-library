using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AuthorLogic
    {
        public List<Author> GetAllAuthors()
        {
            AuthorDAO authorDao = new AuthorDAO();
            List<Author> listOfAuthors = authorDao.GetAllAuthors();

            return listOfAuthors;

        }

        public int AddAuthor(string authorName)
        {
            AuthorDAO authorDAO = new AuthorDAO();
            int iStatus = authorDAO.AddAuthor(authorName);
            return iStatus;
        }

        public int UpdateAuthor(string authorName, int authorId)
        {
            AuthorDAO authorDAO = new AuthorDAO();
            int iStatus = authorDAO.UpdateAuthor(authorName, authorId);
            return iStatus;
        }

        public int DeleteAuthor(string authorName)
        {
            AuthorDAO authorDAO = new AuthorDAO();
            int iStatus = authorDAO.DeleteAuthor(authorName);
            return iStatus;
        }

        public List<Author> SearchByAuthor(string sAuthor)
        {
            AuthorDAO authorDao = new AuthorDAO();
            List<Author> listOfAuthors = authorDao.SearchByAuthor(sAuthor);

            return listOfAuthors;

        }
    }
}
