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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
// upd reserve to upd correct table
// add bookAvailable after return

namespace View
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            // hide password characters 
            txtPassword.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get user input 
            string sUsername = txtUsername.Text;
            string sPassword = txtPassword.Text;

            //
            UserController userControl = new UserController();
            // call method from button 
            UserDTO user = userControl.Login(sUsername, sPassword);

            if (user == null)
            {
                MessageBox.Show("Invalid user, try again.");
            }
            else
            {
                // FormLogin hide
                this.Hide();
                FormDashboard formdashboard = new FormDashboard();
                formdashboard.ShowDialog();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            // checkBoxShow
            if (checkBoxShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sUsername = txtUsername.Text.Trim();
            string sPassword = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(sUsername) || string.IsNullOrEmpty(sPassword))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UserController userControl = new UserController();
                UserDTO user = userControl.Login(sUsername, sPassword);

                if (user == null)
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Save globally
                Kailing_Library_Global.UID = user.UserID;
                Kailing_Library_Global.UUsername = user.UserName;
                Kailing_Library_Global.UPassword = user.Password;
                Kailing_Library_Global.userLevel = user.UserLevel;

                // Hide login form
                this.Hide();

                Form dashboard;
                if (user.UserLevel == 1)
                    dashboard = new FormDashboard();
                else
                    dashboard = new FormDashboardAdmin();

                dashboard.FormClosed += (s, args) => this.Show(); // Reopen login when dashboard closes
                dashboard.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
