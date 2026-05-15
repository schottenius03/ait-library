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
    public partial class FormMaintain : Form
    {
        public FormMaintain()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdmin formDashboardAdmin = new FormDashboardAdmin();
            formDashboardAdmin.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAuthors_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintainAuthors formMaintainAuthors = new FormMaintainAuthors();
            formMaintainAuthors.ShowDialog();
        }

        private void buttonCategories_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintainCategories formMaintainCategories = new FormMaintainCategories();
            formMaintainCategories.ShowDialog();
        }

        private void buttonLanguages_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintainLanguage formMaintainLanguage = new FormMaintainLanguage();
            formMaintainLanguage.ShowDialog();
        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintainBooks formMaintainBooks = new FormMaintainBooks();
            formMaintainBooks.ShowDialog();
        }

        private void FormMaintain_Load(object sender, EventArgs e)
        {

        }
    }
}
