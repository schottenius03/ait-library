using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reservation
    {
        private int rid;
        private int uid;
        private string isbn;
        private DateTime reservedDate;

        public int RID { get => rid; set => rid = value; }
        public int UID { get => uid; set => uid = value; }
        public string ISBN { get => isbn; set => isbn = value; }
        public DateTime ReservedDate { get => reservedDate; set => reservedDate = value; }

    }

}
