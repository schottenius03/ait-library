using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoryLogic
    {
        public List<Category> GetAllCategories()
        {
            CategoryDAO categoryDao = new CategoryDAO();
            List<Category> listOfCategories = categoryDao.GetAllCategories();

            return listOfCategories;

        }

        public int AddCategory(string categoryName)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            int iStatus = categoryDAO.AddCategory(categoryName);

            return iStatus;
        }

        public int UpdateCategory(string categoryName, int categoryId)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            int iStatus = categoryDAO.UpdateCategory(categoryName, categoryId);
            return iStatus;
        }

        public int DeleteCategory(string categoryName)
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            int iStatus = categoryDAO.DeleteCategory(categoryName);
            return iStatus;
        }

        public List<Category> SearchByBookCategory(string sBookCategory)
        {
            CategoryDAO categoryDao = new CategoryDAO();
            List<Category> listOfCategories = categoryDao.SearchByBookCategory(sBookCategory);

            return listOfCategories;

        }
    }
}
