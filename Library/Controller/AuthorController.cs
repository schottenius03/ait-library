using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class AuthorController
    {
        // get data from logic

        public List<AuthorDTO> GetAllAuthors()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Author[] authors = webService.GetAllAuthors();

            List<AuthorDTO> listOfAuthorDTO = new List<AuthorDTO>();

            if (authors != null)
            {
                foreach (ServiceReferenceLibrary.Author author in authors)
                {
                    AuthorDTO authorDTO = new AuthorDTO();
                    authorDTO.AuthorID = author.AuthorID;
                    authorDTO.AuthorName = author.AuthorName;
                    listOfAuthorDTO.Add(authorDTO);
                }
            }

            return listOfAuthorDTO;
        }

        public List<AuthorDTO> SearchByAuthor(string sAuthor)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.Author[] authors = webService.SearchByAuthor(sAuthor);

            List<AuthorDTO> listOfAuthors = new List<AuthorDTO>();

            if (authors != null)
            {
                foreach (ServiceReferenceLibrary.Author author in authors)
                {
                    AuthorDTO authorDTO = new AuthorDTO();
                    authorDTO.AuthorID = author.AuthorID;
                    authorDTO.AuthorName = author.AuthorName;
                    listOfAuthors.Add(authorDTO);
                }
            }

            return listOfAuthors;
        }

        public int AddAuthor(string authorName)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            int iStatus = webService.AddAuthor(authorName);
            return iStatus;
        }

        public int UpdateAuthor(string authorName, int authorId)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            int iStatus = webService.UpdateAuthor(authorName, authorId);
            return iStatus;
        }

        public int DeleteAuthor(string authorName)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            int iStatus = webService.DeleteAuthor(authorName);
            return iStatus;
        }

    }
}
