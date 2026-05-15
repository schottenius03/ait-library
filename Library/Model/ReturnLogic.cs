using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReturnLogic
    {

        public void UpdateReturn(int uid, string isbn)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            returnDAO.UpdateReturnDate(uid, isbn);
        }

        public DataTable GetActiveBorrowedBooks(int uid)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            return returnDAO.GetActiveBorrowedBooks(uid);
        }

        public void UpdateReturnDate(int uid, string isbn)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            returnDAO.UpdateReturnDate(uid, isbn);
        }

        public bool AddBookBorrow(int uid, string isbn)
        {
            ReturnDAO returnDAO = new ReturnDAO();
            return returnDAO.AddBookBorrow(uid, isbn) > 0;
        }
    }
}
