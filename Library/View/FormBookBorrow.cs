using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class FormBookBorrow : Form
    {
        public FormBookBorrow()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Find the ISBN column index by column name
                int isbnColIndex = dataGridView1.Columns["ISBN"]?.Index ?? -1;

                if (isbnColIndex >= 0)
                {
                    var isbnValue = dataGridView1.Rows[e.RowIndex].Cells[isbnColIndex].Value;
                    textBoxISBN.Text = isbnValue?.ToString() ?? string.Empty;
                }
            }
        }
        private void RefreshGrid()
        {
            ReservationController reservationController = new ReservationController();
            int userId = Kailing_Library_Global.UID;
            List<ReservationDTO> reservations = reservationController.GetReservationsByUserID(userId);

            if (reservations != null && reservations.Count > 0)
            {
                dataGridView1.DataSource = reservations;

                // Hide all columns except ISBN and ReservedDate
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Name != "ISBN" && col.Name != "ReservedDate")
                    {
                        col.Visible = false;
                    }
                    else
                    {
                        col.Visible = true;
                    }
                }
            }
            else
            {
                dataGridView1.DataSource = null;
                MessageBox.Show("No reservations found.");
            }
        }

        private void FormBookBorrow_Load(object sender, EventArgs e)
        {
            ReservationController reservationController = new ReservationController();
            int userId = Kailing_Library_Global.UID;
            List<ReservationDTO> reservations = reservationController.GetReservationsByUserID(userId);

            if (reservations != null && reservations.Count > 0)
            {
                dataGridView1.DataSource = reservations;

                // Hide all columns except ISBN and ReturnDate
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    if (col.Name != "ISBN" && col.Name != "ReservedDate")
                    {
                        col.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("No reservations found.");
            }
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

            // Use BorrowController instead of BookController
            BorrowController borrowController = new BorrowController();
            ReservationController reservationController = new ReservationController();

            bool success = borrowController.BorrowBook(uid, ISBN); // Updated method

            if (success)
            {
                bool reservationRemoved = reservationController.RemoveReservation(uid, ISBN);

                if (!reservationRemoved)
                {
                    MessageBox.Show("Warning: Failed to remove reservation.");
                }

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
