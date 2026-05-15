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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View
{
    public partial class FormReserveBook : Form
    {
        public FormReserveBook()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // value from column 0
                var value = dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                textBoxISBN.Text = value?.ToString();
            }
        }
        private void RefreshGrid()
        {
            BookController bookController = new BookController();
            List<BookDTO> listOfBooks = bookController.GetAllBooksAvailable();
            dataGridView1.DataSource = listOfBooks;
        }

        private void FormReserveBook_Load(object sender, EventArgs e)
        {
            BookController userControl = new BookController();
            List<BookDTO> listOfBooks = userControl.GetAllBooksAvailable();
            dataGridView1.DataSource = listOfBooks;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard formDashboard = new FormDashboard();
            formDashboard.ShowDialog();
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            string ISBN = textBoxISBN?.Text?.Trim();

            if (string.IsNullOrWhiteSpace(ISBN))
            {
                MessageBox.Show("Please select a book or enter an ISBN.");
                return;
            }

            ReservationController reservationController = new ReservationController();
            int uid = Kailing_Library_Global.UID;

            bool success = reservationController.AddNewReservation(uid, ISBN);

            if (success)
            {
                MessageBox.Show("Book reserved successfully!");

                RefreshGrid(); 
                textBoxISBN.Clear();
            }
            else
            {
                MessageBox.Show("Failed to reserve the book.");
            }

            // clear textbox
            textBoxISBN.Clear();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void lblDashboard_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxISBN_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
