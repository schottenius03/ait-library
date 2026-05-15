using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// add
using Model;
using Controller;

namespace View
{
    public partial class FormBookBrowsing : Form
    {
        public FormBookBrowsing()
        {
            InitializeComponent();
            
        }
        private void FormBookBrowsing_Load(object sender, EventArgs e)
        {
            BookController userControl = new BookController();
            List<BookDTO> listOfBooks = userControl.GetAllBooks();
            dataGridView1.DataSource = listOfBooks;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard formDashboard = new FormDashboard();
            formDashboard.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { 
        }

        private void label1_Click(object sender, EventArgs e) { 

        }

    }
}
