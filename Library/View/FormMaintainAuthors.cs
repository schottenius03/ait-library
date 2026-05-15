using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class FormMaintainAuthors : Form
    {
        public FormMaintainAuthors()
        {
            InitializeComponent();
            dataGridViewAuthors.CellClick += dataGridViewAuthors_CellClick;
        }

        private void dataGridViewAuthors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // make sure row index is valid
            {
                DataGridViewRow selectedRow = dataGridViewAuthors.Rows[e.RowIndex];

                textBoxAuthorID.Text = selectedRow.Cells["AuthorID"].Value?.ToString() ?? "";
                textBoxAuthorName.Text = selectedRow.Cells["AuthorName"].Value?.ToString() ?? "";
            }
        }

        private void RefreshGrid()
        {
            AuthorController authorController = new AuthorController();
            var authors = authorController.GetAllAuthors();
            dataGridViewAuthors.DataSource = authors;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintain formMaintain = new FormMaintain();
            formMaintain.ShowDialog();
        }

        private void FormMaintainAuthors_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            string authorName = textBoxAuthorName.Text;
            if (!string.IsNullOrWhiteSpace(authorName))
            {
                try
                {
                    AuthorController authorController = new AuthorController();
                    int iStatus = authorController.AddAuthor(authorName);
                    if (iStatus == -1)
                    {
                        MessageBox.Show("Error: Failed to add author.");
                    }
                    else
                    {
                        MessageBox.Show("Author added successfully.");
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please type a valid author name.");
            }

            // clear textboxes
            textBoxAuthorID.Clear();
            textBoxAuthorName.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string authorName = textBoxAuthorName.Text;
            if (!string.IsNullOrWhiteSpace(authorName))
            {
                try
                {
                    AuthorController authorController = new AuthorController();
                    int iStatus = authorController.DeleteAuthor(authorName);
                    if (iStatus == -1)
                    {
                        MessageBox.Show("Error: Failed to delete author.");
                    }
                    else
                    {
                        MessageBox.Show("Author deleted successfully.");
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please type a valid author name.");
            }

            // clear textboxes
            textBoxAuthorID.Clear();
            textBoxAuthorName.Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxAuthorID.Text, out int authorId) || string.IsNullOrWhiteSpace(textBoxAuthorName.Text))
            {
                MessageBox.Show("Author ID must be a valid number and Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string authorName = textBoxAuthorName.Text.Trim();

            try
            {
                AuthorController authorController = new AuthorController();
                int iStatus = authorController.UpdateAuthor(authorName, authorId);

                if (iStatus == -1)
                {
                    MessageBox.Show("Error: Failed to update author.");
                }
                else
                {
                    MessageBox.Show("Author updated successfully.");
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            // clear textboxes
            textBoxAuthorID.Clear();
            textBoxAuthorName.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // No action needed here (can remove if unused)
        }
    }
}
