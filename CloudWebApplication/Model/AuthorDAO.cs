using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetAuthorTableAdapters;
using Model.DataSetBookTableAdapters;

namespace Model
{
    public class AuthorDAO
    {
        public List<Author> GetAllAuthors()
        {
            try
            {
                TabAuthorTableAdapter tabAuthorTableAdapter = new TabAuthorTableAdapter();
                DataSetAuthor.TabAuthorDataTable tabAuthorDataTable = tabAuthorTableAdapter.GetData();

                if (tabAuthorDataTable == null || tabAuthorDataTable.Count == 0)
                {
                    return new List<Author>(); // return empty list instead of null
                }

                List<Author> listOfAuthors = new List<Author>();
                foreach (DataRow row in tabAuthorDataTable.Rows)
                {
                    Author author = new Author
                    {
                        AuthorID = Convert.ToInt32(row["AID"].ToString().Trim()),
                        AuthorName = row["AuthorName"].ToString().Trim()
                    };

                    listOfAuthors.Add(author);
                }

                return listOfAuthors;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllAuthors: {ex.Message}");
                return new List<Author>(); // return empty list on failure
            }
        }

        public int AddAuthor(string authorName)
        {
            try
            {
                TabAuthorTableAdapter tabAuthorTableAdapter = new TabAuthorTableAdapter();
                return tabAuthorTableAdapter.AddAuthor(authorName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddAuthor: {ex.Message}");
                return -1;
            }
        }

        public int UpdateAuthor(string authorName, int authorId)
        {
            try
            {
                TabAuthorTableAdapter tabAuthorTableAdapter = new TabAuthorTableAdapter();
                return tabAuthorTableAdapter.UpdateAuthor(authorName, authorId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateAuthor: {ex.Message}");
                return -1;
            }
        }

        public int DeleteAuthor(string authorName)
        {
            try
            {
                TabAuthorTableAdapter tabAuthorTableAdapter = new TabAuthorTableAdapter();
                return tabAuthorTableAdapter.DeleteAuthor(authorName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteAuthor: {ex.Message}");
                return -1;
            }
        }

        public int GetAuthorIdByName(string authorName)
        {
            try
            {
                TabAuthorTableAdapter adapter = new TabAuthorTableAdapter();
                object result = adapter.GetAuthorIDByName(authorName);

                if (result != null && int.TryParse(result.ToString(), out int authorId))
                {
                    return authorId;
                }

                return -1; // not found or invalid
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAuthorIdByName: {ex.Message}");
                return -1;
            }
        }

        public List<Author> SearchByAuthor(string sAuthor)
        {
            try
            {
                TabAuthorTableAdapter tabAuthorTableAdapter = new TabAuthorTableAdapter();
                DataSetAuthor.TabAuthorDataTable tabAuthorDataTable = tabAuthorTableAdapter.SearchByAuthor(sAuthor);

                if (tabAuthorDataTable == null || tabAuthorDataTable.Count == 0)
                {
                    return new List<Author>(); // empty list instead of null
                }

                List<Author> listOfAuthors = new List<Author>();
                foreach (DataRow row in tabAuthorDataTable.Rows)
                {
                    Author author = new Author
                    {
                        AuthorID = Convert.ToInt32(row["AID"].ToString().Trim()),
                        AuthorName = row["AuthorName"].ToString().Trim()
                    };
                    listOfAuthors.Add(author);
                }

                return listOfAuthors;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchByAuthor: {ex.Message}");
                return new List<Author>();
            }
        }

    }
}
