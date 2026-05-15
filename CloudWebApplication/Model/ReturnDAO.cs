using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetBookTableAdapters;

namespace Model
{
    public class ReturnDAO
    {
        public void UpdateReturnDate(int uid, string isbn)
        {
            try
            {
                TabBorrowTableAdapter adapter = new TabBorrowTableAdapter();
                adapter.UpdateReturnDate(uid, isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateReturnDate: {ex.Message}");
                // Optionally rethrow or handle accordingly
            }
        }

        public DataTable GetActiveBorrowedBooks(int uid)
        {
            try
            {
                TabBorrowTableAdapter adapter = new TabBorrowTableAdapter();
                return adapter.GetActiveBorrowedBooks(uid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetActiveBorrowedBooks: {ex.Message}");
                return null; // or new DataTable() if you prefer empty table
            }
        }

        public int AddBookBorrow(int uid, string isbn)
        {
            try
            {
                TabBorrowTableAdapter tabBorrowTableAdapter = new TabBorrowTableAdapter();
                return tabBorrowTableAdapter.AddBookBorrow(uid, isbn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddBookBorrow: {ex.Message}");
                return -1;
            }
        }

    }
}
