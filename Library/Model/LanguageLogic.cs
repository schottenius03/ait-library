using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LanguageLogic
    {
        public LanguageLogic() { }

        public List<Language> GetAllLanguages()
        {
            LanguageDAO LanguageDAO = new LanguageDAO();
            List<Language> listOfLanguages = LanguageDAO.GetAllLanguages();

            return listOfLanguages;

        }

        public int AddLanguage(string languageName)
        {
            LanguageDAO languageDAO = new LanguageDAO();
            int iStatus = languageDAO.AddLanguage(languageName);
            return iStatus;
        }

        public int UpdateLanguage(string lenguage, int lid)
        {
            LanguageDAO languageDAO = new LanguageDAO();
            int iStatus = languageDAO.UpdateLanguage(lenguage, lid);
            return iStatus;
        }

        public int DeleteLanguage(int lid, string lenguage)
        {

            LanguageDAO languageDAO = new LanguageDAO();
            int iStatus = languageDAO.DeleteLanguage(lid, lenguage);
            return iStatus;
        }

        public List<Language> SearchByBookLanguage(string sBookLanguage)
        {
            LanguageDAO langugageDao = new LanguageDAO();
            List<Language> listOfLanguages = langugageDao.SearchByBookLanguage(sBookLanguage);

            return listOfLanguages;

        }
    }
}
