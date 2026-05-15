using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetBookTableAdapters;

namespace Model
{
    public class BorrowDAO
    {
        public int AddBorrow(int uid, string isbn)
        {
            try
            {
                TabBorrowTableAdapter adapter = new TabBorrowTableAdapter();
                return adapter.AddBookBorrow(uid, isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddBorrow: {ex.Message}");
                return -1; // indicate failure
            }
        }

        public DataTable GetBorrowedBooksByUser(int uid)
        {
            try
            {
                ViewBookBorrowedTableAdapter adapter = new ViewBookBorrowedTableAdapter();
                return adapter.GetDataByUID(uid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetBorrowedBooksByUser: {ex.Message}");
                return new DataTable(); // return empty table on failure
            }
        }

    }
}
