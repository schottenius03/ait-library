using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class FormMaintainBooks : Form
    {
        public FormMaintainBooks()
        {
            InitializeComponent();
            dataGridViewBooks.CellClick += dataGridViewBooks_CellClick;
        }

        private void FormMaintainBooks_Load(object sender, EventArgs e)
        {
            //  load the combo box
            LoadAuthors();
            LoadCategories();
            LoadLanguages();

            // load the books grid after
            LoadBooks();
        }

        private void LoadBooks()
        {
            BookController bookController = new BookController();
            List<BookDTO> listOfBooks = bookController.GetAllBooksAvailable(); // ✅ use DTO

            dataGridViewBooks.DataSource = listOfBooks;

            // Hide the ID columns
            if (dataGridViewBooks.Columns.Contains("AuthorID"))
                dataGridViewBooks.Columns["AuthorID"].Visible = false;

            if (dataGridViewBooks.Columns.Contains("CategoryID"))
                dataGridViewBooks.Columns["CategoryID"].Visible = false;

            if (dataGridViewBooks.Columns.Contains("LanguageID"))
                dataGridViewBooks.Columns["LanguageID"].Visible = false;
        }

        private void LoadAuthors()
        {
            AuthorController authorController = new AuthorController();
            comboBoxBookAuthor.DataSource = authorController.GetAllAuthors();
            comboBoxBookAuthor.DisplayMember = "AuthorName";
            comboBoxBookAuthor.ValueMember = "AuthorID";
        }

        private void LoadCategories()
        {
            CategoryController categoryController = new CategoryController();
            comboBoxBookCategory.DataSource = categoryController.GetAllCategories();
            comboBoxBookCategory.DisplayMember = "CategoryName";
            comboBoxBookCategory.ValueMember = "CategoryID";
        }

        private void LoadLanguages()
        {
            LanguageController languageController = new LanguageController();
            comboBoxBookLanguage.DataSource = languageController.GetAllLanguages();
            comboBoxBookLanguage.DisplayMember = "LanguageName";
            comboBoxBookLanguage.ValueMember = "LanguageID";
        }

        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewBooks.Rows[e.RowIndex];

                // Fill textboxes
                textBoxBookISBN.Text = selectedRow.Cells["Isbn"].Value?.ToString();
                textBoxBookName.Text = selectedRow.Cells["BookName"].Value?.ToString();
                textBoxPublishYear.Text = selectedRow.Cells["PublishYear"].Value?.ToString();
                textBoxBookPages.Text = selectedRow.Cells["Pages"].Value?.ToString();
                textBoxBookPublisher.Text = selectedRow.Cells["Publisher"].Value?.ToString();

                // Fill comboboxes based on ID (not text)
                try
                {
                    comboBoxBookAuthor.SelectedValue = Convert.ToInt32(selectedRow.Cells["AuthorID"].Value);
                }
                catch
                {
                    comboBoxBookAuthor.SelectedIndex = -1;
                }

                try
                {
                    comboBoxBookCategory.SelectedValue = Convert.ToInt32(selectedRow.Cells["CategoryID"].Value);
                }
                catch
                {
                    comboBoxBookCategory.SelectedIndex = -1;
                }

                try
                {
                    comboBoxBookLanguage.SelectedValue = Convert.ToInt32(selectedRow.Cells["LanguageID"].Value);
                }
                catch
                {
                    comboBoxBookLanguage.SelectedIndex = -1;
                }
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            string isbn = textBoxBookISBN.Text.Trim();
            string bookName = textBoxBookName.Text.Trim();
            string publisher = textBoxBookPublisher.Text.Trim();

            if (string.IsNullOrEmpty(isbn) || string.IsNullOrEmpty(bookName))
            {
                MessageBox.Show("ISBN and Book Name are required.");
                return;
            }

            if (!int.TryParse(textBoxPublishYear.Text.Trim(), out int year) ||
                !int.TryParse(textBoxBookPages.Text.Trim(), out int pages))
            {
                MessageBox.Show("Publish year and pages must be valid numbers.");
                return;
            }

            int authorId = Convert.ToInt32(comboBoxBookAuthor.SelectedValue);
            int categoryId = Convert.ToInt32(comboBoxBookCategory.SelectedValue);
            int languageId = Convert.ToInt32(comboBoxBookLanguage.SelectedValue);

            try
            {
                BookController bookController = new BookController();
                int iStatus = bookController.AddBook(isbn, bookName, authorId, categoryId, languageId, year, pages, publisher);

                if (iStatus == -1)
                {
                    MessageBox.Show("Error: failed to add book. Check inner details in the debug output.");
                }
                else
                {
                    MessageBox.Show("Book added successfully.");
                    LoadBooks(); // refresh the book list
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception caught: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMaintain formMaintain = new FormMaintain();
            formMaintain.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string isbn = textBoxBookISBN.Text.Trim(); // Required to identify which book to update
            string bookName = textBoxBookName.Text.Trim();
            string publisher = textBoxBookPublisher.Text.Trim();

            if (string.IsNullOrEmpty(isbn) || string.IsNullOrEmpty(bookName))
            {
                MessageBox.Show("ISBN and Book Name are required.");
                return;
            }

            if (!int.TryParse(textBoxPublishYear.Text.Trim(), out int year) ||
                !int.TryParse(textBoxBookPages.Text.Trim(), out int pages))
            {
                MessageBox.Show("Publish year and pages must be valid numbers.");
                return;
            }

            if (comboBoxBookAuthor.SelectedValue == null ||
                comboBoxBookCategory.SelectedValue == null ||
                comboBoxBookLanguage.SelectedValue == null)
            {
                MessageBox.Show("Please select valid Author, Category, and Language.");
                return;
            }

            int authorId = Convert.ToInt32(comboBoxBookAuthor.SelectedValue);
            int categoryId = Convert.ToInt32(comboBoxBookCategory.SelectedValue);
            int languageId = Convert.ToInt32(comboBoxBookLanguage.SelectedValue);

            DialogResult confirm = MessageBox.Show("Update this book?", "Confirm Update", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                BookController controller = new BookController();
                int result = controller.UpdateBook(bookName, authorId, categoryId, languageId, year, pages, publisher, isbn);

                if (result > 0)
                {
                    MessageBox.Show("Book updated successfully.");
                    LoadBooks(); // Refresh grid
                }
                else
                {
                    MessageBox.Show("Update failed. Book not found or data mismatch.");
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string isbn = textBoxBookISBN.Text.Trim();
            string bookName = textBoxBookName.Text.Trim();
            string publisher = textBoxBookPublisher.Text.Trim();

            if (string.IsNullOrEmpty(isbn) || string.IsNullOrEmpty(bookName))
            {
                MessageBox.Show("Please select a valid book to delete.");
                return;
            }

            if (!int.TryParse(textBoxPublishYear.Text.Trim(), out int year) ||
                !int.TryParse(textBoxBookPages.Text.Trim(), out int pages))
            {
                MessageBox.Show("Publish Year and Pages must be numbers.");
                return;
            }

            int authorId = Convert.ToInt32(comboBoxBookAuthor.SelectedValue);
            int categoryId = Convert.ToInt32(comboBoxBookCategory.SelectedValue);
            int languageId = Convert.ToInt32(comboBoxBookLanguage.SelectedValue);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                BookController controller = new BookController();
                int status = controller.DeleteBook(isbn, bookName, authorId, categoryId, languageId, year, pages, publisher);

                if (status > 0)
                {
                    MessageBox.Show("Book deleted successfully.");
                    LoadBooks(); // Refresh
                }
                else
                {
                    MessageBox.Show("Delete failed. Book may not exist or data mismatch.");
                }
            }
        }
    }
}
