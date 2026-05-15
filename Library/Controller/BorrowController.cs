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
    public class BorrowController
    {
        public bool BorrowBook(int uid, string isbn)
        {
            // call cloud method instead of local 
            WebServiceLibrarySoapClient webService = new WebServiceLibrarySoapClient();
            return webService.AddBorrow(uid, isbn);
        }

        public DataTable GetBorrowedBooks(int uid)
        {
            // call cloud method instead of local 
            WebServiceLibrarySoapClient webService = new WebServiceLibrarySoapClient();
            return webService.GetBorrowedBooks(uid);
        }
    }
}
