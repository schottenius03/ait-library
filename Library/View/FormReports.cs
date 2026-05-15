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
using Model.DataSetBookTableAdapters;

namespace View
{
    public partial class FormReports : Form
    {
        public FormReports()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboardAdmin formDashboardAdmin = new FormDashboardAdmin();
            formDashboardAdmin.Show();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReservationController reservationController = new ReservationController();
            List<ReservationDTO> reservations = reservationController.GetAllReservations();

            if (reservations != null && reservations.Count > 0)
            {
                dataGridViewBooks.DataSource = reservations;
            }
            else
            {
                MessageBox.Show("No reservations found.");
            }
        }

        private void buttonBooksAvailable_Click(object sender, EventArgs e)
        {
            BookController userController = new BookController();
            List<BookDTO> listOfBooks = userController.GetAllBooksAvailable();
            dataGridViewBooks.DataSource = listOfBooks;
        }

        private void buttonBooksBorrowed_Click(object sender, EventArgs e)
        {
            BookController bookController = new BookController(); 
            List<BookDTO> books = bookController.GetAllBorrowedBooks();

            if (books != null)
            {
                dataGridViewBooks.DataSource = books;
            }
            else
            {
                MessageBox.Show("No borrowed books found.");
            }
        }

        private void FormReports_Load(object sender, EventArgs e)
        {

        }
    }
}
