using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {

        private int userID;
        private string userName;
        private string password;
        private int userLevel;

        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int UserLevel { get => userLevel; set => userLevel = value; }
    }
}
