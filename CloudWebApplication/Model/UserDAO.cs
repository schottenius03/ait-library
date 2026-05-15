using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataSetBookTableAdapters;
using Model.DataSetUserTableAdapters;
using static Model.DataSetUser;

namespace Model
{
    public class UserDAO
    {
        public List<User> GetAllUsers()
        {
            try
            {
                TabUserTableAdapter tabUserTableAdapter = new TabUserTableAdapter();
                DataSetUser.TabUserDataTable tabUserDataTable = tabUserTableAdapter.GetData();

                if (tabUserDataTable.Count == 0)
                {
                    return null;
                }

                List<User> listOfUsers = new List<User>();

                foreach (DataRow row in tabUserDataTable.Rows)
                {
                    User user = new User();
                    user.UserID = Convert.ToInt32(row["UID"].ToString().Trim());
                    user.UserName = row["UserName"].ToString().Trim();
                    user.Password = row["Password"].ToString().Trim();
                    user.UserLevel = Convert.ToInt32(row["UserLevel"].ToString().Trim());
                    listOfUsers.Add(user);
                }

                return listOfUsers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllUsers: {ex.Message}");
                return null;
            }
        }

        public int AddUser(string userName, string password, int userLevel)
        {
            try
            {
                TabUserTableAdapter tabUserTableAdapter = new TabUserTableAdapter();
                return tabUserTableAdapter.AddUser(userName, password, userLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddUser: {ex.Message}");
                return -1;
            }
        }

        public int DeleteUser(int originalUID, string originalUserName, string originalPassword, int originalUserLevel)
        {
            try
            {
                TabUserTableAdapter tabUserTableAdapter = new TabUserTableAdapter();
                return tabUserTableAdapter.DeleteUser(originalUID, originalUserName, originalPassword, originalUserLevel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteUser: {ex.Message}");
                return -1;
            }
        }

        public int UpdateUser(int userId, string userName, string password, int userLevel)
        {
            try
            {
                TabUserTableAdapter tabUserTableAdapter = new TabUserTableAdapter();
                return tabUserTableAdapter.UpdateUser(userName, password, userLevel, userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateUser: {ex.Message}");
                return -1;
            }
        }

        public User Login(string username, string password)
        {
            try
            {
                TabUserTableAdapter tabUserTableAdapter = new TabUserTableAdapter();
                DataSetUser.TabUserDataTable tabUserDataTable = tabUserTableAdapter.Login(username, password);

                if (tabUserDataTable == null || tabUserDataTable.Count == 0)
                {
                    return null;
                }

                DataRow row = tabUserDataTable.Rows[0];
                User user = new User
                {
                    UserName = username,
                    UserID = Convert.ToInt32(row["UID"].ToString()),
                    UserLevel = Convert.ToInt32(row["UserLevel"].ToString())
                };

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Login: {ex.Message}");
                return null;
            }
        }

    }
}
