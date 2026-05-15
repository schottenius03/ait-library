using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class FormMaintainUsers : Form
    {
        public FormMaintainUsers()
        {
            InitializeComponent();
            dataGridViewUsers.CellClick += dataGridViewUsers_CellClick;
            this.Load += FormMaintainUsers_Load;  // <-- Add this line if missing
        }
        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // make sure a valid row is clicked
                {
                    DataGridViewRow selectedRow = dataGridViewUsers.Rows[e.RowIndex];

                    textBoxUserID.Text = selectedRow.Cells["UserID"].Value?.ToString() ?? "";
                    textBoxUserName.Text = selectedRow.Cells["UserName"].Value?.ToString() ?? "";
                    textBoxUserPassword.Text = selectedRow.Cells["Password"].Value?.ToString() ?? "";
                    textBoxUserLevel.Text = selectedRow.Cells["UserLevel"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdmin formDashboardAdmin = new FormDashboardAdmin();
            formDashboardAdmin.Show();
        }

        private void FormMaintainUsers_Load(object sender, EventArgs e)
        {
            try
            {
                UserController userController = new UserController();
                List<UserDTO> listOfUsers = userController.GetAllUsers(); // This should call the cloud service internally
                dataGridViewUsers.DataSource = listOfUsers;

                // Debug: print actual column names in the grid
                foreach (DataGridViewColumn col in dataGridViewUsers.Columns)
                {
                    Console.WriteLine($"Column: {col.Name} | Header: {col.HeaderText}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
        }



        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            string userName = textBoxUserName.Text.Trim();
            string password = textBoxUserPassword.Text.Trim();
            string userLevelText = textBoxUserLevel.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(userLevelText))
            {
                MessageBox.Show("Please fill in Username, Password, and User Level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(userLevelText, out int userLevel))
            {
                MessageBox.Show("User Level must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UserController userController = new UserController();

            int result = userController.AddUser(userName, password, userLevel);

            if (result > 0) // success
            {
                MessageBox.Show($"User added successfully!");
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Failed to add user.");
            }

            // clear textboxes
            textBoxUserID.Clear();
            textBoxUserLevel.Clear();
            textBoxUserName.Clear();
            textBoxUserPassword.Clear();

        }

        private void RefreshGrid()
        {
            UserController userController = new UserController();
            var users = userController.GetAllUsers();
            dataGridViewUsers.DataSource = users;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserID.Text) ||
                string.IsNullOrWhiteSpace(textBoxUserName.Text) ||
                string.IsNullOrWhiteSpace(textBoxUserPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxUserLevel.Text))
            {
                MessageBox.Show("All fields (ID, Username, Password, User Level) must be filled before deleting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = int.Parse(textBoxUserID.Text);
            string userName = textBoxUserName.Text;
            string password = textBoxUserPassword.Text;
            int userLevel = int.Parse(textBoxUserLevel.Text);

            UserController userController = new UserController();
            int status = userController.DeleteUser(userId, userName, password, userLevel);

            if (status > 0)
            {
                MessageBox.Show("User deleted successfully.");
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Failed to delete user. Data might have been changed by another process.");
            }

            // clear textboxes
            textBoxUserID.Clear();
            textBoxUserLevel.Clear();
            textBoxUserName.Clear();
            textBoxUserPassword.Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserID.Text) ||
                string.IsNullOrWhiteSpace(textBoxUserName.Text) ||
                string.IsNullOrWhiteSpace(textBoxUserPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxUserLevel.Text))
            {
                MessageBox.Show("Please fill in all fields (ID, Username, Password, User Level).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxUserID.Text, out int userId))
            {
                MessageBox.Show("Invalid User ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxUserLevel.Text, out int userLevel))
            {
                MessageBox.Show("User Level must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userName = textBoxUserName.Text.Trim();
            string password = textBoxUserPassword.Text.Trim();

            UserController userController = new UserController();
            int result = userController.UpdateUser(userId, userName, password, userLevel);

            if (result > 0)
            {
                MessageBox.Show("User updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update user.");
                RefreshGrid();
            }

            // clear textboxes
            textBoxUserID.Clear();
            textBoxUserLevel.Clear();
            textBoxUserName.Clear();
            textBoxUserPassword.Clear();
        }

    }
}
