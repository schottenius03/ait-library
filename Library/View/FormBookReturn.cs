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
using static System.Collections.Specialized.BitVector32;

namespace View
{
    public partial class FormBookReturn : Form
    {
        public FormBookReturn()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // value from column 0
                var value = dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                textBoxISBN.Text = value?.ToString();
            }
        }

        private void FormBookReturn_Load(object sender, EventArgs e)
        {
            ReturnController returnController = new ReturnController();
            int userId = Kailing_Library_Global.UID;
            DataTable borrowedBooks = returnController.GetActiveBorrowedBooks(userId);
            dataGridView1.DataSource = borrowedBooks;
        }

        private void RefreshGrid()
        {
            ReturnController returnController = new ReturnController();
            int userId = Kailing_Library_Global.UID;
            DataTable borrowedBooks = returnController.GetActiveBorrowedBooks(userId);  
            dataGridView1.DataSource = borrowedBooks;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard formDashboard = new FormDashboard();
            formDashboard.Show();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            string ISBN = textBoxISBN?.Text?.Trim();

            if (string.IsNullOrWhiteSpace(ISBN))
            {
                MessageBox.Show("Please select a book or enter an ISBN.");
                return;
            }

            int uid = Kailing_Library_Global.UID;
            ReturnController returnController = new ReturnController();

            // Attempt to borrow the book
            bool success = returnController.AddBookBorrow(uid, ISBN);

            if (success)
            {
                // Update return date after successful borrow
                returnController.UpdateReturnDate(uid, ISBN);

                MessageBox.Show("Book borrowed successfully!");
                RefreshGrid();
                textBoxISBN.Clear();
            }
            else
            {
                MessageBox.Show("Failed to borrow the book.");
            }

            // clear textbox
            textBoxISBN.Clear();
        }

    }
}
