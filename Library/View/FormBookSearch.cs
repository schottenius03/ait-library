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

namespace View
{
    public partial class FormBookSearch : Form
    {
        public FormBookSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // call the controller

            string sBookName = txtBookName.Text;

            BookController userControl = new BookController();
            List<BookDTO> listOfBooks = userControl.SearchByBookName(sBookName);
            dataGridView1.DataSource = listOfBooks;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sAuthor = txtAuthor.Text;
                AuthorController authorController = new AuthorController();
                List<AuthorDTO> listOfAuthors = authorController.SearchByAuthor(sAuthor);
                dataGridView1.DataSource = listOfAuthors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching authors: " + ex.Message);
            }
        }


        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            string sBookName = txtBookName.Text;

            BookController userControl = new BookController();
            List<BookDTO> listOfBooks = userControl.SearchByBookName(sBookName);
            dataGridView1.DataSource = listOfBooks;
        }

        private void lblAuthor_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sAuthor = txtAuthor.Text;
                AuthorController authorController = new AuthorController();
                List<AuthorDTO> listOfAuthors = authorController.SearchByAuthor(sAuthor);
                dataGridView1.DataSource = listOfAuthors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching authors: " + ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sBookLanguage = txtLanguage.Text;
                LanguageController languageController = new LanguageController();
                List<LanguageDTO> listOfLanguages = languageController.SearchByBookLanguage(sBookLanguage);
                dataGridView1.DataSource = listOfLanguages;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching languages: " + ex.Message);
            }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string sBookCategory = txtCategory.Text;
                CategoryController categoryController = new CategoryController();
                List<CategoryDTO> listOfCategories = categoryController.SearchByBookCategory(sBookCategory);
                dataGridView1.DataSource = listOfCategories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching categories: " + ex.Message);
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard formDashboard = new FormDashboard();
            formDashboard.ShowDialog();
        }

        private void txtBookName_Click(object sender, EventArgs e)
        {
            // reset 
            txtAuthor.Clear();
            txtLanguage.Clear();
            txtCategory.Clear();
        }

        private void txtAuthor_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            txtLanguage.Clear();
            txtCategory.Clear();
        }

        private void txtLanguage_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            txtAuthor.Clear();
            txtCategory.Clear();
        }

        private void txtCategory_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            txtAuthor.Clear();
            txtLanguage.Clear();
        }

        private void FormBookSearch_Load(object sender, EventArgs e)
        {

        }
    }
}