using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetAuthorTableAdapters;
using Model.DataSetCategoryTableAdapters;

namespace Model
{
    public class CategoryDAO
    {
        public List<Category> GetAllCategories()
        {
            try
            {
                TabCategoryTableAdapter tabCategoryTableAdapter = new TabCategoryTableAdapter();
                DataSetCategory.TabCategoryDataTable tabCategoryDataTable = tabCategoryTableAdapter.GetData();

                if (tabCategoryDataTable == null || tabCategoryDataTable.Count == 0)
                {
                    return new List<Category>();
                }

                List<Category> listOfCategories = new List<Category>();
                foreach (DataRow row in tabCategoryDataTable.Rows)
                {
                    Category category = new Category
                    {
                        CategoryID = Convert.ToInt32(row["CID"].ToString().Trim()),
                        CategoryName = row["CategoryName"].ToString().Trim()
                    };

                    listOfCategories.Add(category);
                }

                return listOfCategories;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllCategories: {ex.Message}");
                return new List<Category>();
            }
        }

        public int AddCategory(string categoryName)
        {
            try
            {
                TabCategoryTableAdapter tabCategoryTableAdapter = new TabCategoryTableAdapter();
                return tabCategoryTableAdapter.AddCategory(categoryName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddCategory: {ex.Message}");
                return -1;
            }
        }

        public int UpdateCategory(string categoryName, int categoryId)
        {
            try
            {
                TabCategoryTableAdapter tabCategoryTableAdapter = new TabCategoryTableAdapter();
                return tabCategoryTableAdapter.UpdateCategory(categoryName, categoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateCategory: {ex.Message}");
                return -1;
            }
        }

        public int GetCategoryIdByName(string categoryName)
        {
            try
            {
                TabCategoryTableAdapter tabCategoryTableAdapter = new TabCategoryTableAdapter();
                object result = tabCategoryTableAdapter.GetCategoryIDByName(categoryName);

                if (result != null && int.TryParse(result.ToString(), out int categoryId))
                {
                    return categoryId;
                }

                return -1; // not found or invalid
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCategoryIdByName: {ex.Message}");
                return -1;
            }
        }

        public int DeleteCategory(string categoryName)
        {
            try
            {
                TabCategoryTableAdapter tabCategoryTableAdapter = new TabCategoryTableAdapter();
                return tabCategoryTableAdapter.DeleteCategory(categoryName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteCategory: {ex.Message}");
                return -1;
            }
        }

        public List<Category> SearchByBookCategory(string sCategoryName)
        {
            try
            {
                TabCategoryTableAdapter tabCategoryTableAdapter = new TabCategoryTableAdapter();
                DataSetCategory.TabCategoryDataTable tabCategoryDataTable = tabCategoryTableAdapter.SearchByBookCategory(sCategoryName);

                if (tabCategoryDataTable == null || tabCategoryDataTable.Count == 0)
                {
                    return new List<Category>();
                }

                List<Category> listOfCategories = new List<Category>();
                foreach (DataRow row in tabCategoryDataTable.Rows)
                {
                    Category category = new Category
                    {
                        CategoryID = Convert.ToInt32(row["CID"].ToString().Trim()),
                        CategoryName = row["CategoryName"].ToString().Trim()
                    };

                    listOfCategories.Add(category);
                }

                return listOfCategories;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SearchByBookCategory: {ex.Message}");
                return new List<Category>();
            }
        }

    }
}
