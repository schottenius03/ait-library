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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBookReturn formBookReturn = new FormBookReturn();
            formBookReturn.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnBrowsing.BackColor = Color.Transparent;
            // FormDashboard hide
            this.Hide();

            // browsing
            FormBookBrowsing formBookBrowsing = new FormBookBrowsing();
            formBookBrowsing.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSearch.BackColor = Color.Transparent;
            this.Hide();

            // browsing
            FormBookSearch formBookSearch = new FormBookSearch();
            formBookSearch.ShowDialog();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            lblDashboard.BackColor = Color.Transparent;
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormReserveBook formReserveBook = new FormReserveBook();
            formReserveBook.Show();
        }

        private void buttonBorrow_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBookBorrow formBookBorrow = new FormBookBorrow();
            formBookBorrow.Show();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            FormProfile formProfile = new FormProfile();
            formProfile.Show();
        }
    }
}
