using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class UserController
    {
        public List<UserDTO> GetAllUsers()
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.User[] users = webService.GetAllUsers();

            List<UserDTO> dtos = new List<UserDTO>();

            if (users != null)
            {
                foreach (ServiceReferenceLibrary.User user in users)
                {
                    UserDTO dto = new UserDTO
                    {
                        UserID = user.UserID,
                        UserName = user.UserName,
                        Password = user.Password,
                        UserLevel = user.UserLevel
                    };
                    dtos.Add(dto);
                }
            }

            return dtos;
        }


        public UserDTO Login(string username, string password)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            ServiceReferenceLibrary.User user = webService.Login(username, password);

            UserDTO userDTO = new UserDTO();

            if (user != null)
            {
                // assign each variable 
                userDTO.UserID = user.UserID;
                userDTO.UserName = user.UserName;
                userDTO.Password = user.Password;
                userDTO.UserLevel = user.UserLevel;

                return userDTO;
            }
            else
            {
                return null;
            }
        }
        public int AddUser(string userName, string password, int userLevel)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            int userId = webService.AddUser(userName, password, userLevel);
            return userId;
        }

        public int UpdateUser(int userId, string userName, string password, int userLevel)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.UpdateUser(userId, userName, password, userLevel);
        }

        public int DeleteUser(int originalUID, string originalUserName, string originalPassword, int originalUserLevel)
        {
            // call cloud method instead of local 
            ServiceReferenceLibrary.WebServiceLibrarySoapClient webService = new ServiceReferenceLibrary.WebServiceLibrarySoapClient();
            return webService.DeleteUser(originalUID, originalUserName, originalPassword, originalUserLevel);
        }

    }
}
