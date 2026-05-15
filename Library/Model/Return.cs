using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Return
    {
        private int uid;
        private string isbn;
        private DateTime returnDate;

        public int UID { get => uid; set => uid = value; }
        public string ISBN { get => isbn; set => isbn = value; }
        public DateTime ReturnDate { get => returnDate; set => returnDate = value; }

    }
}
