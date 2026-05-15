using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FormDashboardAdmin : Form
    {
        public FormDashboardAdmin()
        {
            InitializeComponent();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            DialogResult message = MessageBox.Show("Are you sure you wanna sign out?",
                      "", MessageBoxButtons.YesNo);
            switch (message)
            {
                case DialogResult.Yes:
                    this.Hide();
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        private void btnBrowsing_Click(object sender, EventArgs e)
        {
        }

        private void buttonMaintain_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintain formMaintain = new FormMaintain();
            formMaintain.Show();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormReports formReports = new FormReports();
            formReports.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintainUsers formMaintainUsers = new FormMaintainUsers();
            formMaintainUsers.ShowDialog();
        }

        private void FormDashboardAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
