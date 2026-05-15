using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserLogic
    {
        public List<User> GetAllUsers()
        {
            UserDAO userDao = new UserDAO();
            List<User> listOfUsers = userDao.GetAllUsers();

            return listOfUsers;

        }

        public int AddUser(string userName, string password, int userLevel)
        {
            UserDAO userDAO = new UserDAO();
            int userId = userDAO.AddUser(userName, password, userLevel);
            return userId;
        }

        public int UpdateUser(int userId, string userName, string password, int userLevel)
        {
            UserDAO dao = new UserDAO();
            return dao.UpdateUser(userId, userName, password, userLevel);
        }

        public User Login(string username, string password)
        {
            UserDAO userDao = new UserDAO();
            User user = userDao.Login(username, password);

            return user;
        }

        public int DeleteUser(int originalUID, string originalUserName, string originalPassword, int originalUserLevel)
        {
            UserDAO userDAO = new UserDAO();
            return userDAO.DeleteUser(originalUID, originalUserName, originalPassword, originalUserLevel);
        }

    }
}
