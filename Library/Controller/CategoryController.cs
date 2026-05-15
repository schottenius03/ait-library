using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class CategoryController
    {
        // connect with DAO
        public List<CategoryDTO> GetAllCategories()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Category[] categories = webService.GetAllCategories();

            List<CategoryDTO> listOfCategoryDTO = new List<CategoryDTO>();
            if (categories != null)
            {
                foreach (ServiceReferenceLibrary.Category category in categories)
                {
                    CategoryDTO categoryDTO = new CategoryDTO
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName
                    };
                    listOfCategoryDTO.Add(categoryDTO);
                }
            }

            return listOfCategoryDTO;
        }

        public List<CategoryDTO> SearchByBookCategory(string sCategory)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Category[] categories = webService.SearchByBookCategory(sCategory);

            List<CategoryDTO> listOfCategoryDTO = new List<CategoryDTO>();
            if (categories != null)
            {
                foreach (ServiceReferenceLibrary.Category category in categories)
                {
                    CategoryDTO categoryDTO = new CategoryDTO
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName
                    };
                    listOfCategoryDTO.Add(categoryDTO);
                }
            }

            return listOfCategoryDTO;
        }

        public int AddCategory(string categoryName)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.AddCategory(categoryName);
        }

        public int UpdateCategory(string categoryName, int categoryId)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.UpdateCategory(categoryName, categoryId);
        }

        public int DeleteCategory(string categoryName)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.DeleteCategory(categoryName);
        }
    }
}
