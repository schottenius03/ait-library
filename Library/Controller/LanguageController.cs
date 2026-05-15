using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class LanguageController
    {
        // connect to logic
        public List<LanguageDTO> GetAllLanguages()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Language[] languages = webService.GetAllLanguages();

            List<LanguageDTO> listOfLanguageDTO = new List<LanguageDTO>();
            if (languages != null)
            {
                foreach (ServiceReferenceLibrary.Language language in languages)
                {
                    LanguageDTO languageDTO = new LanguageDTO
                    {
                        LanguageID = language.LanguageID,
                        LanguageName = language.LanguageName
                    };
                    listOfLanguageDTO.Add(languageDTO);
                }
            }

            return listOfLanguageDTO;
        }

        public List<LanguageDTO> SearchByBookLanguage(string sBookLanguage)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Language[] languages = webService.SearchByBookLanguage(sBookLanguage);

            List<LanguageDTO> listOfLanguageDTO = new List<LanguageDTO>();
            if (languages != null)
            {
                foreach (ServiceReferenceLibrary.Language language in languages)
                {
                    LanguageDTO languageDTO = new LanguageDTO
                    {
                        LanguageID = language.LanguageID,
                        LanguageName = language.LanguageName
                    };
                    listOfLanguageDTO.Add(languageDTO);
                }
            }

            return listOfLanguageDTO;
        }

        public int AddLanguage(string languageName)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.AddLanguage(languageName);
        }

        public int UpdateLanguage(string languageName, int languageId)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.UpdateLanguage(languageName, languageId);
        }

        public int DeleteLanguage(int lid, string language)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.DeleteLanguage(lid, language);
        }

    }
}
