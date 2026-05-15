using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Language
    {
        private int languageID;
        private string languageName;

        public int LanguageID { get => languageID; set => languageID = value; }
        public string LanguageName { get => languageName; set => languageName = value; }
    }
}
