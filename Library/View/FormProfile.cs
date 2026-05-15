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

namespace View
{
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            textBoxUserLevel.Text = Kailing_Library_Global.UID.ToString();
            textBoxUsername.Text = Kailing_Library_Global.UUsername;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard formDashboard = new FormDashboard();
            formDashboard.Show();
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                // password has not changed 
                this.Hide();
                FormDashboard formDashboard = new FormDashboard();
                formDashboard.Show();
                return;

            } 

            if (string.IsNullOrWhiteSpace(textBoxUsername.Text) || string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Kailing_Library_Global.UID;
            string userName = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            int userLevel = Kailing_Library_Global.userLevel;

            UserController userController = new UserController();
            int result = userController.UpdateUser(userId, userName, password, userLevel);

            if (result > 0)
            {
                MessageBox.Show("Changes saved.");
                textBoxUsername.Clear();
                textBoxPassword.Clear();
            }
            else
            {
                MessageBox.Show("Failed to update password.");
            }
            
        }

        private void textBoxUserLevel_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
