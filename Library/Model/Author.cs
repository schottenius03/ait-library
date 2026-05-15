using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Author
    {
        private int authorID;
        private string authorName;

        public int AuthorID { get => authorID; set => authorID = value; }
        public string AuthorName { get => authorName; set => authorName = value; }
    }
}
