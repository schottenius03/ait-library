using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class LanguageDTO
    {
        private int languageID;
        private string languageName;

        public int LanguageID { get => languageID; set => languageID = value; }
        public string LanguageName { get => languageName; set => languageName = value; }
    }
}
