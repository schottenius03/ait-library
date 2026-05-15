using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller.ServiceReferenceLibrary;
using Model;

namespace Controller
{
    public class ReturnController
    {
        public void ReturnBook(int uid, string isbn)
        {
            // call cloud method instead of local 
            WebServiceLibrarySoapClient webService = new WebServiceLibrarySoapClient();
            webService.UpdateReturn(uid, isbn);
        }

        public DataTable GetActiveBorrowedBooks(int uid)
        {
            // call cloud method instead of local 
            WebServiceLibrarySoapClient webService = new WebServiceLibrarySoapClient();
            return webService.GetActiveBorrowedBooks(uid);
        }

        public void UpdateReturnDate(int uid, string isbn)
        {
            // call cloud method instead of local 
            WebServiceLibrarySoapClient webService = new WebServiceLibrarySoapClient();
            webService.UpdateReturnDate(uid, isbn);
        }

        public bool AddBookBorrow(int uid, string isbn)
        {
            // call cloud method instead of local 
            WebServiceLibrarySoapClient webService = new WebServiceLibrarySoapClient();
            return webService.AddBookBorrow(uid, isbn);
        }
    }
}
