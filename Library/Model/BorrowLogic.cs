using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BorrowLogic
    {

        public bool AddBorrow(int uid, string isbn)
        {
            BorrowDAO borrowDAO = new BorrowDAO();
            return borrowDAO.AddBorrow(uid, isbn) > 0;
        }

        public DataTable GetBorrowedBooks(int uid)
        {
            BorrowDAO borrowDAO = new BorrowDAO();
            return borrowDAO.GetBorrowedBooksByUser(uid);
        }
    }
}
