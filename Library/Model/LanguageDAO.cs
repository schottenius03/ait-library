using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetAuthorTableAdapters;
using Model.DataSetBookTableAdapters;
using Model.DataSetCategoryTableAdapters;
using Model.DataSetLanguageTableAdapters;

namespace Model
{
    public class LanguageDAO
    {
        public List<Language> GetAllLanguages()
        {
            try
            {
                TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();
                DataSetLanguage.TabLanguageDataTable tabLanguageDataTable = tabLanguageTableAdapter.GetData();

                if (tabLanguageDataTable == null || tabLanguageDataTable.Count == 0)
                {
                    return new List<Language>();
                }

                List<Language> listOfLanguages = new List<Language>();
                foreach (DataRow row in tabLanguageDataTable.Rows)
                {
                    Language language = new Language
                    {
                        LanguageID = Convert.ToInt32(row["LID"].ToString().Trim()),
                        LanguageName = row["LanguageName"].ToString().Trim()
                    };

                    listOfLanguages.Add(language);
                }

                return listOfLanguages;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllLanguages: {ex.Message}");
                return new List<Language>();
            }
        }

        public int AddLanguage(string languageName)
        {
            try
            {
                TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();
                return tabLanguageTableAdapter.AddLanguage(languageName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddLanguage: {ex.Message}");
                return -1;
            }
        }

        public int UpdateLanguage(string language, int lid)
        {
            try
            {
                TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();
                return tabLanguageTableAdapter.UpdateLanguage(language, lid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateLanguage: {ex.Message}");
                return -1;
            }
        }

        public int DeleteLanguage(int lid, string language)
        {
            try
            {
                TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();
                return tabLanguageTableAdapter.DeleteLanguage(lid, language);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteLanguage: {ex.Message}");
                return -1;
            }
        }

        public int GetLanguageIdByName(string languageName)
        {
            try
            {
                TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();
                object result = tabLanguageTableAdapter.GetLanguageIDByName(languageName);

                if (result != null && int.TryParse(result.ToString(), out int languageId))
                {
                    return languageId;
                }

                return -1; // not found or invalid
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetLanguageIdByName: {ex.Message}");
                return -1;
            }
        }

        public List<Language> SearchByBookLanguage(string sBookLanguage)
        {
            try
            {
                TabLanguageTableAdapter tabLanguageTableAdapter = new TabLanguageTableAdapter();
                DataSetLanguage.TabLanguageDataTable tabLanguageDataTable = tabLanguageTableAdapter.SearchByBookLanguage(sBookLanguage);

                if (tabLanguageDataTable == null || tabLanguageDataTable.Count == 0)
                {
                    return new List<Language>();
                }

                List<Language> listOfLanguages = new List<Language>();
                foreach (DataRow row in tabLanguageDataTable.Rows)
                {
                    Language language = new Language
                    {
                        LanguageID = Convert.ToInt32(row["LID"].ToString().Trim()),
                        LanguageName = row["LanguageName"].ToString().Trim()
                    };

                    listOfLanguages.Add(language);
                }

                return listOfLanguages;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchByBookLanguage: {ex.Message}");
                return new List<Language>();
            }
        }

    }
}
